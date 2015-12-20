// ReSharper disable All
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Xunit;

namespace Extems.Admission.Api.Tests
{
    public class ScholorshipRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/delete/{scholorshipId}", "DELETE", typeof(ScholorshipController), "Delete")]
        [InlineData("/api/admission/scholorship/delete/{scholorshipId}", "DELETE", typeof(ScholorshipController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/edit/{scholorshipId}", "PUT", typeof(ScholorshipController), "Edit")]
        [InlineData("/api/admission/scholorship/edit/{scholorshipId}", "PUT", typeof(ScholorshipController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/verify/{scholorshipId}/{verificationStatusId}/{reason}", "PUT", typeof(ScholorshipController), "Verifiy")]
        [InlineData("/api/admission/scholorship/verify/{scholorshipId}/{verificationStatusId}/{reason}", "PUT", typeof(ScholorshipController), "Verifiy")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship/count-where", "POST", typeof(ScholorshipController), "CountWhere")]
        [InlineData("/api/admission/scholorship/count-where", "POST", typeof(ScholorshipController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/get-where/{pageNumber}", "POST", typeof(ScholorshipController), "GetWhere")]
        [InlineData("/api/admission/scholorship/get-where/{pageNumber}", "POST", typeof(ScholorshipController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/add-or-edit", "POST", typeof(ScholorshipController), "AddOrEdit")]
        [InlineData("/api/admission/scholorship/add-or-edit", "POST", typeof(ScholorshipController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/add/{scholorship}", "POST", typeof(ScholorshipController), "Add")]
        [InlineData("/api/admission/scholorship/add/{scholorship}", "POST", typeof(ScholorshipController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/bulk-import", "POST", typeof(ScholorshipController), "BulkImport")]
        [InlineData("/api/admission/scholorship/bulk-import", "POST", typeof(ScholorshipController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/meta", "GET", typeof(ScholorshipController), "GetEntityView")]
        [InlineData("/api/admission/scholorship/meta", "GET", typeof(ScholorshipController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/count", "GET", typeof(ScholorshipController), "Count")]
        [InlineData("/api/admission/scholorship/count", "GET", typeof(ScholorshipController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/all", "GET", typeof(ScholorshipController), "GetAll")]
        [InlineData("/api/admission/scholorship/all", "GET", typeof(ScholorshipController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/export", "GET", typeof(ScholorshipController), "Export")]
        [InlineData("/api/admission/scholorship/export", "GET", typeof(ScholorshipController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/1", "GET", typeof(ScholorshipController), "Get")]
        [InlineData("/api/admission/scholorship/1", "GET", typeof(ScholorshipController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/get?scholorshipIds=1", "GET", typeof(ScholorshipController), "Get")]
        [InlineData("/api/admission/scholorship/get?scholorshipIds=1", "GET", typeof(ScholorshipController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship", "GET", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship", "GET", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/page/1", "GET", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship/page/1", "GET", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/count-filtered/{filterName}", "GET", typeof(ScholorshipController), "CountFiltered")]
        [InlineData("/api/admission/scholorship/count-filtered/{filterName}", "GET", typeof(ScholorshipController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipController), "GetFiltered")]
        [InlineData("/api/admission/scholorship/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipController), "GetFiltered")]
        [InlineData("/api/admission/scholorship/first", "GET", typeof(ScholorshipController), "GetFirst")]
        [InlineData("/api/admission/scholorship/previous/1", "GET", typeof(ScholorshipController), "GetPrevious")]
        [InlineData("/api/admission/scholorship/next/1", "GET", typeof(ScholorshipController), "GetNext")]
        [InlineData("/api/admission/scholorship/last", "GET", typeof(ScholorshipController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship/custom-fields", "GET", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship/custom-fields", "GET", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/custom-fields/{resourceId}", "GET", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship/custom-fields/{resourceId}", "GET", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/meta", "HEAD", typeof(ScholorshipController), "GetEntityView")]
        [InlineData("/api/admission/scholorship/meta", "HEAD", typeof(ScholorshipController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/count", "HEAD", typeof(ScholorshipController), "Count")]
        [InlineData("/api/admission/scholorship/count", "HEAD", typeof(ScholorshipController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/all", "HEAD", typeof(ScholorshipController), "GetAll")]
        [InlineData("/api/admission/scholorship/all", "HEAD", typeof(ScholorshipController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/export", "HEAD", typeof(ScholorshipController), "Export")]
        [InlineData("/api/admission/scholorship/export", "HEAD", typeof(ScholorshipController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/1", "HEAD", typeof(ScholorshipController), "Get")]
        [InlineData("/api/admission/scholorship/1", "HEAD", typeof(ScholorshipController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/get?scholorshipIds=1", "HEAD", typeof(ScholorshipController), "Get")]
        [InlineData("/api/admission/scholorship/get?scholorshipIds=1", "HEAD", typeof(ScholorshipController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship", "HEAD", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship", "HEAD", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/page/1", "HEAD", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship/page/1", "HEAD", typeof(ScholorshipController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/count-filtered/{filterName}", "HEAD", typeof(ScholorshipController), "CountFiltered")]
        [InlineData("/api/admission/scholorship/count-filtered/{filterName}", "HEAD", typeof(ScholorshipController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipController), "GetFiltered")]
        [InlineData("/api/admission/scholorship/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipController), "GetFiltered")]
        [InlineData("/api/admission/scholorship/first", "HEAD", typeof(ScholorshipController), "GetFirst")]
        [InlineData("/api/admission/scholorship/previous/1", "HEAD", typeof(ScholorshipController), "GetPrevious")]
        [InlineData("/api/admission/scholorship/next/1", "HEAD", typeof(ScholorshipController), "GetNext")]
        [InlineData("/api/admission/scholorship/last", "HEAD", typeof(ScholorshipController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship/custom-fields", "HEAD", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship/custom-fields", "HEAD", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipController), "GetCustomFields")]

        [Conditional("Debug")]
        public void TestRoute(string url, string verb, Type type, string actionName)
        {
            //Arrange
            url = url.Replace("{apiVersionNumber}", this.ApiVersionNumber);
            url = Host + url;

            //Act
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(verb), url);

            IHttpControllerSelector controller = this.GetControllerSelector();
            IHttpActionSelector action = this.GetActionSelector();

            IHttpRouteData route = this.Config.Routes.GetRouteData(request);
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = this.Config;

            HttpControllerDescriptor controllerDescriptor = controller.SelectController(request);

            HttpControllerContext context = new HttpControllerContext(this.Config, route, request)
            {
                ControllerDescriptor = controllerDescriptor
            };

            var actionDescriptor = action.SelectAction(context);

            //Assert
            Assert.NotNull(controllerDescriptor);
            Assert.NotNull(actionDescriptor);
            Assert.Equal(type, controllerDescriptor.ControllerType);
            Assert.Equal(actionName, actionDescriptor.ActionName);
        }

        #region Fixture
        private readonly HttpConfiguration Config;
        private readonly string Host;
        private readonly string ApiVersionNumber;

        public ScholorshipRouteTests()
        {
            this.Host = ConfigurationManager.AppSettings["HostPrefix"];
            this.ApiVersionNumber = ConfigurationManager.AppSettings["ApiVersionNumber"];
            this.Config = GetConfig();
        }

        private HttpConfiguration GetConfig()
        {
            if (MemoryCache.Default["Config"] == null)
            {
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute("VersionedApi", "api/" + this.ApiVersionNumber + "/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
                config.Routes.MapHttpRoute("DefaultApi", "api/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

                config.EnsureInitialized();
                MemoryCache.Default["Config"] = config;
                return config;
            }

            return MemoryCache.Default["Config"] as HttpConfiguration;
        }

        private IHttpControllerSelector GetControllerSelector()
        {
            if (MemoryCache.Default["ControllerSelector"] == null)
            {
                IHttpControllerSelector selector = this.Config.Services.GetHttpControllerSelector();
                return selector;
            }

            return MemoryCache.Default["ControllerSelector"] as IHttpControllerSelector;
        }

        private IHttpActionSelector GetActionSelector()
        {
            if (MemoryCache.Default["ActionSelector"] == null)
            {
                IHttpActionSelector selector = this.Config.Services.GetActionSelector();
                return selector;
            }

            return MemoryCache.Default["ActionSelector"] as IHttpActionSelector;
        }
        #endregion
    }
}