using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class HouseController:DashboardController
    {
        [Route("dashboard/academic/houses")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("House/Index.cshtml"));
        }
    }
}