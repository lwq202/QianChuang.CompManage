/*
 * @Author: your name
 * @Date: 2021-02-18 11:48:51
 * @LastEditTime: 2021-02-18 12:09:32
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\form\config.ts
 */
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
        key: "ID",
        label: "ID"
    },
    {
        key: "Name",
        label: "表单名称"
    },
    {
        key: "FrmType",
        label: "表单类型"
    },
    {
        key: "SortCode",
        label: "排序码"
    },
    {
        key: "DeleteMark",
        label: "删除标记"
    },
    {
        key: "DbName",
        label: "数据库名称"
    },
    {
        key: "Description",
        label: "备注"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const FrmTypeTypes: Array<any> = [
  { Text: "默认动态表单", Value: "Default" },
  { Text: "Web自定义表单", Value: "Web" }
];

