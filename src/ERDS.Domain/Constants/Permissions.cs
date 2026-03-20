namespace ERDS.Domain.Constants;

public static class Permissions
{
    public const string InventoryView = "inventory.view";
    public const string InventoryCreate = "inventory.create";
    public const string InventoryEdit = "inventory.edit";
    public const string InventoryDelete = "inventory.delete";

    public const string DistributionView = "distribution.view";
    public const string DistributionCreate = "distribution.create";
    public const string DistributionApprove = "distribution.approve";
    public const string DistributionReceive = "distribution.receive";

    public const string ProjectView = "project.view";
    public const string ProjectCreate = "project.create";
    public const string ProjectEdit = "project.edit";

    public const string ReportsView = "reports.view";
    public const string ReportsExport = "reports.export";

    public const string AdminManageUsers = "admin.manage_users";
    public const string AdminManageRoles = "admin.manage_roles";
    public const string AdminManageSettings = "admin.manage_settings";
}
