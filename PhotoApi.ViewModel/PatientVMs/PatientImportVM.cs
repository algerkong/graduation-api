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
    public partial class PatientTemplateVM : BaseTemplateVM
    {
        [Display(Name = "患者姓名")]
        public ExcelPropety PatientName_Excel = ExcelPropety.CreateProperty<Patient>(x => x.PatientName);
        [Display(Name = "身份证号")]
        public ExcelPropety IdNumber_Excel = ExcelPropety.CreateProperty<Patient>(x => x.IdNumber);
        [Display(Name = "性别")]
        public ExcelPropety Gender_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Gender);
        [Display(Name = "状态")]
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Status);
        [Display(Name = "生日")]
        public ExcelPropety Birthdy_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Birthdy);
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<Patient>(x => x.LocationId);
        public ExcelPropety Hospital_Excel = ExcelPropety.CreateProperty<Patient>(x => x.HospitalId);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
            Hospital_Excel.DataType = ColumnDataType.ComboBox;
            Hospital_Excel.ListItems = DC.Set<Hospital>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
        }

    }

    public class PatientImportVM : BaseImportVM<PatientTemplateVM, Patient>
    {

    }

}
