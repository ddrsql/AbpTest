using Volo.Abp.Modularity;

namespace AbpTest;

[DependsOn(
    typeof(AbpTestDomainModule),
    typeof(AbpTestTestBaseModule)
)]
public class AbpTestDomainTestModule : AbpModule
{

}
