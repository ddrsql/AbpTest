using AbpTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpTest.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpTestController : AbpControllerBase
{
    protected AbpTestController()
    {
        LocalizationResource = typeof(AbpTestResource);
    }
}
