using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace AbpTest.Books.LocalEventHandlers;


public class BasicHandler : ILocalEventHandler<BasicLocalEvent>, ITransientDependency
{
    public async Task HandleEventAsync(BasicLocalEvent eventData)
    {
        await Task.Delay(500);
    }
}

public class TestHandler : ILocalEventHandler<TestLocalEvent>, ITransientDependency
{
    public async Task HandleEventAsync(TestLocalEvent eventData)
    {
        await Task.Delay(500);
    }
}
