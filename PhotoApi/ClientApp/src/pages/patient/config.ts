import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "PatientName",
        label: "患者姓名"
    },
    {
        key: "IdNumber",
        label: "身份证号"
    },
    {
        key: "Gender",
        label: "性别"
    },
    {
        key: "Status",
        label: "状态"
    },
    {
        key: "Birthdy",
        label: "生日"
    },
    {
        key: "Name_view",
        label: "Location"
    },
    {
        key: "Name_view2",
        label: "Hospital"
    },
    {
        key: "PhotoId",
        label: "Photo",
        isSlot: true 
    },
    {
        key: "VirusName_view",
        label: "病毒"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const GenderTypes: Array<any> = [
  { Text: "男", Value: 0 },
  { Text: "女", Value: 1 }
];
export const StatusTypes: Array<any> = [
  { Text: "无症状", Value: 0 },
  { Text: "疑似", Value: 1 },
  { Text: "确诊", Value: 2 },
  { Text: "治愈", Value: 3 },
  { Text: "死亡", Value: 4 }
];

