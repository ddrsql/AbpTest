using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpTest.Data;

/* This is used if database provider does't define
 * IAbpTestDbSchemaMigrator implementation.
 */
public class NullAbpTestDbSchemaMigrator : IAbpTestDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
