using AbpTest.Samples;
using Xunit;

namespace AbpTest.EntityFrameworkCore.Applications;

[Collection(AbpTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpTestEntityFrameworkCoreTestModule>
{

}
