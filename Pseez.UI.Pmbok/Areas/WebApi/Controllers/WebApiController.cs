using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pseez.UI.Pmbok.Areas.WebApi.Controllers
{
    public class WebApiController : ApiController
    {
        /// <summary>
        /// ذخیره مقدار جدید 
        /// </summary>
        /// <returns></returns>
        //public IHttpActionResult Save()
        //{
        //        string JsonResult = "True1";
        //        return Ok(JsonResult);
        //}

        //public IHttpActionResult Index()
        //{
        //    string JsonResult = "True2";
        //    return Ok(JsonResult);
        //}

        public IHttpActionResult Get()
        {
            string JsonResult = "True3";
            return Ok(JsonResult);
        }
    }
}
