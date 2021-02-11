<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions" ></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import { OrgTypeTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getFrameworkUser;
    @State
    getFrameworkUserData;

    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
             "Entity.OrgName":{
                 label: "组织名称",
                 rules: [{ required: true, message: "组织名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.SOrgName":{
                 label: "组织名称简称",
                 rules: [{ required: true, message: "组织名称简称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.ManageUserId":{
                 label: "上级销售",
                 rules: [],
                    type: "select",
                    children: this.getFrameworkUserData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.LinkMan":{
                 label: "联系人",
                 rules: [],
                    type: "input"
            },
             "Entity.LinkPhone":{
                 label: "联系电话",
                 rules: [],
                    type: "input"
            },
             "Entity.OrgType":{
                 label: "组织类型",
                 rules: [{ required: true, message: "组织类型"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: OrgTypeTypes,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getFrameworkUser();

    }
}
</script>
