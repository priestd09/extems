using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class SubjectController:DashboardController
    {
        [Route("dashboard/academic/subjects")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Subject/Index.cshtml"));
        }
    }
}