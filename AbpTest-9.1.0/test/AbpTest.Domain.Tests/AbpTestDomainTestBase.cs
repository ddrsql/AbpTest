using Volo.Abp.Modularity;

namespace AbpTest;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpTestDomainTestBase<TStartupModule> : AbpTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
