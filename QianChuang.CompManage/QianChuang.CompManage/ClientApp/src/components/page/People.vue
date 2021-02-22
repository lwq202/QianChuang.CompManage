<!--
 * @Author: your name
 * @Date: 2021-02-18 15:32:38
 * @LastEditTime: 2021-02-19 08:52:50
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\components\page\People.vue
-->
<template>
  <div>
    <el-row> 
      <el-col :span="24">
        <a  v-on:click="IsEdit=true">{{Entity.Name}}-{{Entity.LegalIdentityNum}}-{{Entity.LegalAddress}}</a>
      </el-col>
    </el-row>

<el-dialog
  title="修改人员信息"
  :visible.sync="IsEdit"
  width="900px"
  :modal=false
  :before-close="onClose"
  >
  
    <el-row>
      <el-col :span="12">
        <el-form-item prop="Name" label="名称" :label-width="labelWidth">
          <el-input v-model="Entity.Name"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.LegalIdentityNum"
          label="身份证"
          :label-width="labelWidth"
        >
          <el-input v-model="Entity.LegalIdentityNum"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.LegalLimitDate"
          label="有效时间"
          :label-width="labelWidth"
        >
          <el-date-picker
            v-model="Entity.LegalLimitDate"
            type="date"
            placeholder="选择日期"
          >
          </el-date-picker>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.LegalAddress"
          label="地址"
          :label-width="labelWidth"
        >
          <el-input v-model="Entity.LegalAddress"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item prop="Nation" label="民族" :label-width="labelWidth">
          <el-input v-model="Entity.Nation"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.Education"
          label="文化程度"
          :label-width="labelWidth"
        >
          <el-input v-model="Entity.Education"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.Political"
          label="政治面貌"
          :label-width="labelWidth"
        >
          <el-input v-model="Entity.Political"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item prop="ZipCode" label="邮政编码" :label-width="labelWidth">
          <el-input v-model="Entity.ZipCode"></el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.IdentityId"
          label="身份证正面"
          :label-width="labelWidth"
        >
          <wtm-upload-img
            :imgId="Entity.IdentityId"
            :imageStyle="imageStyle"
            v-on:onBackImgId="(a) => onBackImgId(a, 'IdentityId')"
          ></wtm-upload-img>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item
          prop="Entity.IdentityBackId"
          label="身份证反面"
          :label-width="labelWidth"
        >
          <wtm-upload-img
            :imgId="Entity.IdentityBackId"
            :imageStyle="imageStyle"
            v-on:onBackImgId="(a) => onBackImgId(a, 'IdentityBackId')"
          ></wtm-upload-img>
        </el-form-item>
      </el-col>
    </el-row>
    
  <span slot="footer" class="dialog-footer">
    <el-button type="primary" @click="submit = false">确 定</el-button>
  </span>
</el-dialog>
  </div>
</template>
<script lang="ts">
import WtmUploadImg from "@/components/page/UploadImg.vue";
import { Component, Vue, Prop, Inject, Ref } from "vue-property-decorator";
@Component({
  components: {
    WtmUploadImg,
  },
})
export default class People extends Vue {
  @Prop({ required: true })
  value!: IFrmPeople;
  @Prop({ default: "100px" })
  labelWidth;

  @Prop({ default: { width: "100px", height: "100px" } })
  imageStyle;

  onBackImgId(reId, key) {
    debugger;
    this.$set(this.value, key, reId);
  }
  submit(){
    this.$data.IsEdit = false;
    Object.assign(this.value,this.$data.Entity);
  }
  onClose(done){
    debugger
    Object.assign(this.$data.Entity,this.value);
    done();
    return true;
  }
  data() {
    return {
    Entity:_.cloneDeep(this.value),
    IsEdit:false};
  }
}

interface IFrmPeople {
  ID: string;
  Name: string;
  LegalIdentityNum: string;
  LegalLimitDate: string;
  LegalAddress: string;
  Nation: string; //民族
  Education: string; //文化程度
  Political: string; //政治面貌
  ZipCode: string;
  IdentityId: string;
  IdentityBackId: string;
  
}
</script>