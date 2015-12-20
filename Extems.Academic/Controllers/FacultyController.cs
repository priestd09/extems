using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class FacultyController:DashboardController
    {
        [Route("dashboard/academic/faculties")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Faculty/Index.cshtml"));
        }
    }
}