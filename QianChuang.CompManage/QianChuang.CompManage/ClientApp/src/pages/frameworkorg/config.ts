import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "OrgName",
        label: "组织名称"
    },
    {
        key: "SOrgName",
        label: "组织名称简称"
    },
    {
        key: "Name_view",
        label: "上级销售"
    },
    {
        key: "LinkMan",
        label: "联系人"
    },
    {
        key: "LinkPhone",
        label: "联系电话"
    },
    {
        key: "OrgType",
        label: "组织类型"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const OrgTypeTypes: Array<any> = [
  { Text: "管理组织", Value: "Manage" },
  { Text: "其他组织", Value: "Other" },
  { Text: "客户组织", Value: "User" }
];

