using AbpTest.Samples;
using Xunit;

namespace AbpTest.EntityFrameworkCore.Domains;

[Collection(AbpTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpTestEntityFrameworkCoreTestModule>
{

}
