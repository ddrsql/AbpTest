﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Volo.Abp.Auditing;

//https://github.com/abpframework/abp/blob/9.1.0/framework/src/Volo.Abp.Auditing/Volo/Abp/Auditing/AuditingManager.cs
[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IAuditingManager))]
public class TestAuditingManager : IAuditingManager, ITransientDependency
{
    private const string AmbientContextKey = "Volo.Abp.Auditing.IAuditLogScope";

    protected IServiceProvider ServiceProvider { get; }
    protected AbpAuditingOptions Options { get; }
    protected ILogger<TestAuditingManager> Logger { get; set; }
    private readonly IAmbientScopeProvider<IAuditLogScope> _ambientScopeProvider;
    private readonly IAuditingHelper _auditingHelper;
    private readonly IAuditingStore _auditingStore;

    public TestAuditingManager(
        IAmbientScopeProvider<IAuditLogScope> ambientScopeProvider,
        IAuditingHelper auditingHelper,
        IAuditingStore auditingStore,
        IServiceProvider serviceProvider,
        IOptions<AbpAuditingOptions> options)
    {
        ServiceProvider = serviceProvider;
        Options = options.Value;
        Logger = NullLogger<TestAuditingManager>.Instance;

        _ambientScopeProvider = ambientScopeProvider;
        _auditingHelper = auditingHelper;
        _auditingStore = auditingStore;
    }

    public IAuditLogScope? Current => _ambientScopeProvider.GetValue(AmbientContextKey);

    public IAuditLogSaveHandle BeginScope()
    {
        var ambientScope = _ambientScopeProvider.BeginScope(
            AmbientContextKey,
            new AuditLogScope(_auditingHelper.CreateAuditLogInfo())
        );

        Debug.Assert(Current != null, "Current != null");

        return new DisposableSaveHandle(this, ambientScope, Current!.Log, Stopwatch.StartNew());
    }

    protected virtual void ExecutePostContributors(AuditLogInfo auditLogInfo)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var context = new AuditLogContributionContext(scope.ServiceProvider, auditLogInfo);

            foreach (var contributor in Options.Contributors)
            {
                try
                {
                    contributor.PostContribute(context);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, LogLevel.Warning);
                }
            }
        }
    }

    protected virtual void BeforeSave(DisposableSaveHandle saveHandle)
    {
        saveHandle.StopWatch.Stop();
        saveHandle.AuditLog.ExecutionDuration = Convert.ToInt32(saveHandle.StopWatch.Elapsed.TotalMilliseconds);
        ExecutePostContributors(saveHandle.AuditLog);
        MergeEntityChanges(saveHandle.AuditLog);
    }

    protected virtual void MergeEntityChanges(AuditLogInfo auditLog)
    {
        var changeGroups = auditLog.EntityChanges
            .Where(e => e.ChangeType == EntityChangeType.Updated)
            .GroupBy(e => new { e.EntityTypeFullName, e.EntityId })
            .ToList();

        foreach (var changeGroup in changeGroups)
        {
            if (changeGroup.Count() <= 1)
            {
                continue;
            }

            var firstEntityChange = changeGroup.First();

            foreach (var entityChangeInfo in changeGroup)
            {
                if (entityChangeInfo == firstEntityChange)
                {
                    continue;
                }

                firstEntityChange.Merge(entityChangeInfo);

                auditLog.EntityChanges.Remove(entityChangeInfo);
            }
        }
    }

    protected virtual async Task SaveAsync(DisposableSaveHandle saveHandle)
    {
        BeforeSave(saveHandle);

        await _auditingStore.SaveAsync(saveHandle.AuditLog);
    }

    protected class DisposableSaveHandle : IAuditLogSaveHandle
    {
        public AuditLogInfo AuditLog { get; }
        public Stopwatch StopWatch { get; }

        private readonly TestAuditingManager _auditingManager;
        private readonly IDisposable _scope;

        public DisposableSaveHandle(
            TestAuditingManager auditingManager,
            IDisposable scope,
            AuditLogInfo auditLog,
            Stopwatch stopWatch)
        {
            _auditingManager = auditingManager;
            _scope = scope;
            AuditLog = auditLog;
            StopWatch = stopWatch;
        }

        public async Task SaveAsync()
        {
            await _auditingManager.SaveAsync(this);
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}

