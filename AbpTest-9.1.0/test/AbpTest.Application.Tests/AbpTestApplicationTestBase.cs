using Volo.Abp.Modularity;

namespace AbpTest;

public abstract class AbpTestApplicationTestBase<TStartupModule> : AbpTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
