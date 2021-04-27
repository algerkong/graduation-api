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
        key: "Name",
        label: "医院名称"
    },
    {
        key: "Level",
        label: "医院级别"
    },
    {
        key: "Name_view",
        label: "医院地点"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const LevelTypes: Array<any> = [
  { Text: "三级医院", Value: 0 },
  { Text: "二级医院", Value: 1 },
  { Text: "一级医院", Value: 2 }
];

