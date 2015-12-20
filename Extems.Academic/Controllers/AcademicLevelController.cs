using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class AcademicLevelController : DashboardController
    {
        [Route("dashboard/academic/academic-levels")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("AcademicLevel/Index.cshtml"));
        }
    }
}