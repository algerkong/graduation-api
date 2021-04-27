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

, patient: {
    name: '病例管理',
    path: '/patient',
    controller: 'PhotoApi.Controllers,Patient'
    }

, virus: {
    name: '病毒管理',
    path: '/virus',
    controller: 'PhotoApi.Controllers,Virus'
    }

, city: {
    name: '城市管理',
    path: '/city',
    controller: 'PhotoApi.Controllers,City'
    }

, hospital: {
    name: '医院管理',
    path: '/hospital',
    controller: 'PhotoApi.Controllers,Hospital'
    }
/**WTM**/
 
 
 
 

};
