using System.Threading.Tasks;

namespace AbpTest.Data;

public interface IAbpTestDbSchemaMigrator
{
    Task MigrateAsync();
}
