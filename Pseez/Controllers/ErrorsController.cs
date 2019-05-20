using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DomainClasses.Models.PseezEnt.Management;
using Pseez.DataLayer.DataContext;

namespace Pseez.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            //ExceptionLog(0);
            return View("Index");
        }
        public ActionResult NotFound()
        {
            //ExceptionLog(404);
            Response.StatusCode = 404;
            ViewBag.ErrorMessagePersian = "صفحه مورد نظر پیدا نشد.";
            //return View("NotFound");
            return View("Index");
        }

        private void ExceptionLog(int httpCode)
        {
            Log Log = new Log();
            Log.DateTime = DateTime.UtcNow;
            string controllerName = (string)RouteData.Values["controller"];
            string actionName = (string)RouteData.Values["action"];
            string StringLogMessage;
            if (httpCode != 0)
            {
                HandleErrorInfo HandleErrorInfo = new System.Web.Mvc.HandleErrorInfo(new HttpException(httpCode, ""), controllerName, actionName);
                StringLogMessage = "Controler:" + HandleErrorInfo.ControllerName +
                   "---Action:" + HandleErrorInfo.ActionName +
                   "---Exception.Message" + HandleErrorInfo.Exception.Message;
            }
            else
            {
                StringLogMessage = "Controler:" + controllerName +
                    "---Action:" + actionName +
                    "---Exception.Message" + "Error.";
            }
            Log.Message = StringLogMessage;

            PseezEntContext db = new PseezEntContext();
            db.Logs.Add(Log);
            db.SaveChanges();
        }
	}
}