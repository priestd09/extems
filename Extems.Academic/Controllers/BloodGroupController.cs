using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frapid.Dashboard.Controllers;

namespace Extems.Academic.Controllers
{
    public class BloodGroupController : DashboardController
    {
        [Route("dashboard/academic/blood-groups")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("BloodGroup/Index.cshtml"));
        }
    }
}