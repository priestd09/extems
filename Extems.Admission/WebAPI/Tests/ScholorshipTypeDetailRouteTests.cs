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
    public class ScholorshipTypeDetailRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/delete/{scholorshipTypeDetailId}", "DELETE", typeof(ScholorshipTypeDetailController), "Delete")]
        [InlineData("/api/admission/scholorship-type-detail/delete/{scholorshipTypeDetailId}", "DELETE", typeof(ScholorshipTypeDetailController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/edit/{scholorshipTypeDetailId}", "PUT", typeof(ScholorshipTypeDetailController), "Edit")]
        [InlineData("/api/admission/scholorship-type-detail/edit/{scholorshipTypeDetailId}", "PUT", typeof(ScholorshipTypeDetailController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/count-where", "POST", typeof(ScholorshipTypeDetailController), "CountWhere")]
        [InlineData("/api/admission/scholorship-type-detail/count-where", "POST", typeof(ScholorshipTypeDetailController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/get-where/{pageNumber}", "POST", typeof(ScholorshipTypeDetailController), "GetWhere")]
        [InlineData("/api/admission/scholorship-type-detail/get-where/{pageNumber}", "POST", typeof(ScholorshipTypeDetailController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/add-or-edit", "POST", typeof(ScholorshipTypeDetailController), "AddOrEdit")]
        [InlineData("/api/admission/scholorship-type-detail/add-or-edit", "POST", typeof(ScholorshipTypeDetailController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/add/{scholorshipTypeDetail}", "POST", typeof(ScholorshipTypeDetailController), "Add")]
        [InlineData("/api/admission/scholorship-type-detail/add/{scholorshipTypeDetail}", "POST", typeof(ScholorshipTypeDetailController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/bulk-import", "POST", typeof(ScholorshipTypeDetailController), "BulkImport")]
        [InlineData("/api/admission/scholorship-type-detail/bulk-import", "POST", typeof(ScholorshipTypeDetailController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/meta", "GET", typeof(ScholorshipTypeDetailController), "GetEntityView")]
        [InlineData("/api/admission/scholorship-type-detail/meta", "GET", typeof(ScholorshipTypeDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/count", "GET", typeof(ScholorshipTypeDetailController), "Count")]
        [InlineData("/api/admission/scholorship-type-detail/count", "GET", typeof(ScholorshipTypeDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/all", "GET", typeof(ScholorshipTypeDetailController), "GetAll")]
        [InlineData("/api/admission/scholorship-type-detail/all", "GET", typeof(ScholorshipTypeDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/export", "GET", typeof(ScholorshipTypeDetailController), "Export")]
        [InlineData("/api/admission/scholorship-type-detail/export", "GET", typeof(ScholorshipTypeDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/1", "GET", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/admission/scholorship-type-detail/1", "GET", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/get?scholorshipTypeDetailIds=1", "GET", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/admission/scholorship-type-detail/get?scholorshipTypeDetailIds=1", "GET", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail", "GET", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type-detail", "GET", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/page/1", "GET", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type-detail/page/1", "GET", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/count-filtered/{filterName}", "GET", typeof(ScholorshipTypeDetailController), "CountFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/count-filtered/{filterName}", "GET", typeof(ScholorshipTypeDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipTypeDetailController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ScholorshipTypeDetailController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/first", "GET", typeof(ScholorshipTypeDetailController), "GetFirst")]
        [InlineData("/api/admission/scholorship-type-detail/previous/1", "GET", typeof(ScholorshipTypeDetailController), "GetPrevious")]
        [InlineData("/api/admission/scholorship-type-detail/next/1", "GET", typeof(ScholorshipTypeDetailController), "GetNext")]
        [InlineData("/api/admission/scholorship-type-detail/last", "GET", typeof(ScholorshipTypeDetailController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/custom-fields", "GET", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type-detail/custom-fields", "GET", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/custom-fields/{resourceId}", "GET", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type-detail/custom-fields/{resourceId}", "GET", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/meta", "HEAD", typeof(ScholorshipTypeDetailController), "GetEntityView")]
        [InlineData("/api/admission/scholorship-type-detail/meta", "HEAD", typeof(ScholorshipTypeDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/count", "HEAD", typeof(ScholorshipTypeDetailController), "Count")]
        [InlineData("/api/admission/scholorship-type-detail/count", "HEAD", typeof(ScholorshipTypeDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/all", "HEAD", typeof(ScholorshipTypeDetailController), "GetAll")]
        [InlineData("/api/admission/scholorship-type-detail/all", "HEAD", typeof(ScholorshipTypeDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/export", "HEAD", typeof(ScholorshipTypeDetailController), "Export")]
        [InlineData("/api/admission/scholorship-type-detail/export", "HEAD", typeof(ScholorshipTypeDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/1", "HEAD", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/admission/scholorship-type-detail/1", "HEAD", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/get?scholorshipTypeDetailIds=1", "HEAD", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/admission/scholorship-type-detail/get?scholorshipTypeDetailIds=1", "HEAD", typeof(ScholorshipTypeDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail", "HEAD", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type-detail", "HEAD", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/page/1", "HEAD", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/admission/scholorship-type-detail/page/1", "HEAD", typeof(ScholorshipTypeDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/count-filtered/{filterName}", "HEAD", typeof(ScholorshipTypeDetailController), "CountFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/count-filtered/{filterName}", "HEAD", typeof(ScholorshipTypeDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipTypeDetailController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ScholorshipTypeDetailController), "GetFiltered")]
        [InlineData("/api/admission/scholorship-type-detail/first", "HEAD", typeof(ScholorshipTypeDetailController), "GetFirst")]
        [InlineData("/api/admission/scholorship-type-detail/previous/1", "HEAD", typeof(ScholorshipTypeDetailController), "GetPrevious")]
        [InlineData("/api/admission/scholorship-type-detail/next/1", "HEAD", typeof(ScholorshipTypeDetailController), "GetNext")]
        [InlineData("/api/admission/scholorship-type-detail/last", "HEAD", typeof(ScholorshipTypeDetailController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/custom-fields", "HEAD", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type-detail/custom-fields", "HEAD", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/scholorship-type-detail/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipTypeDetailController), "GetCustomFields")]
        [InlineData("/api/admission/scholorship-type-detail/custom-fields/{resourceId}", "HEAD", typeof(ScholorshipTypeDetailController), "GetCustomFields")]

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

        public ScholorshipTypeDetailRouteTests()
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