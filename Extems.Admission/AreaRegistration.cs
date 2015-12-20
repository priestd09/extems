using System.Web.Mvc;
using Frapid.Areas;

namespace Extems.Admission
{
    public class AreaRegistration: FrapidAreaRegistration
    {
        public override string AreaName => "Extems.Admission";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}