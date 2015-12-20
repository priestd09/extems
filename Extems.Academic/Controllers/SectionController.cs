using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class SectionController:DashboardController
    {
        [Route("dashboard/academic/sections")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Section/Index.cshtml"));
        }
    }
}