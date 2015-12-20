using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Admission.Controllers
{
    public class ApplicationController : DashboardController
    {
        [Route("dashboard/admission/applications")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Application/Index.cshtml"));
        }
    }
}