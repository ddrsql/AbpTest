using AbpTest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpTest;

[DependsOn(
    typeof(AbpTestEntityFrameworkCoreTestModule)
    )]
public class AbpTestDomainTestModule : AbpModule
{

}
