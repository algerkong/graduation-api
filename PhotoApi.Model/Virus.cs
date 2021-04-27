using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace PhotoApi.Model
{
    public enum VirusTypeEnum
    {
        DNA,
        RNA
    }

    public class Virus:TopBasePoco
    {
        [Display(Name="病毒名称")]
        [Required(ErrorMessage="病毒名称不能为空")]
        public string VirusName { get; set; }
        [Display(Name = "病毒代码")]
        [Required(ErrorMessage = "病毒代码不能为空")]
        public string VirusCode { get; set; }
        [Display(Name = "病毒描述")]
        public string Remark { get; set; }
        [Display(Name = "病毒种类")]
        [Required(ErrorMessage = "病毒种类不能为空")]
        public VirusTypeEnum? VirusType { get; set; }

        [Display(Name ="患者")]
        public List<PatientVirus> Patients { get; set; }
    }
}
