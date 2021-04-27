using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using PhotoApi.Model;


namespace PhotoApi.ViewModel.PatientVMs
{
    public partial class PatientSearcher : BaseSearcher
    {
        [Display(Name = "患者姓名")]
        public String PatientName { get; set; }
        [Display(Name = "身份证号")]
        public String IdNumber { get; set; }
        [Display(Name = "性别")]
        public GenderEnum? Gender { get; set; }
        [Display(Name = "病毒")]
        public List<Guid> SelectedVirusesIDs { get; set; }

        protected override void InitVM()
        {
        }

    }
}
