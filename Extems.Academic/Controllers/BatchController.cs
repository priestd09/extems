using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class BatchController:DashboardController
    {
        [Route("dashboard/academic/batches")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Batch/Index.cshtml"));
        }
    }
}