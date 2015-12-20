using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class GenderController:DashboardController
    {
        [Route("dashboard/academic/genders")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Gender/Index.cshtml"));
        }
    }
}