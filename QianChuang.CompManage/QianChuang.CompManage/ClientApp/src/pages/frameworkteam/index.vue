<template>
    <card>
        <wtm-search-box :ref="searchRefName" :events="searchEvent" :formOptions="SEARCH_DATA" :needCollapse="true" :isActive.sync="isActive" />
        <!-- 操作按钮 -->
        <wtm-but-box :assembly="assembly" :action-list="actionList" :selected-data="selectData" :events="actionEvent" />
        <!-- 列表 -->
        <wtm-table-box :attrs="{...searchAttrs, actionList}" :events="{...searchEvent, ...actionEvent}">

        </wtm-table-box>
        <!-- 弹出框 -->
        <dialog-form :is-show.sync="dialogIsShow" :dialog-data="dialogData" :status="dialogStatus" @onSearch="onHoldSearch" />
        <!-- 导入 -->
        <upload-box :is-show.sync="uploadIsShow" @onImport="onImport" @onDownload="onDownload" />
    </card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import searchMixin from "@/vue-custom/mixin/search";
import actionMixin from "@/vue-custom/mixin/action-mixin";
import DialogForm from "./views/dialog-form.vue";
import store from "./store/index";
// 查询参数, table列 ★★★★★
import { ASSEMBLIES, TABLE_HEADER, LevelTypes } from "./config";
import i18n from "@/lang";

@Component({
    name: "frameworkteam",
    mixins: [searchMixin(TABLE_HEADER), actionMixin(ASSEMBLIES)],
    store,
    components: {
        DialogForm
    }
})
export default class Index extends Vue {
    isActive: boolean = false;
    @Action
    getFrameworkUser;
    @State
    getFrameworkUserData;
    @Action
    getFrameworkOrg;
    @State
    getFrameworkOrgData;

    get SEARCH_DATA() {
        return {
            formProps: {
                "label-width": "75px",
                inline: true
            },
            formItem: {
                "Name":{
                    label: " 团队名",
                    rules: [],
                    type: "input"
              },
                "LeaderId":{
                    label: "领导者",
                    rules: [],
                    type: "select",
                    children: this.getFrameworkUserData,
                    props: {
                        clearable: true,
                        placeholder: '全部'
                    }
              },
                "Level":{
                    label: "团队等级",
                    rules: [],
                    type: "select",
                    children: LevelTypes,
                    props: {
                        clearable: true,
                        placeholder: this.$t("form.all")
                    }
                    ,isHidden: !this.isActive
              },
                "OrgId":{
                    label: "组织",
                    rules: [],
                    type: "select",
                    children: this.getFrameworkOrgData,
                    props: {
                        clearable: true,
                        placeholder: '全部'
                    }
                    ,isHidden: !this.isActive
              },

            }
        };
    }

     mounted() {
        this.getFrameworkUser();
        this.getFrameworkOrg();

    }
}
</script>
