using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Auth.Attribute;
using PhotoApi.ViewModel.PatientVMs;
using PhotoApi.Model;

namespace PhotoApi.Controllers
{
    
    [AuthorizeJwtWithCookie]
    [ActionDescription("病例管理")]
    [ApiController]
    [Route("api/Patient")]
	public partial class PatientController : BaseApiController
    {
        [ActionDescription("Search")]
        [HttpPost("Search")]
		public IActionResult Search(PatientSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = CreateVM<PatientListVM>();
                vm.Searcher = searcher;
                return Content(vm.GetJson());
            }
            else
            {
                return BadRequest(ModelState.GetErrorJson());
            }
        }

        [ActionDescription("Get")]
        [HttpGet("{id}")]
        public PatientVM Get(string id)
        {
            var vm = CreateVM<PatientVM>(id);
            return vm;
        }

        [ActionDescription("Create")]
        [HttpPost("Add")]
        public IActionResult Add(PatientVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }

        }

        [ActionDescription("Edit")]
        [HttpPut("Edit")]
        public IActionResult Edit(PatientVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoEdit(false);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }

		[HttpPost("BatchDelete")]
        [ActionDescription("Delete")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = CreateVM<PatientBatchVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(ids.Count());
            }
        }


        [ActionDescription("Export")]
        [HttpPost("ExportExcel")]
        public IActionResult ExportExcel(PatientSearcher searcher)
        {
            var vm = CreateVM<PatientListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("CheckExport")]
        [HttpPost("ExportExcelByIds")]
        public IActionResult ExportExcelByIds(string[] ids)
        {
            var vm = CreateVM<PatientListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }

        [ActionDescription("DownloadTemplate")]
        [HttpGet("GetExcelTemplate")]
        public IActionResult GetExcelTemplate()
        {
            var vm = CreateVM<PatientImportVM>();
            var qs = new Dictionary<string, string>();
            foreach (var item in Request.Query.Keys)
            {
                qs.Add(item, Request.Query[item]);
            }
            vm.SetParms(qs);
            var data = vm.GenerateTemplate(out string fileName);
            return File(data, "application/vnd.ms-excel", fileName);
        }

        [ActionDescription("Import")]
        [HttpPost("Import")]
        public ActionResult Import(PatientImportVM vm)
        {

            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return BadRequest(vm.GetErrorJson());
            }
            else
            {
                return Ok(vm.EntityList.Count);
            }
        }


        [HttpGet("GetCitys")]
        public ActionResult GetCitys()
        {
            return Ok(DC.Set<City>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, x => x.Name));
        }

        [HttpGet("GetHospitals")]
        public ActionResult GetHospitals()
        {
            return Ok(DC.Set<Hospital>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, x => x.Name));
        }

        [HttpGet("GetViruss")]
        public ActionResult GetViruss()
        {
            return Ok(DC.Set<Virus>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, x => x.VirusName));
        }

    }
}
