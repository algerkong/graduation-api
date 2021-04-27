using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace PhotoApi.Model
{

    public enum HospitalLevel
    {
        [Display(Name = "三级医院")]
        Class3,
        [Display(Name = "二级医院")]
        Class2,
        [Display(Name = "一级医院")]
        Class1
    }
    public class Hospital : TopBasePoco
    {
        [Display(Name="医院名称")]
        [Required(ErrorMessage = "医院名称不能为空,")]
        public string Name { get; set; }

        [Display(Name = "医院级别")]
        [Required(ErrorMessage = "医院级别不能为空,")]
        public HospitalLevel? Level { get; set; }

        [Display(Name = "医院地点")]
        public City Location { get; set; }

        [Display(Name = "医院地点")]
        [Required(ErrorMessage = "医院地点不能为空,")]
        public Guid LocationId { get; set; }


    }
}
