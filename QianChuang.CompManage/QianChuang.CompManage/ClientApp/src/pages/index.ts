/**
 * 页面集合
 */
export default {
  actionlog: {
    name: "actionlog",
    path: "/actionlog",
    controller: "WalkingTec.Mvvm.Admin.Api,ActionLog",
    icon: "el-icon-receiving"
  },
   frameworkuserbase: {
    name: "frameworkuser",
    path: "/frameworkuser",
    controller: "WalkingTec.Mvvm.Admin.Api,FrameworkUser",
    icon: "el-icon-user"
  },
  frameworkrole: {
    name: "frameworkrole",
    path: "/frameworkrole",
    controller: "WalkingTec.Mvvm.Admin.Api,FrameworkRole",
    icon: "el-icon-s-custom"
  },
 frameworkgroup: {
    name: "frameworkgroup",
    path: "/frameworkgroup",
    controller: "WalkingTec.Mvvm.Admin.Api,FrameworkGroup",
    icon: "el-icon-office-building"
  },
  frameworkmenu: {
    name: "frameworkmenu",
    path: "/frameworkmenu",
    controller: "WalkingTec.Mvvm.Admin.Api,FrameworkMenu",
    icon: "el-icon-menu"
  },
  dataprivilege: {
    name: "dataprivilege",
    path: "/dataprivilege",
    controller: "WalkingTec.Mvvm.Admin.Api,DataPrivilege",
    icon: "el-icon-odometer"
  }

, frameworkorg: {
    name: '组织管理',
    path: '/frameworkorg',
    controller: 'QianChuang.CompManage.Controllers,FrameworkOrg'
    }

, frameworkteam: {
    name: '团队管理',
    path: '/frameworkteam',
    controller: 'QianChuang.CompManage.Controllers,FrameworkTeam'
    }

, frameworklog: {
    name: '运行日志',
    path: '/frameworklog',
    controller: 'QianChuang.CompManage.Controllers,FrameworkLog'
    }

, productinfo: {
    name: '产品信息',
    path: '/productinfo',
    controller: 'QianChuang.CompManage.Controllers,ProductInfo'
    }

, productarea: {
    name: '园区管理',
    path: '/productarea',
    controller: 'QianChuang.CompManage.Controllers,ProductArea'
    }

, form: {
    name: '表单',
    path: '/form',
    controller: 'QianChuang.CompManage.Controllers,Form'
    }
/**WTM**/
 
 
 
 
 
 
 

};
