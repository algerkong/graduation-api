using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace PhotoApi.Model
{
    public class Report :BasePoco
    {
        [Required(ErrorMessage="体温是必填项")]
        [Range(30,45,ErrorMessage="体温必须在30-45之间")]
        [Display(Name ="体温")]
        public float? Temprature { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
        public Patient Patient { get; set; }
        [Display(Name = "患者")]
        [Required(ErrorMessage="患者是必填项")]
        public Patient? PatientId { get; set; }
    }
}
