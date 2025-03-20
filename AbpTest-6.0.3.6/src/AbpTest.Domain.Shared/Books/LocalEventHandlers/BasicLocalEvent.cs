using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace AbpTest.Books.LocalEventHandlers;

public class BasicLocalEvent
{
    public BasicLocalEvent(string basic)
    {
        Basic = basic;
    }

    public string Basic {  get; set; }
}

public class TestLocalEvent : BasicLocalEvent
{
    public TestLocalEvent(string test, string basic) : base(basic)
    {
        Test = test;
    }

    public string Test { get; set; }
}

//public class BasicHandler : ILocalEventHandler<BasicLocalEvent>, ITransientDependency
//{
//    public async Task HandleEventAsync(BasicLocalEvent eventData)
//    {

//    }
//}

//public class TestHandler : ILocalEventHandler<TestLocalEvent>, ITransientDependency
//{
//    public async Task HandleEventAsync(TestLocalEvent eventData)
//    {

//    }
//}
