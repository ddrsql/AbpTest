using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpTest.Data;
using Volo.Abp.DependencyInjection;

namespace AbpTest.EntityFrameworkCore;

public class EntityFrameworkCoreAbpTestDbSchemaMigrator
    : IAbpTestDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpTestDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
