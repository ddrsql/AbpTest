using Volo.Abp.Settings;

namespace AbpTest.Settings;

public class AbpTestSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpTestSettings.MySetting1));
    }
}
