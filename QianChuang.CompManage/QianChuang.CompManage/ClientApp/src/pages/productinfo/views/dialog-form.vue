<template>
  <wtm-dialog-box :rightDialog="true" :is-show="isShow" :status="status" :events="formEvent">
    <wtm-create-form
      :ref="refName"
      :status="status"
      :options="formOptions"
    ></wtm-create-form>
  </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";

@Component({
  mixins: [formMixin()],
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
        "Entity.ID": {
          isHidden: true,
        },
        "Entity.Name": {
          label: "产品名称",
          rules: [
            {
              required: true,
              message: "产品名称" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "input",
        },
        "Entity.Remark": {
          label: "产品备注",
          rules: [
            {
              required: true,
              message: "产品备注" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "input",
        },
        "Entity.FormCode": {
          label: "表单Code",
          rules: [],
          type: "input",
        },
        "Entity.Price": {
          label: "价格",
          rules: [],
          type: "input",
        },
        "Entity.Title": {
          label: "标题",
          rules: [
            {
              required: true,
              message: "标题" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "input",
        },
        "Entity.ImageId": {
          label: "图片",
          rules: [
            {
              required: true,
              message: "图片" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "upload",
          props: {
            isHead: true,
            imageStyle: { width: "100px", height: "100px" },
          },
        },
        "Entity.Content": {
          label: "正文",
          rules: [
            {
              required: true,
              message: "正文" + this.$t("form.notnull"),
              trigger: "blur",
            },
          ],
          type: "tinymce",
          prop: {
            height: "560px",
          },
          span: 24,
        },
      },
    };
  }
  beforeOpen() {}
}
</script>
