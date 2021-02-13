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
import { ASSEMBLIES, TABLE_HEADER, OrgTypeTypes } from "./config";
import i18n from "@/lang";

@Component({
    name: "frameworkorg",
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

    get SEARCH_DATA() {
        return {
            formProps: {
                "label-width": "75px",
                inline: true
            },
            formItem: {
                "OrgName":{
                    label: "组织名称",
                    rules: [],
                    type: "input"
              },
                "SOrgName":{
                    label: "组织简称",
                    rules: [],
                    type: "input"
              },
                "ManageUserId":{
                    label: "上级销售",
                    rules: [],
                    type: "select",
                    children: this.getFrameworkUserData,
                    props: {
                        clearable: true,
                        placeholder: '全部'
                    }
                    ,isHidden: !this.isActive
              },
                "LinkMan":{
                    label: "联系人",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "LinkPhone":{
                    label: "联系电话",
                    rules: [],
                    type: "input"
                    ,isHidden: !this.isActive
              },
                "OrgType":{
                    label: "组织类型",
                    rules: [],
                    type: "select",
                    children: OrgTypeTypes,
                    props: {
                        clearable: true,
                        placeholder: this.$t("form.all")
                    }
                    ,isHidden: !this.isActive
              },

            }
        };
    }

     mounted() {
        this.getFrameworkUser();

    }
}
</script>
