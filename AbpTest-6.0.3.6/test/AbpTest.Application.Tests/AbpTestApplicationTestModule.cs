using Volo.Abp.Modularity;

namespace AbpTest;

[DependsOn(
    typeof(AbpTestApplicationModule),
    typeof(AbpTestDomainTestModule)
    )]
public class AbpTestApplicationTestModule : AbpModule
{

}
