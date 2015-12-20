using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class ClassShiftController : DashboardController
    {
        [Route("dashboard/academic/class-shifts")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("ClassShift/Index.cshtml"));
        }
    }
}