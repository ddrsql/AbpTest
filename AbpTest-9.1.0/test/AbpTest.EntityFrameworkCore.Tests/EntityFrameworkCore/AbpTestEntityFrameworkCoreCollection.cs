using Xunit;

namespace AbpTest.EntityFrameworkCore;

[CollectionDefinition(AbpTestTestConsts.CollectionDefinitionName)]
public class AbpTestEntityFrameworkCoreCollection : ICollectionFixture<AbpTestEntityFrameworkCoreFixture>
{

}
