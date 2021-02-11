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
import { LevelTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getFrameworkUser;
    @State
    getFrameworkUserData;
    @Action
    getFrameworkOrg;
    @State
    getFrameworkOrgData;

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
             "Entity.Name":{
                 label: " 团队名",
                 rules: [],
                    type: "input"
            },
             "Entity.LeaderId":{
                 label: "领导者",
                 rules: [{ required: true, message: "领导者"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getFrameworkUserData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Level":{
                 label: "团队等级",
                 rules: [{ required: true, message: "团队等级"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: LevelTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.OrgId":{
                 label: "组织",
                 rules: [{ required: true, message: "组织"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getFrameworkOrgData,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getFrameworkUser();
        this.getFrameworkOrg();

    }
}
</script>
