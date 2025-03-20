using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpTest;

[Dependency(ReplaceServices = true)]
public class AbpTestBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpTest";
}
