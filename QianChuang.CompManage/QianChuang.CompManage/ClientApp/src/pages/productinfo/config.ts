/*
 * @Author: your name
 * @Date: 2021-02-12 12:27:49
 * @LastEditTime: 2021-02-13 14:13:16
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\productinfo\config.ts
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
        key: "Name",
        label: "产品名称"
    },
    {
        key: "Remark",
        label: "产品备注"
    },
    {
        key: "FormCode",
        label: "表单Code"
    },
    {
        key: "Price",
        label: "价格"
    },
    {
        key: "Title",
        label: "标题"
    },
    {
        key: "ImageId",
        label: "图片",
        isSlot: true 
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];


