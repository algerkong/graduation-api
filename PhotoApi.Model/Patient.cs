using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace PhotoApi.Model
{
    public enum GenderEnum
    {
        [Display(Name = "男")]
        Male,
        [Display(Name = "女")]
        Female
    }

    public enum PatientStatusEnum
    {
        [Display(Name = "无症状")]
        WuZhengZhuang,
        [Display(Name = "疑似")]
        YiSi,
        [Display(Name = "确诊")]
        QueZhen,
        [Display(Name = "治愈")]
        ZhiYu,
        [Display(Name = "死亡")]
        SiWang
    }
    public class Patient : PersistPoco
    {
        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "身份证号")]
        [Required(ErrorMessage="身份证号不能为空")]
        [RegularExpression("^[1-9]\\d{7}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}$|^[1-9]\\d{5}[1-9]\\d{3}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}([0-9]|X)$", ErrorMessage = "身份证格式不正确")]
        public string IdNumber { get; set; }


        [Display(Name = "性别")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "状态")]
        public PatientStatusEnum Status { get; set; }
        [Display(Name = "生日")]
        public DateTime? Birthdy { get; set; }

        public City Location { get; set; }
        [Display(Name = "籍贯")]
        public Guid? LocationId { get; set; }

        public Hospital Hospital { get; set; }
        [Display(Name = "所属医院")]
        public Guid? HospitalId { get; set; }

        public FileAttachment Photo { get; set; } 
        [Display(Name = "照片")]
        public Guid? PhotoId { get; set; }

        [Display(Name ="病毒")]
        public List<PatientVirus> Viruses { get; set; }



        [NotMapped]
        [Display(Name = "年龄")]
        public int Age
        {
            get {
                return DateTime.Now.Year - Birthdy.Value.Year;
            }

        }

    }
}
