<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions" ></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import { GenderTypes,StatusTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getCity;
    @State
    getCityData;
    @Action
    getHospital;
    @State
    getHospitalData;
    @Action
    getVirus;
    @State
    getVirusData;

    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
             "Entity.PatientName":{
                 label: "患者姓名",
                 rules: [],
                    type: "input"
            },
             "Entity.IdNumber":{
                 label: "身份证号",
                 rules: [{ required: true, message: "身份证号"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Gender":{
                 label: "性别",
                 rules: [],
                    type: "select",
                    children: GenderTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Status":{
                 label: "状态",
                 rules: [{ required: true, message: "状态"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: StatusTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Birthdy":{
                 label: "生日",
                 rules: [],
                    type: "datePicker"
            },
             "Entity.LocationId":{
                 label: "Location",
                 rules: [],
                    type: "select",
                    children: this.getCityData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.HospitalId":{
                 label: "Hospital",
                 rules: [],
                    type: "select",
                    children: this.getHospitalData,
                    props: {
                        clearable: true
                    }
            },
             "Entity.PhotoId":{
                 label: "Photo",
                 rules: [],
                type: "wtmUploadImg",
                    props: {
                        isHead: true,
                        imageStyle: { width: "100px", height: "100px" }
                    }

            },
             "Entity.Viruses":{
                 label: "病毒",
                 rules: [],
                    type: "transfer",
                    mapKey: "VirusId",
                    props: {
                        data: this.getVirusData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: [this.$t("form.all"), this.$t("form.selected")],
                        filterable: true,
                        filterMethod: filterMethod
                    },
                    span: 24,
                    defaultValue: []
            }
                
            }
        };
    }
    beforeOpen() {
        this.getCity();
        this.getHospital();
        this.getVirus();

    }
}
</script>
