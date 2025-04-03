using AbpTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpTest.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTestEntityFrameworkCoreModule),
    typeof(AbpTestApplicationContractsModule)
)]
public class AbpTestDbMigratorModule : AbpModule
{
}
