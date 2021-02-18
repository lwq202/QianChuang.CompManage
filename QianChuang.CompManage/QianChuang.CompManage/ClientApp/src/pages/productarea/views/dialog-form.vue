<!--
 * @Author: your name
 * @Date: 2021-02-12 12:28:41
 * @LastEditTime: 2021-02-13 19:00:02
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\src\pages\productarea\views\dialog-form.vue
-->
<template>
  <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
    <el-form ref="form" :ref="refName" :model="Entity" :rules="rules" label-width="80px">
      <el-row>
        <el-col :span="12">
          <el-form-item label="省市" prop="City">
            <v-distpicker
              :province="Entity.Province"
              v-on:selected="onSelected"
              :city="Entity.City"
              hide-area
            ></v-distpicker>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="园区" prop="AreaName">
            <el-input v-model="Entity.AreaName" />
          </el-form-item>
        </el-col>
      </el-row>

      <el-row>
        <el-col :span="24">
          <table style="width: 100%; text-align: center">
            <thead>
              <tr>
                <td style="width: 50px">拥有</td>
                <td style="width: 50px">序号</td>
                <td>产品</td>
                <td style="width: 200px">价格</td>
                <td style="width: 300px">可忽略字段</td>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(Info, index) in Entity.ProductAreaInfos"
                :Key="index"
              >
                <td><el-checkbox v-model="Info.HasProduct"></el-checkbox></td>
                <td>{{ index + 1 }}</td>
                <td><i class="el-icon-edit" v-if="Info.ID" style="color:green"></i>{{ Info.InfoName }}</td>
                <td>
                  <el-input-number
                    v-model="Info.Price"
                    :step="1"
                    :precision="2"
                    :min="100"
                    style="width: 100%"
                  ></el-input-number>
                </td>
                <td><el-input v-model="Info.IgnoreFields"></el-input></td>
              </tr>
            </tbody>
          </table>
        </el-col>
      </el-row>
    </el-form>
  </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue, Watch,Ref } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import VDistpicker from "v-distpicker";
import { watch } from "fs";
import _request from "@/util/service.ts";
import api from "../store/api";

let InfoItemData={
      InfoId: null,
      InfoName: null,
      Price: 0,
      IgnoreFields: null,
      IsValid: true,
      HasProduct: false,
    };

@Component({
  mixins: [formMixin()],
  components: { VDistpicker },
})
export default class Index extends Vue {
  @Action
  getProductInfos;
  @State
  getProductInfosData;

onReset() {
    this.$data.Entity = this.InfoData() ;
      
    }

    /**
     * 提交
     */
    onSubmit() {
          debugger
          let that=this;
      this.FormComp().validate((valid, data) => {
        if (valid) {
            data=_.cloneDeep(that.$data);
          if (this.status === this["$actionType"].add) {
            this.onAdd(data);
          } else if (this.status === this["$actionType"].edit) {
            this.onEdit(data);
          }
        }
      });
    }
    private setFormData(data: Object) {
        Object.assign(this.$data.Entity,data.Entity);
        this.onGetProductInfosData();
    }



  /*
    数据模型
    */
  InfoData() {
    var item = this.InfoItemData();
    var model = {
        ID:null,
      Province: null,
      City: null,
      AreaName: null,
      ProductAreaInfos: [],
    };
    return model;
  }
  InfoItemData() {
    return {
        ID:null,
      InfoId: null,
      InfoName: null,
      Price: 0,
      IgnoreFields: null,
      IsValid: true,
      HasProduct: false,
    };
  }

  onSelected(data) {
    if (this.$data.Entity.City != data.city.value) {
      this.$data.Entity.City = data.city.value;
      this.$data.Entity.Province = data.province.value;
    }
  }
  data() {
    var Entity = this.InfoData();
    return {
      Entity: Entity,
    };
  }
  @Watch("getProductInfosData")
  onGetProductInfosData() {
    var entity = this.$data.Entity;
    for (let index = 0; index < this.getProductInfosData.length; index++) {
      const element = this.getProductInfosData[index];

      let has = false;
      if (entity.ProductAreaInfos) {
        for (let i = 0; i < entity.ProductAreaInfos.length; i++) {
          const info = entity.ProductAreaInfos[i];
          if (info.InfoId == element.InfoId) {
            has = true;
            info.InfoName = element.InfoName;
          }
        }
      }
      if (!has) {
        let item = _.cloneDeep(InfoItemData);
        item.InfoId = element.InfoId;
        item.InfoName = element.InfoName;
        if (entity.ProductAreaInfos) {
             this.$data.Entity.ProductAreaInfos.push(item);
        }else{
            Vue.set(this.$data.Entity.ProductAreaInfos, 0, item)
        }
       
      }
    }
  }
  beforeOpen() {
    this.getProductInfos();
  }

   rules: object = {
    City: [{ required: true, message: "请选择市", trigger: "blur" }],
    AreaName: [{ required: true, message: "请选择园区", trigger: "blur" }],

  };
}
</script>
