/*
 * @Author: your name
 * @Date: 2021-02-12 12:28:41
 * @LastEditTime: 2021-02-13 17:26:39
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\productarea\store\api.ts
 */
import config from "@/config/index";
import { contentType } from "@/config/enum";
const reqPath = config.headerApi + "/productarea/";

// 列表
const search = {
  url: reqPath + "search",
  method: "post",
  dataType: "array"
};
// 添加
const add = {
  url: reqPath + "Add",
  method: "post"
};
// 删除
const deleted = {
  url: reqPath + "Delete/{ID}",
  method: "get"
};
// 批量删除
const batchDelete = {
  url: reqPath + "BatchDelete",
  method: "post"
};
// 修改
const edit = {
  url: reqPath + "Edit",
  method: "put"
};
// 详情
const detail = {
  url: reqPath + "{ID}",
  method: "get"
};
const exportExcel = {
  url: reqPath + "ExportExcel",
  method: "post",
  contentType: contentType.stream
};
const exportExcelByIds = {
  url: reqPath + "ExportExcelByIds",
  method: "post",
  contentType: contentType.stream
};
const getExcelTemplate = {
  url: reqPath + "GetExcelTemplate",
  method: "get",
  contentType: contentType.stream
};
// 导入
const imported = {
  url: reqPath + "Import",
  method: "post"
};

// 获取产品信息
const getProductInfos = {
  url: reqPath + "GetProductInfos",
  method: "get",
  dataType: "array"
};

export default {
  getProductInfos,
  search,
  add,
  deleted,
  batchDelete,
  edit,
  detail,
  exportExcel,
  exportExcelByIds,
  getExcelTemplate,
  imported
};
