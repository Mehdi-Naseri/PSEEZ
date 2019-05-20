using System.Collections.Generic;
using System.Web.Mvc;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;

namespace Pseez.UI.HumanResource.Areas.PersonnelReports.Controllers
{
    public class EmployeeDetailController : Controller
    {
        private readonly IEmployeeDetailService _employeeDetailService;

        public EmployeeDetailController(IEmployeeDetailService employeeDetailService)
        {
            _employeeDetailService = employeeDetailService;
        }

        //
        // GET: /PersonnelReports/Employee/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read(bool boolShowAllEmployee, int numberofReturnedEmployee = 0)
        {
            //StsContext db = new StsContext();
            //جهت غیر فعال کردن لود فرزندان و در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = GenerateEmployeeList(boolShowAllEmployee);
            IEnumerable<EmployeesDetailViewModel> result;
            if (boolShowAllEmployee)
            {
                result = _employeeDetailService.GetAll();
            }
            else
            {
                result = _employeeDetailService.GetFew(numberofReturnedEmployee);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //    if (Persons != null)
        //    IEnumerable<EmployeesDetailViewModel> Persons = _employeeDetailService.GetAll();
        //{

        //public ActionResult ExportCSV()
        //    {
        //        System.Text.StringBuilder StringBuilder1 = new System.Text.StringBuilder(null);
        //        //StringBuilder1.AppendLine("نام ، نام خانوادگی ، نام پدر ، ");
        //        foreach (EmployeesDetailViewModel EmplyeesDetailsViewModel1 in Persons)
        //        {
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Name + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Family + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.FatherName + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.BirthDate + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.City + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Province + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Shenasnameh + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.NationalCode + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Gender + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Mobile + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.PersoneliCode + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.EmploymentDate + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Religion + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.Email + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.BloodType + ',');
        //            StringBuilder1.Append(EmplyeesDetailsViewModel1.MartialStatus + ',');
        //            StringBuilder1.AppendLine(EmplyeesDetailsViewModel1.MartialDate);
        //        }

        //        return File(new System.Text.UTF8Encoding().GetBytes(StringBuilder1.ToString()), "text/csv", "Test.csv");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "موردی برای نمایش یافت نشد.");
        //        return Content("موردی برای نمایش یافت نشد.");
        //    }
        //}

        //public void ExportExcel()
        //{
        //    IEnumerable<EmployeesDetailViewModel> Persons = _employeeDetailService.GetAll();
        //    if (Persons != null)
        //    {
        //        System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView();
        //        GridView1.DataSource = Persons.ToList();
        //        GridView1.DataBind();

        //        Response.ClearContent();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment; filename=Employees.xls");
        //        Response.ContentType = "application/ms-excel";
        //        Response.Charset = "";
        //        System.IO.StringWriter StringWriter1 = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter HtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(StringWriter1);
        //        GridView1.RenderControl(HtmlTextWriter1);
        //        //string style1 = @"<style> .textmode {mso-number-format:General}</style>";
        //        string style = @"<style> TD {mso-number-format:\@;}</style>";
        //        Response.Output.Write(style);
        //        Response.Output.Write(StringWriter1.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "موردی برای نمایش یافت نشد.");
        //        //return Content("There is no item to display.");
        //    }
        //}
    }
}