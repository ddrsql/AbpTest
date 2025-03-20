using System;
using System.Collections.Generic;
using System.Text;
using AbpTest.Localization;
using Volo.Abp.Application.Services;

namespace AbpTest;

/* Inherit your application services from this class.
 */
public abstract class AbpTestAppService : ApplicationService
{
    protected AbpTestAppService()
    {
        LocalizationResource = typeof(AbpTestResource);
    }
}
