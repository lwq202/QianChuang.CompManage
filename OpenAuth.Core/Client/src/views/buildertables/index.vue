<template>
  <div class="flex-column">
    <sticky :className="'sub-navbar'">
      <div class="filter-container">
        <el-input @keyup.enter.native="handleFilter" size="mini" style="width: 200px;" class="filter-item"
          :placeholder="'名称'" v-model="firstQuery.key">
        </el-input>
        <el-button class="filter-item" size="mini" v-waves icon="el-icon-search" @click="handleFilter">搜索</el-button>
        <permission-btn moduleName='builderTables' size="mini" v-on:btn-event="onBtnClicked"></permission-btn>
      </div>
    </sticky>
    <div class="app-container flex-item flex-column">
      <div class="flex-item">
        <el-card shadow="nerver" class="demo-card fh">
          <el-table ref="multipleTable" id="firstCard" :key='tableKey' :data="mainList" v-loading="listLoading" border
            tooltip-effect="dark" style="width: 100%;" height="calc(100% - 52px)" @row-click="rowClickFirstTable">
            <el-table-column width="55" align="center">
              <template slot-scope="scope">
                <el-radio :label="scope.row.id" v-model="radio">{{''}}</el-radio>
              </template>
            </el-table-column>
            <el-table-column prop="tableName" label="表名" show-overflow-tooltip></el-table-column>
            <el-table-column prop="comment" label="描述" show-overflow-tooltip></el-table-column>
            <el-table-column prop="detailTableName" label="子表名称" show-overflow-tooltip></el-table-column>
            <el-table-column prop="detailComment" label="子表描述" show-overflow-tooltip></el-table-column>
            <el-table-column prop="className" label="实体类名称" show-overflow-tooltip></el-table-column>
            <el-table-column prop="namespace" label="命名空间" show-overflow-tooltip></el-table-column>
            <el-table-column prop="moduleCode" label="模块标识" show-overflow-tooltip></el-table-column>
            <el-table-column prop="moduleName" label="模块名称" show-overflow-tooltip></el-table-column>
            <el-table-column prop="folder" label="vue根目录" show-overflow-tooltip></el-table-column>
            <el-table-column prop="options" label="其它选项" show-overflow-tooltip></el-table-column>
            <el-table-column prop="typeName" label="分类名称" show-overflow-tooltip></el-table-column>
          </el-table>
          <pagination v-show="firstTotal>0" :total="firstTotal" :page.sync="firstQuery.page"
            :limit.sync="firstQuery.limit" @pagination="handleCurrentChange" />
        </el-card>
      </div>
      <el-row class="flex-item">
        <el-col :span="showTitleDialog ? 12 : 0" class="fh form-card">
          <el-card shadow="nerver" class="demo-card fh">
            <div slot="header">
              <span v-if="radio == ''">表信息</span>
              <span v-else>{{tableName}}表信息</span>
            </div>
            <el-form :rules="mainRules" ref="dataForm" :model="firstTemp" label-position="right" label-width="140px"
              style="height:calc(100% - 34px);overflow: auto;">
              <el-row>
                <el-col :span="12" class="hide">
                  <el-form-item size="mini" :label="'id'" prop="id">
                    <el-input v-model="firstTemp.id" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'表名'" prop="tableName">
                    <el-input v-model="firstTemp.tableName" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'命名空间'" prop="namespace">
                    <el-input v-model="firstTemp.namespace" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'模块标识'" prop="moduleCode">
                    <el-input v-model="firstTemp.moduleCode" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'模块名称'" prop="moduleName">
                    <el-input v-model="firstTemp.moduleName" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'实体类名称'" prop="className">
                    <el-input v-model="firstTemp.className" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'描述'" prop="comment">
                    <el-input v-model="firstTemp.comment" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'子表名称'" prop="detailTableName">
                    <el-input v-model="firstTemp.detailTableName" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'子表描述'" prop="detailComment">
                    <el-input v-model="firstTemp.detailComment" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'vue根目录'" prop="folder">
                    <el-input v-model="firstTemp.folder" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'其它选项'" prop="options">
                    <el-input v-model="firstTemp.options" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="12">
                  <el-form-item size="mini" :label="'分类名称'" prop="typeName">
                    <el-input v-model="firstTemp.typeName" :disabled="!editModel"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
          </el-card>
        </el-col>

        <!-- 第二部分多选 -->
        <el-col :span="!showTitleDialog ? 24 : 12" class="fh detail-card">
          <el-card shadow="nerver" class="demo-card fh" id="secondCard">
            <div slot="header">
              <i class="show-title-button" :class="showTitleDialog ? 'el-icon-d-arrow-left' : 'el-icon-d-arrow-right'"
                :title="showTitleDialog ? '展开' : '收缩'" @click="showTitleDialog=!showTitleDialog"></i>
              <span v-if="radio == ''">表字段信息（修改后，编辑框内回车生效）</span>
              <span v-else>{{tableName}}表字段信息（修改后，编辑框内回车生效）</span>
              <!-- <el-button v-if="editModel" type="primary" class="filter-item edit-button" size="mini" v-waves icon="el-icon-refresh" @click="onBtnClicked('btnUpdateDetail')">同步表结构</el-button> -->
              <el-button v-if="editModel" type="danger" class="filter-item edit-button delete-button" size="mini"
                v-waves icon="el-icon-delete" @click="onBtnClicked('btnDelDetail')">删除</el-button>
            </div>
            <el-table ref="secondTable" border :data="secondList" tooltip-effect="dark" height="calc(100% - 44px)"
              @row-click="rowClickSecondTable" @selection-change="selChangeSecondTable">
              <el-table-column width="55" type="selection" align="center" prop="custid" fixed> </el-table-column>
              <el-table-column prop="tableName" label="表名称" show-overflow-tooltip fixed></el-table-column>
              <el-table-column prop="columnName" label="列名称" show-overflow-tooltip fixed></el-table-column>
              <el-table-column prop="comment" label="列描述" show-overflow-tooltip></el-table-column>
              <el-table-column prop="columnType" label="列类型" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-input @keyup.enter.native="handleUpdateDetail(scope.row)" v-if="editModel" size="mini"
                    v-model="scope.row.columnType"></el-input>
                  <span v-else>{{scope.row.columnType}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="entityType" label="实体类型" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-input @keyup.enter.native="handleUpdateDetail(scope.row)" v-if="editModel" size="mini"
                    v-model="scope.row.entityType"></el-input>
                  <span v-else>{{scope.row.entityType}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="entityName" label="实体名称" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-input @keyup.enter.native="handleUpdateDetail(scope.row)" v-if="editModel" size="mini"
                    v-model="scope.row.entityName"></el-input>
                  <span v-else>{{scope.row.entityName}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isKey" label="主键" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isKey"
                    :active-value="true" :disabled="!editModel" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isKey ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isIncrement" label="自增" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isIncrement"
                    :active-value="true" :disabled="!editModel" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isIncrement ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isRequired" label="必填" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isRequired"
                    :active-value="true" :disabled="!editModel" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isRequired ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isInsert" label="可插入" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isInsert"
                    :active-value="true" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isInsert ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isEdit" label="可编辑" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isEdit"
                    :active-value="true" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isEdit ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isList" label="可展示" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isList"
                    :active-value="true" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isList ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="isQuery" label="可查询" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-switch @change="handleUpdateDetail(scope.row)" v-if="editModel" v-model="scope.row.isQuery"
                    :active-value="true" :inactive-value="false">
                  </el-switch>
                  <span v-else>{{scope.row.isQuery ? '是' : '否'}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="queryType" label="查询方式" width="120" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-select @change="handleUpdateDetail(scope.row)" v-if="editModel" class="filter-item"
                    style="width:100%;" size="mini" v-model="scope.row.queryType" placeholder="Please select">
                    <el-option v-for="item in queryTypes" :key="item.value" :label="item.key" :value="item.value">
                    </el-option>
                  </el-select>
                  <span v-else>{{handleType(scope.row.htmlType, 'queryTypes')}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="htmlType" label="显示类型" width="120" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-select @change="handleUpdateDetail(scope.row)" v-if="editModel" class="filter-item"
                    style="width:100%;" size="mini" v-model="scope.row.htmlType" placeholder="Please select">
                    <el-option v-for="item in typeLists" :key="item.value" :label="item.key" :value="item.value">
                    </el-option>
                  </el-select>
                  <span v-else>{{handleType(scope.row.htmlType, 'typeLists')}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="editType" label="编辑类型" width="120" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-select @change="handleUpdateDetail(scope.row)" v-if="editModel" class="filter-item"
                    style="width:100%;" size="mini" :disabled="!editModel" v-model="scope.row.editType"
                    placeholder="Please select">
                    <el-option v-for="item in typeLists" :key="item.value" :label="item.key" :value="item.value">
                    </el-option>
                  </el-select>
                  <span v-else>{{handleType(scope.row.editType, 'typeLists')}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="dataSource" label="数据源" width="120" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-select @change="handleUpdateDetail(scope.row)" v-if="editModel" class="filter-item"
                    style="width:100%;" size="mini" :disabled="!editModel" v-model="scope.row.dataSource"
                    placeholder="Please select">
                    <el-option v-for="item in sourceList" :key="item.id" :label="item.name" :value="item.id">
                    </el-option>
                  </el-select>
                  <span v-else>{{handleSource(scope.row.dataSource)}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="maxLength" label="最大长度" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-input @keyup.enter.native="handleUpdateDetail(scope.row)" v-if="editModel" size="mini"
                    v-model="scope.row.maxLength"></el-input>
                  <span v-else>{{scope.row.maxLength}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="sort" label="排序" show-overflow-tooltip>
                <template slot-scope="scope">
                  <el-input @keyup.enter.native="handleUpdateDetail(scope.row)" v-if="editModel" size="mini"
                    v-model="scope.row.sort"></el-input>
                  <span v-else>{{scope.row.sort}}</span>
                </template>
              </el-table-column>
              <el-table-column prop="updateUserName" label="修改人姓名" show-overflow-tooltip></el-table-column>
            </el-table>
            <!-- 分页 -->
            <pagination v-show="secondTotal>0" :total="secondTotal" :page.sync="secondQuery.page"
              :limit.sync="secondQuery.limit" @pagination="handleSecondPage" />
          </el-card>
        </el-col>
      </el-row>
      <el-card shadow="nerver" v-if="editModel" style="text-align: right;padding-bottom: 10px;">
        <el-row>
          <el-col :span="24">
            <el-button size="mini" @click="editModel = false">取消</el-button>
            <el-button size="mini" v-if="dialogStatus=='create'" type="primary" @click="createData">确认</el-button>
            <el-button size="mini" v-else type="primary" @click="updateData">确认</el-button>
          </el-col>
        </el-row>
      </el-card>
      <el-dialog class="dialog-mini" width="500px" v-el-drag-dialog :title="'添加'" :visible.sync="dialogFormVisible">
        <el-form ref="dataForm" :rules="mainRules" :model="firstTemp" label-position="right" label-width="120px">
          <el-form-item size="mini" :label="'表名'" prop="tableName">
            <el-input v-model="firstTemp.tableName" @change="handleChangeTableName"></el-input>
          </el-form-item>
          <el-form-item size="mini" :label="'命名空间'" prop="namespace">
            <el-input v-model="firstTemp.namespace"></el-input>
          </el-form-item>
          <el-form-item size="mini" :label="'模块标识'" prop="moduleCode">
            <el-input v-model="firstTemp.moduleCode"></el-input>
          </el-form-item>
          <el-form-item size="mini" :label="'模块名称'" prop="moduleName">
            <el-input v-model="firstTemp.moduleName"></el-input>
          </el-form-item>
          <el-form-item size="mini" :label="'实体类名称'" prop="className">
            <el-input v-model="firstTemp.className"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer">
          <el-button size="mini" @click="dialogFormVisible = false">取消</el-button>
          <el-button size="mini" type="primary" @click="createData">确认</el-button>
        </div>
      </el-dialog>
    </div>
  </div>

</template>

<script>
  import * as builderTables from '@/api/builderTables'
  import * as categorys from '@/api/categorys'
  import waves from '@/directive/waves' // 水波纹指令
  import Sticky from '@/components/Sticky'
  import permissionBtn from '@/components/PermissionBtn'
  import Pagination from '@/components/Pagination'
  import elDragDialog from '@/directive/el-dragDialog'
  import {
    parseTime
  } from '@/utils/index'
  // import SelectType from '@/components/SelectType'
  import {
    mapGetters
  } from 'vuex'
  export default {
    name: 'builderTable',
    components: {
      Sticky,
      permissionBtn,
      Pagination,
      // SelectType
    },
    directives: {
      waves,
      elDragDialog
    },
    data() {
      return {
        // ------------------------主列表数据（头）-----------------------------
        // firstHeaderList: [], // 主列表列定义
        radio: '', // 主列表选中项
        firstQuery: { // 主列表查询条件
          page: 1,
          limit: 20,
          key: undefined,
          appId: undefined
        },
        mainList: [], // 主列表值
        firstTotal: 0, // 主列表总条数
        listLoading: true, // 主列表记录总数
        tableKey: 0,
        showTitleDialog: true,

        editModel: false, // 是否为编辑模式
        editType: 'edit', // 编辑类型
        dialogStatus: '', // 主修改对话框状态create/update
        selectRow: {},
        firstTempDefaultVal: { // 头信息默认值
          id: '', // 入库通知单号
          tableName: '', // 表名
          comment: '', // 表描述、中文名称
          detailTableName: '', // 子表名称
          detailComment: '', // 子表描述、中文名称
          className: '', // 实体类名称
          namespace: 'OpenAuth.Repository.Domain', // 命名空间
          moduleCode: '', // 模块标识
          moduleName: '', // 模块名称
          folder: '', // vue根目录
          options: '', // 其它选项
          typeId: '', // 分类ID
          typeName: '', // 分类名称
        },
        dialogFormVisible: false,
        firstTemp: {}, // 当前选中的头信息
        mainRules: {
          tableName: [{
            required: true,
            message: '请输入表名',
            trigger: 'change'
          }],
          namespace: [{
            required: true
          }],
          moduleCode: [{
            required: true,
            message: '请输入模块标识',
            trigger: 'change'
          }],
          moduleName: [{
            required: true,
            message: '请输入模块名称',
            trigger: 'change'
          }]
        },
        // ------------------------明细列表数据-------------------------------------
        secondHeaderList: [], // 明细列表列定义
        secondList: [], // 明细列表值
        secondQuery: {}, // 明细列表的过滤条件，如页码、每页条数，搜索关键字等
        secondTotal: 0, // 明细列表总条数
        multipleSelection: [], // 明细列表checkbox选中的值,

        // ------------------------通用数据项-------------------------------------
        statusOptions: [{
            key: 1,
            display_name: '停用'
          },
          {
            key: 0,
            display_name: '正常'
          }
        ],
        queryTypes: [{
          key: '=',
          value: '='
        }, {
          key: '!=',
          value: '!='
        }, {
          key: '>',
          value: '>'
        }, {
          key: '<',
          value: '<'
        }, {
          key: 'between',
          value: 'between'
        }, {
          key: 'include',
          value: 'include'
        }, {
          key: 'in',
          value: 'in'
        }],
        typeLists: [{
            "key": "text",
            "value": "text"
          },
          {
            "key": "textarea",
            "value": "textarea"
          },
          {
            "key": "switch",
            "value": "switch"
          },
          // { "key": "dropList", "value": "dropList" },
          {
            "key": "select",
            "value": "select"
          },
          {
            "key": "selectList",
            "value": "selectList"
          },
          {
            "key": "date",
            "value": "date"
          },
          {
            "key": "datetime",
            "value": "datetime"
          },
          {
            "key": "checkbox",
            "value": "checkbox"
          },
          {
            "key": "mail",
            "value": "mail"
          },
          {
            "key": "number",
            "value": "number"
          },
          {
            "key": "decimal",
            "value": "decimal"
          },
          {
            "key": "phone",
            "value": "phone"
          },
          {
            "key": "img",
            "value": "img"
          },
          {
            "key": "excel",
            "value": "excel"
          },
          {
            "key": "file",
            "value": "file"
          }
        ],

        textMap: {
          update: '编辑',
          create: '添加'
        },
        excelName: `订单${parseTime(new Date())}`,
        sourceList: [] //数据源
      }
    },
    computed: {
      ...mapGetters(['defaultorgid', 'typeDataLists'])
    },
    filters: {
      filterInt(val) {
        switch (val) {
          case null:
            return ''
          case 1:
            return '状态1'
          case 2:
            return '状态2'
          default:
            return '默认状态'
        }
      },
      statusFilter(disable) {
        const statusMap = {
          false: 'color-success',
          true: 'color-danger'
        }
        return statusMap[disable]
      }
    },
    created() {
      this.getDataSource()
      this.getList()
    },
    methods: {
      // 获取数据源
      getDataSource() {
        categorys.loadType(this.typesListQuery).then(res => {
          this.sourceList = [...res.data]
        })
      },
      handleChangeTableName(val) {
        this.firstTemp.moduleCode = this.firstTemp.className = val
      },
      handleFilterStatus(val, key) {
        const status = [{
          key: false,
          display_name: '否'
        }, {
          key: true,
          display_name: '是'
        }]
        const arr = key === 'status' ? this.statusOptions : status
        return key === 'asnStatus' ? val === 0 ? '否' : '是' : arr.find(item => item.key === val).display_name
      },
      handleType(val, name) {
        const obj = this[name].find(item => item.value === val)
        return obj && obj.key
      },
      handleSource(val) {
        const obj = this.sourceList.find(item => item.id === val)
        return obj && obj.name
      },
      isEdit(key) {
        switch (key) {
          case 'updateUserName':
          case 'updateTime':
          case 'createUserName':
          case 'createTime':
            return false
          default:
            return true
        }
      },
      // ------------------------通用处理函数-------------------------------------
      onBtnClicked: function (domId) {
        console.log('you click:' + domId)
        switch (domId) {
          case 'btnAdd': // 添加新记录
            this.resetFirstTemp()
            this.secondList = []
            this.dialogStatus = 'create'
            this.dialogFormVisible = true
            this.editModel = false
            this.editType = 'add'
            this.$nextTick(() => {
              this.$refs['dataForm'].clearValidate()
            })
            break
          case 'btnEdit': // 编辑头
            this.firstTemp = Object.assign({}, this.selectRow)
            if (this.firstTemp.id === '') {
              this.editModel = false
              this.$message({
                message: '请选择要修改的项',
                type: 'error'
              })
              return
            }
            this.dialogStatus = 'update'
            this.editModel = true
            this.editType = 'edit'
            this.$nextTick(() => {
              this.$refs['dataForm'].clearValidate()
            })
            break
          case 'btnDel': // 删除主表
            if (this.firstTemp.id === '') {
              this.$message({
                message: '请选择要删除的项',
                type: 'error'
              })
              return
            }
            this.handleFirstDel(this.firstTemp)
            break
          case 'btnCreateEntity': // 创建实体
            this.handleCreateEntity()
            break
          case 'btnCreateBusiness': // 创建业务逻辑
            this.handleCreateBusiness()
            break
          case 'btnCreateVue': // 创建vue界面
            this.handleCreateVue()
            break
          case 'btnUpdateDetail': // 同步表数据结构
            this.handleUpdateDetail()
            break
          case 'btnDelDetail': // 删除明细行
            if (this.multipleSelection.length < 1) {
              this.$message({
                message: '至少删除一个',
                type: 'error'
              })
              return
            }
            this.handleSecondDel(this.multipleSelection)
            break
          default:
            break
        }
      },
      // 创建实体
      handleCreateEntity() {
        builderTables.CreateEntity({
          id: this.firstTemp.id
        }).then(() => {
          this.$message.success('创建成功，请在OpenAuthDBContext中添加相应的DbSet')
        })
      },
      // 创建业务逻辑
      handleCreateBusiness() {
        builderTables.CreateBusiness({
          id: this.firstTemp.id
        }).then(() => {
          this.$message.success('创建成功')
        })
      },
      // 创建vue界面
      handleCreateVue() {
        if(this.firstTemp.folder == undefined || this.firstTemp.folder ==""){
          this.$message.error('Vue根目录不能为空')
          return;
        }
        builderTables.CreateVue({
          id: this.firstTemp.id,
          vueProjRootPath:this.firstTemp.folder
        }).then(() => {
          this.$message.success('创建成功')
        })
      },
      // ------------------------主数据列表处理------------------------------------
      getList() {
        this.listLoading = true
        builderTables.getList(this.firstQuery).then(response => {
          response.columnHeaders.forEach((item) => { // 首字母小写
            item.key = item.key.substring(0, 1).toLowerCase() + item.key.substring(1)
          })
          // this.firstHeaderList = response.columnHeaders.filter(u => u.browsable)
          this.mainList = response.data || []
          this.firstTotal = response.count

          if (this.firstTotal > 0) {
            this.rowClickFirstTable(this.mainList[0])
          }

          this.listLoading = false
        })
      },
      rowClickFirstTable(row) { // 点击行
        this.radio = row.id
        this.tableName = row.tableName
        this.secondQuery.page = 1
        this.secondQuery.limit = 99999
        this.querySecondList(row.id)
        this.showTitleDetail(row)
      },
      handleFilter() {
        this.firstQuery.page = 1
        this.getList()
      },
      handleSizeChange(val) {
        this.firstQuery.limit = val
        this.getList()
      },
      handleCurrentChange(val) {
        this.firstQuery.page = val.page
        this.firstQuery.limit = val.limit
        this.getList()
      },
      resetFirstTemp() {
        this.firstTemp = Object.assign({}, this.firstTempDefaultVal)
      },
      createData() { // 保存提交
        this.$refs['dataForm'].validate((valid) => {
          if (valid) {
            let tempData = Object.assign({}, this.firstTemp)
            tempData = this.setDetails(tempData)
            tempData.OrgId = this.defaultorgid
            builderTables.add(tempData).then(res => {
              this.firstTemp.id = res.result
              this.mainList.unshift(this.firstTemp)
              this.dialogFormVisible = false
              this.rowClickFirstTable(this.firstTemp)
              this.$notify({
                title: '成功',
                message: '创建成功',
                type: 'success',
                duration: 2000
              })
            })
          }
        })
      },
      showTitleDetail(row) { // 弹出编辑框
        this.selectRow = Object.assign({}, row) // 新增订单时保存当前选中行
        this.firstTemp = Object.assign({}, row) // copy obj
        this.$nextTick(() => {
          this.$refs['dataForm'].clearValidate()
        })
      },
      setDetails(tempData) { // 处理明细
        tempData.wmsInboundOrderDtblReqs = []
        tempData.scheduledInboundTime = tempData.scheduledInboundTime && parseTime(tempData.scheduledInboundTime,
          '{y}-{m}-{d} {h}:{i}:{s}')
        tempData.returnBoxNum = tempData.returnBoxNum && parseInt(tempData.returnBoxNum) || 0
        return tempData
      },
      updateData() { // 更新提交
        this.$refs['dataForm'].validate((valid) => {
          if (valid) {
            let tempData = Object.assign({}, this.firstTemp)
            tempData = this.setDetails(tempData)
            builderTables.update(tempData).then(() => {
              for (const v of this.mainList) {
                if (v.id === this.firstTemp.id) {
                  const index = this.mainList.indexOf(v)
                  this.mainList.splice(index, 1, this.firstTemp)
                  break
                }
              }

              this.editModel = false
              this.querySecondList(this.firstTemp.id)
              this.$notify({
                title: '成功',
                message: '更新成功',
                type: 'success',
                duration: 2000
              })
            })
          }
        })
      },
      handleFirstDel(row) { // 删除头
        builderTables.del([row.id]).then(() => {
          this.$notify({
            title: '成功',
            message: '删除成功',
            type: 'success',
            duration: 2000
          })
          this.mainList = this.mainList.filter(item => item.id !== row.id)
          if (this.mainList.length > 0) {
            this.$nextTick(() => {
              this.rowClickFirstTable(this.mainList[0])
            })
            return
          }
          this.secondList = []
          this.showTitleDetail({})
        })
      },

      // ------------------------明细列表处理-------------------------------------
      handleSecondPage(e) {
        this.secondQuery = e
        this.querySecondList(this.radio)
      },
      querySecondList(id) {
        builderTables.getDetailList({
          'BuilderTableId': id,
          'page': this.secondQuery.page,
          'limit': this.secondQuery.limit,
          'key': this.secondQuery.customerKey
        }).then((res) => {
          res.columnHeaders.forEach((item) => { // 首字母小写
            item.key = item.key.substring(0, 1).toLowerCase() + item.key.substring(1)
          })
          this.secondHeaderList = res.columnHeaders.filter(u => u.browsable)
          this.secondHeaderListC = res.columnHeaders || []
          this.secondTotal = res.count
          this.secondList = res.data
        })
      },
      rowClickSecondTable(row) { // 行点击事件
        this.$refs.secondTable.clearSelection()
        this.$refs.secondTable.toggleRowSelection(row)
      },
      handleSecondDel(rows) { // 删除明细时,只删除前端
        builderTables.delDetail(rows.map(item => item.id)).then(() => {
          rows.forEach(row => {
            this.secondList = this.secondList.filter(item => item.id !== row.id)
          })
          this.$notify({
            title: '成功',
            message: '删除成功',
            type: 'success',
            duration: 2000
          })
        })
      },
      selChangeSecondTable(val) { // 明细选中事件
        this.multipleSelection = val
      },
      handleUpdateDetail(item) { // 同步表数据结构
        builderTables.updateDetail(item).then(() => {
          this.$notify({
            title: '成功',
            message: '更新成功',
            type: 'success',
            duration: 2000
          })
        })
      }
    }
  }
</script>
<style lang="scss">
  .nomal-form label {
    font-weight: 500 !important;
  }

  .demo-card .el-card__header {
    padding: 10px !important;
    line-height: 1;
    position: relative;
  }

  .el-card__body {
    padding: 10px 10px 0 10px !important;
    height: 100%;
  }

  .form-card .el-card__body {
    padding-right: 0 !important;
  }

  .form-card .el-form {
    padding-right: 5px;
  }

  .dialog-small .el-dialog__header {
    padding: 10px;
    border-bottom: 1px solid #efefef;
  }

  .dialog-small .el-dialog__headerbtn {
    top: 15px;
  }

  .dialog-small .el-dialog__body {
    padding: 10px;
  }

  .el-form-item__error {
    padding-top: 0;
  }
</style>

<style scoped>
  .el-form-item {
    margin-bottom: 15px !important;
  }

  .m-t-lg {
    margin-top: 20px;
  }

  .pagination-container {
    border: 0;
    padding-left: 0 !important;
  }

  .times .el-date-editor.el-input,
  .times .el-date-editor.el-input__inner {
    width: 120px;
  }

  .times .el-select {
    width: 120px;
  }

  .box-flex .label {
    width: 50px;
  }

  .m-b-sm {
    margin-bottom: 5px;
  }

  .p-l-m {
    padding-left: 10px;
  }

  .p-r-m {
    padding-right: 10px;
  }

  .edit-button {
    position: absolute !important;
    top: 2px;
    right: 80px;
  }

  .delete-button {
    right: 5px;
  }

  .show-title-button {
    cursor: pointer;
    padding: 0 10px 0 0;
  }
</style>