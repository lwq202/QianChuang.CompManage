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
        key: "Name",
        label: " 团队名"
    },
    {
        key: "Name_view",
        label: "领导者"
    },
    {
        key: "Level",
        label: "团队等级"
    },
    {
        key: "OrgName_view",
        label: "组织"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const LevelTypes: Array<any> = [
  { Text: "一级", Value: "One" },
  { Text: "二级", Value: "Two" },
  { Text: "三级", Value: "Three" },
  { Text: "四级", Value: "Four" },
  { Text: "五级", Value: "Five" }
];

