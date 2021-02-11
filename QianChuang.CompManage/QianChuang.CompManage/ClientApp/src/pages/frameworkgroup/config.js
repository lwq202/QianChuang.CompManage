import i18n from "@/lang";
// 页面中，需要展示的动作按钮；增，改，删，导入，导出
export var ASSEMBLIES = [
    "add",
    "edit",
    "delete",
    "export",
    "imported"
];
export var TABLE_HEADER = [
    { key: "GroupCode", sortable: true, label: i18n.t("frameworkgroup.GroupCode") },
    { key: "GroupName", sortable: true, label: i18n.t("frameworkgroup.GroupName") },
    { key: "GroupRemark", sortable: true, label: i18n.t("frameworkgroup.GroupRemark") },
    { isOperate: true, label: i18n.t("table.actions"), actions: ["detail", "edit", "deleted"] } //操作列
];
//# sourceMappingURL=config.js.map