using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class CourseController:DashboardController
    {
        [Route("dashboard/academic/courses")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Course/Index.cshtml"));
        }
    }
}