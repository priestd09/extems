using System.Web.Mvc;
using Frapid.Areas;

namespace Extems.Academic
{
    public class AreaRegistration: FrapidAreaRegistration
    {
        public override string AreaName => "Extems.Academic";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}