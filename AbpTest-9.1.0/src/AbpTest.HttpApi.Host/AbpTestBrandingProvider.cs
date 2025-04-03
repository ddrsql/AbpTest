using Microsoft.Extensions.Localization;
using AbpTest.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpTest;

[Dependency(ReplaceServices = true)]
public class AbpTestBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpTestResource> _localizer;

    public AbpTestBrandingProvider(IStringLocalizer<AbpTestResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
