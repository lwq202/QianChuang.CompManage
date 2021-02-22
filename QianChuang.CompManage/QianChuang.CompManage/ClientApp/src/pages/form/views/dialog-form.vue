<template>
  <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
    <!-- <el-form v-model="Entity">
      <el-form-item label="财务人员" label-width="100px">

      <people v-model="Entity.Finance"></people>
      </el-form-item>
    </el-form> -->
    <wtm-create-form :ref="refName" :status="status" :options="formOptions" >
            
        </wtm-create-form>
  </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import People from "@/components/page/People.vue";
import { FrmTypeTypes } from "../config";

@Component({
  mixins: [formMixin()],
  components: {
    People,
  },
})
export default class Index extends Vue {
  // 表单结构
  get formOptions() {
    const filterMethod = (query, item) => {
      return item.label.indexOf(query) > -1;
    };
    return {
      formProps: {
        "label-width": "100px",
      },
      formItem: {
        "Entity.Name": {
          label: "表单名称",
          rules: [],
          type: "input",
        },
        "Entity.FrmType": {
          label: "表单类型",
          rules: [
            {
              required: true,
              message: "表单类型" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "select",
          children: FrmTypeTypes,
          props: {
            clearable: true,
          },
        },
        "Entity.WebId": {
          label:
            "系统页面",
          rules: [],
          type: "input",
        },
        "Entity.Fields": {
          label: "字段个数",
          rules: [
            {
              required: true,
              message: "字段个数" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "input",
        },
        // "Entity.ContentData": {
        //   label: "表单中的控件属性描述",
        //   rules: [],
        //   type: "input",
        // },
        // "Entity.ContentParse": {
        //   label: "表单控件位置模板",
        //   rules: [],
        //   type: "input",
        // },
        // "Entity.Content": {
        //   label: "表单原html模板未经处理的",
        //   rules: [],
        //   type: "input",
        // },
        "Entity.SortCode": {
          label: "排序码",
          rules: [
            {
              required: true,
              message: "排序码" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "input",
        },
        // "Entity.DeleteMark": {
        //   label: "删除标记",
        //   rules: [
        //     {
        //       required: true,
        //       message: "删除标记" + this.$t("form.notnull"),
        //       trigger: "blur",
        //     },
        //   ],
        //   type: "input",
        // },
        "Entity.DbName": {
          label: "数据库名称",
          rules: [],
          type: "input",
        },
        "Entity.Description": {
          label: "备注",
          rules: [],
          type: "input",
        },
        "Entity.OrgId": {
          label: "所属部门",
          rules: [],
          type: "input",
        },
      },
    };
  }
  beforeOpen() {}
  
}
</script>
