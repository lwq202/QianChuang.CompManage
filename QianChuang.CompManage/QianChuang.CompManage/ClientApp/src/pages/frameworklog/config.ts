/*
 * @Author: your name
 * @Date: 2021-02-11 16:04:58
 * @LastEditTime: 2021-02-11 16:07:52
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\frameworklog\config.ts
 */
import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "export"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "Level",
        label: "等级"
    },
    {
        key: "Message",
        label: "消息"
    },
    {
        key: "TimeStamp",
        label: "时间"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail"] } //操作列
];


