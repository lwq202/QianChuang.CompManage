/*
 * @Author: your name
 * @Date: 2021-02-11 18:27:45
 * @LastEditTime: 2021-02-13 13:04:01
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\vue-custom\component\index.ts
 */
// 内容布局
import Card from "@/components/layout/components/Card/index.vue";
// 弹出框
import DialogBox from "@/components/page/DialogBox/index.vue";
// 查询
import SearchBox from "@/components/page/SearchBox.tsx";
// 列表
import TableBox from "@/components/page/TableBox/index.vue";
// 操作按钮
import ButBox from "@/components/page/ButtonBox.vue";
// 表单项
import FormItem from "@/components/page/FormItem.vue";
// flex控制
import FlexBox from "@/components/page/FlexBox.vue";
// Create Form
import CreateForm from "@/components/page/CreateForm";
// string 转 函数式组件
import RenderView from "@/components/page/RenderView";
// icon
import Icon from "@/components/page/Icon/index.vue";
//富文本编辑器
import Tinymce from "@/components/page/Tinymce/index.vue";

export default [
  { key: "Card", value: Card },
  { key: "WtmDialogBox", value: DialogBox },
  { key: "WtmSearchBox", value: SearchBox },
  { key: "WtmTableBox", value: TableBox },
  { key: "WtmButBox", value: ButBox },
  { key: "WtmFormItem", value: FormItem },
  { key: "WtmFlexBox", value: FlexBox },
  { key: "WtmCreateForm", value: CreateForm },
  { key: "Tinymce", value: Tinymce },
  { key: "WtmRenderView", value: RenderView },
  { key: "WtmIcon", value: Icon }
];
