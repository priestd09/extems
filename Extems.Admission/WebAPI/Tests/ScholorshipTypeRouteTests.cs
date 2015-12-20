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
    public class ScholorshipTypeRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/delete/{scholorshipTypeId}", "DELETE", typeof(ScholorshipTypeController), "Delete")]
        [InlineData("/api/admission/scholorship-type/delete/{scholorshipTypeId}", "DELETE", typeof(ScholorshipTypeController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/edit/{scholorshipTypeId}", "PUT", typeof(ScholorshipTypeController), "Edit")]
        [InlineData("/api/admission/scholorship-type/edit/{scholorshipTypeId}", "PUT", typeof(ScholorshipTypeController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/count-where", "POST", typeof(ScholorshipTypeController), "CountWhere")]
        [InlineData("/api/admission/scholorship-type/count-where", "POST", typeof(ScholorshipTypeController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/get-where/{pageNumber}", "POST", typeof(ScholorshipTypeController), "GetWhere")]
        [InlineData("/api/admission/scholorship-type/get-where/{pageNumber}", "POST", typeof(ScholorshipTypeController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/add-or-edit", "POST", typeof(ScholorshipTypeController), "AddOrEdit")]
        [InlineData("/api/admission/scholorship-type/add-or-edit", "POST", typeof(ScholorshipTypeController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/add/{scholorshipType}", "POST", typeof(ScholorshipTypeController), "Add")]
        [InlineData("/api/admission/scholorship-type/add/{scholorshipType}", "POST", typeof(ScholorshipTypeController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/bulk-import", "POST", typeof(ScholorshipTypeController), "BulkImport")]
        [InlineData("/api/admission/scholorship-type/bulk-import", "POST", typeof(ScholorshipTypeController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/meta", "GET", typeof(ScholorshipTypeController), "GetEntityView")]
        [InlineData("/api/admission/scholorship-type/meta", "GET", typeof(ScholorshipTypeController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/count", "GET", typeof(ScholorshipTypeController), "Count")]
        [InlineData("/api/admission/scholorship-type/count", "GET", typeof(ScholorshipTypeController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/all", "GET", typeof(ScholorshipTypeController), "GetAll")]
        [InlineData("/api/admission/scholorship-type/all", "GET", typeof(ScholorshipTypeController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/export", "GET", typeof(ScholorshipTypeController), "Export")]
        [InlineData("/api/admission/scholorship-type/export", "GET", typeof(ScholorshipTypeController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/1", "GET", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/admission/scholorship-type/1", "GET", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/get?scholorshipTypeIds=1", "GET", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/admission/scholorship-type/get?scholorshipTypeIds=1", "GET", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type", "GET", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type", "GET", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/page/1", "GET", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type/page/1", "GET", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/count-filtered/{filterName}", "GET", typeof(ScholorshipTypeController), "CountFiltered")]
        [InlineData("/api/admission/scholorship-type/count-filtered/{filterName}", "GET", typeof(ScholorshipTypeController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipTypeController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipTypeController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type/first", "GET", typeof(ScholorshipTypeController), "GetFirst")]
        [InlineData("/api/admission/scholorship-type/previous/1", "GET", typeof(ScholorshipTypeController), "GetPrevious")]
        [InlineData("/api/admission/scholorship-type/next/1", "GET", typeof(ScholorshipTypeController), "GetNext")]
        [InlineData("/api/admission/scholorship-type/last", "GET", typeof(ScholorshipTypeController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/custom-fields", "GET", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type/custom-fields", "GET", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/custom-fields/{resourceId}", "GET", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type/custom-fields/{resourceId}", "GET", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/meta", "HEAD", typeof(ScholorshipTypeController), "GetEntityView")]
        [InlineData("/api/admission/scholorship-type/meta", "HEAD", typeof(ScholorshipTypeController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/count", "HEAD", typeof(ScholorshipTypeController), "Count")]
        [InlineData("/api/admission/scholorship-type/count", "HEAD", typeof(ScholorshipTypeController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/all", "HEAD", typeof(ScholorshipTypeController), "GetAll")]
        [InlineData("/api/admission/scholorship-type/all", "HEAD", typeof(ScholorshipTypeController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/export", "HEAD", typeof(ScholorshipTypeController), "Export")]
        [InlineData("/api/admission/scholorship-type/export", "HEAD", typeof(ScholorshipTypeController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/1", "HEAD", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/admission/scholorship-type/1", "HEAD", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/get?scholorshipTypeIds=1", "HEAD", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/admission/scholorship-type/get?scholorshipTypeIds=1", "HEAD", typeof(ScholorshipTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type", "HEAD", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type", "HEAD", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/page/1", "HEAD", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type/page/1", "HEAD", typeof(ScholorshipTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/count-filtered/{filterName}", "HEAD", typeof(ScholorshipTypeController), "CountFiltered")]
        [InlineData("/api/admission/scholorship-type/count-filtered/{filterName}", "HEAD", typeof(ScholorshipTypeController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipTypeController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipTypeController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type/first", "HEAD", typeof(ScholorshipTypeController), "GetFirst")]
        [InlineData("/api/admission/scholorship-type/previous/1", "HEAD", typeof(ScholorshipTypeController), "GetPrevious")]
        [InlineData("/api/admission/scholorship-type/next/1", "HEAD", typeof(ScholorshipTypeController), "GetNext")]
        [InlineData("/api/admission/scholorship-type/last", "HEAD", typeof(ScholorshipTypeController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/custom-fields", "HEAD", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type/custom-fields", "HEAD", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipTypeController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipTypeController), "GetCustomFields")]

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

        public ScholorshipTypeRouteTests()
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