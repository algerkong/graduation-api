using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PhotoApi.Model;


namespace PhotoApi.ViewModel.VirusVMs
{
    public partial class VirusListVM : BasePagedListVM<Virus_View, VirusSearcher>
    {

        protected override IEnumerable<IGridColumn<Virus_View>> InitGridHeader()
        {
            return new List<GridColumn<Virus_View>>{
                this.MakeGridHeader(x => x.VirusName),
                this.MakeGridHeader(x => x.VirusCode),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeader(x => x.VirusType),
                this.MakeGridHeader(x => x.PatientName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Virus_View> GetSearchQuery()
        {
            var query = DC.Set<Virus>()
                .CheckContain(Searcher.VirusName, x=>x.VirusName)
                .CheckEqual(Searcher.VirusType, x=>x.VirusType)
                .Select(x => new Virus_View
                {
				    ID = x.ID,
                    VirusName = x.VirusName,
                    VirusCode = x.VirusCode,
                    Remark = x.Remark,
                    VirusType = x.VirusType,
                    PatientName_view = x.Patients.Select(y=>y.Patient.PatientName).ToSpratedString(null,","), 
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Virus_View : Virus{
        [Display(Name = "患者姓名")]
        public String PatientName_view { get; set; }

    }
}
