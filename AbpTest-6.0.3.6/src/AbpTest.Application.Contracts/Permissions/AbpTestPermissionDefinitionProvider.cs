using AbpTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpTest.Permissions;

public class AbpTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpTestPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpTestPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpTestResource>(name);
    }
}
