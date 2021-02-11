<!--
 * @Author: your name
 * @Date: 2021-02-11 16:04:58
 * @LastEditTime: 2021-02-11 17:06:31
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\frameworklog\views\dialog-form.vue
-->
<template>
  <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
    <el-form ref="form" :model="Entity" label-width="80px" size="mini">
      <el-row>
        <el-col :span="12">
          <el-form-item label="编号"> {{ Entity.ID }}</el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="其他信息">  <el-checkbox v-model="ShowOther">全部</el-checkbox></el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="等级"> {{ Entity.Level }}</el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="时间"> {{ Entity.TimeStamp }}</el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="消息"> {{ Entity.Message }}</el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="消息模板">
            {{ Entity.MessageTemplate }}</el-form-item
          >
        </el-col>
        <el-col :span="24">
          <el-form-item label="错误详情">
            <el-input
              type="textarea"
              :autosize="{ minRows: 16, maxRows: 20 }"
              v-model="Entity.Exception"
            >
            </el-input>
          </el-form-item>
        </el-col>
          <el-col :span="24" v-show="ShowOther">
            <el-form-item label="属性">
              <el-input
                type="textarea"
                :autosize="{ minRows: 6, maxRows: 8 }"
                v-model="Entity.Properties"
              >
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :span="24"  v-show="ShowOther">
            <el-form-item label="日志事件">
              <el-input
                type="textarea"
                :autosize="{ minRows: 6, maxRows: 8 }"
                v-model="Entity.LogEvent"
              >
              </el-input>
            </el-form-item>
          </el-col>
      </el-row>
    </el-form>
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
  private setFormData(data: Object) {
    Object.assign(this.$data.Entity, data.Entity);
  }

    onClose() {
      this.$emit("update:isShow", false);
      this.onReset();
      this.$data.ShowOther=false;
    }
  data() {
    return {
      Entity: {
        ID: null,
        Level: null,
        Message: null,
        TimeStamp: null,
        MessageTemplate: null,
        Properties: null,
        Exception: null,
        LogEvent: null,
      },
      ShowOther: false,
    };
  }
  beforeOpen() {}
}
</script>
