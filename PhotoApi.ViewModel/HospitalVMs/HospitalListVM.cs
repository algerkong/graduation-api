using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PhotoApi.Model;


namespace PhotoApi.ViewModel.HospitalVMs
{
    public partial class HospitalListVM : BasePagedListVM<Hospital_View, HospitalSearcher>
    {

        protected override IEnumerable<IGridColumn<Hospital_View>> InitGridHeader()
        {
            return new List<GridColumn<Hospital_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Hospital_View> GetSearchQuery()
        {
            var query = DC.Set<Hospital>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.Level, x=>x.Level)
                .CheckEqual(Searcher.LocationId, x=>x.LocationId)
                .Select(x => new Hospital_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Level = x.Level,
                    Name_view = x.Location.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Hospital_View : Hospital{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
