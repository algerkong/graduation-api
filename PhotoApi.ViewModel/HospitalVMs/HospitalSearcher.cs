using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using PhotoApi.Model;


namespace PhotoApi.ViewModel.HospitalVMs
{
    public partial class HospitalSearcher : BaseSearcher
    {
        [Display(Name = "医院名称")]
        public String Name { get; set; }
        [Display(Name = "医院级别")]
        public HospitalLevel? Level { get; set; }
        [Display(Name = "医院地点")]
        public Guid? LocationId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
