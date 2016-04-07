using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ConfigCenter.Business;
using ConfigCenter.Dto;
using Webdiyer.WebControls.Mvc;

namespace ConfigCenter.Admin.Controllers
{
    public class AppSettingController : Controller
    {
        // GET: App
        public ActionResult Index(int pageindex = 1, int appId = 0, string kword = "")
        {
            long totalItem;
            var dto = AppSettingBusiness.GetAppSettings(appId, pageindex, 1, kword, out totalItem);
            return View(new PagedList<AppSettingDto>(dto, pageindex, 1, (int)totalItem));
        }

        public JsonResult GetAppSettingById(int id)
        {
            return Json(AppSettingBusiness.GetAppSettingById(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAppSettingById(int id)
        {
            ResponseResult responseResult;
            try
            {
                var result = AppSettingBusiness.DeleteAppSettingById(id);
                responseResult = new ResponseResult(result, "");
            }
            catch (Exception)
            {
                responseResult = new ResponseResult(false, "");
            }
            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveAppSetting(AppSettingDto appSettingDto)
        {
            ResponseResult responseResult;
            try
            {
                AppSettingBusiness.SaveAppSetting(appSettingDto);
                responseResult = new ResponseResult(true, "");
            }
            catch (Exception)
            {
                responseResult = new ResponseResult(false, "");
            }
            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }
    }
}
