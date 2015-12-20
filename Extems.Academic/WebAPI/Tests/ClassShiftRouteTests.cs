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

namespace Extems.Academic.Api.Tests
{
    public class ClassShiftRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/delete/{classShiftId}", "DELETE", typeof(ClassShiftController), "Delete")]
        [InlineData("/api/academic/class-shift/delete/{classShiftId}", "DELETE", typeof(ClassShiftController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/edit/{classShiftId}", "PUT", typeof(ClassShiftController), "Edit")]
        [InlineData("/api/academic/class-shift/edit/{classShiftId}", "PUT", typeof(ClassShiftController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/count-where", "POST", typeof(ClassShiftController), "CountWhere")]
        [InlineData("/api/academic/class-shift/count-where", "POST", typeof(ClassShiftController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/get-where/{pageNumber}", "POST", typeof(ClassShiftController), "GetWhere")]
        [InlineData("/api/academic/class-shift/get-where/{pageNumber}", "POST", typeof(ClassShiftController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/add-or-edit", "POST", typeof(ClassShiftController), "AddOrEdit")]
        [InlineData("/api/academic/class-shift/add-or-edit", "POST", typeof(ClassShiftController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/add/{classShift}", "POST", typeof(ClassShiftController), "Add")]
        [InlineData("/api/academic/class-shift/add/{classShift}", "POST", typeof(ClassShiftController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/bulk-import", "POST", typeof(ClassShiftController), "BulkImport")]
        [InlineData("/api/academic/class-shift/bulk-import", "POST", typeof(ClassShiftController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/meta", "GET", typeof(ClassShiftController), "GetEntityView")]
        [InlineData("/api/academic/class-shift/meta", "GET", typeof(ClassShiftController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/count", "GET", typeof(ClassShiftController), "Count")]
        [InlineData("/api/academic/class-shift/count", "GET", typeof(ClassShiftController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/all", "GET", typeof(ClassShiftController), "GetAll")]
        [InlineData("/api/academic/class-shift/all", "GET", typeof(ClassShiftController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/export", "GET", typeof(ClassShiftController), "Export")]
        [InlineData("/api/academic/class-shift/export", "GET", typeof(ClassShiftController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/1", "GET", typeof(ClassShiftController), "Get")]
        [InlineData("/api/academic/class-shift/1", "GET", typeof(ClassShiftController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/get?classShiftIds=1", "GET", typeof(ClassShiftController), "Get")]
        [InlineData("/api/academic/class-shift/get?classShiftIds=1", "GET", typeof(ClassShiftController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift", "GET", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/academic/class-shift", "GET", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/page/1", "GET", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/academic/class-shift/page/1", "GET", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/count-filtered/{filterName}", "GET", typeof(ClassShiftController), "CountFiltered")]
        [InlineData("/api/academic/class-shift/count-filtered/{filterName}", "GET", typeof(ClassShiftController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ClassShiftController), "GetFiltered")]
        [InlineData("/api/academic/class-shift/get-filtered/{pageNumber}/{filterName}", "GET", typeof(ClassShiftController), "GetFiltered")]
        [InlineData("/api/academic/class-shift/first", "GET", typeof(ClassShiftController), "GetFirst")]
        [InlineData("/api/academic/class-shift/previous/1", "GET", typeof(ClassShiftController), "GetPrevious")]
        [InlineData("/api/academic/class-shift/next/1", "GET", typeof(ClassShiftController), "GetNext")]
        [InlineData("/api/academic/class-shift/last", "GET", typeof(ClassShiftController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/class-shift/custom-fields", "GET", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/academic/class-shift/custom-fields", "GET", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/custom-fields/{resourceId}", "GET", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/academic/class-shift/custom-fields/{resourceId}", "GET", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/meta", "HEAD", typeof(ClassShiftController), "GetEntityView")]
        [InlineData("/api/academic/class-shift/meta", "HEAD", typeof(ClassShiftController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/count", "HEAD", typeof(ClassShiftController), "Count")]
        [InlineData("/api/academic/class-shift/count", "HEAD", typeof(ClassShiftController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/all", "HEAD", typeof(ClassShiftController), "GetAll")]
        [InlineData("/api/academic/class-shift/all", "HEAD", typeof(ClassShiftController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/export", "HEAD", typeof(ClassShiftController), "Export")]
        [InlineData("/api/academic/class-shift/export", "HEAD", typeof(ClassShiftController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/1", "HEAD", typeof(ClassShiftController), "Get")]
        [InlineData("/api/academic/class-shift/1", "HEAD", typeof(ClassShiftController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/get?classShiftIds=1", "HEAD", typeof(ClassShiftController), "Get")]
        [InlineData("/api/academic/class-shift/get?classShiftIds=1", "HEAD", typeof(ClassShiftController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift", "HEAD", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/academic/class-shift", "HEAD", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/page/1", "HEAD", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/academic/class-shift/page/1", "HEAD", typeof(ClassShiftController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/count-filtered/{filterName}", "HEAD", typeof(ClassShiftController), "CountFiltered")]
        [InlineData("/api/academic/class-shift/count-filtered/{filterName}", "HEAD", typeof(ClassShiftController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ClassShiftController), "GetFiltered")]
        [InlineData("/api/academic/class-shift/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(ClassShiftController), "GetFiltered")]
        [InlineData("/api/academic/class-shift/first", "HEAD", typeof(ClassShiftController), "GetFirst")]
        [InlineData("/api/academic/class-shift/previous/1", "HEAD", typeof(ClassShiftController), "GetPrevious")]
        [InlineData("/api/academic/class-shift/next/1", "HEAD", typeof(ClassShiftController), "GetNext")]
        [InlineData("/api/academic/class-shift/last", "HEAD", typeof(ClassShiftController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/class-shift/custom-fields", "HEAD", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/academic/class-shift/custom-fields", "HEAD", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/class-shift/custom-fields/{resourceId}", "HEAD", typeof(ClassShiftController), "GetCustomFields")]
        [InlineData("/api/academic/class-shift/custom-fields/{resourceId}", "HEAD", typeof(ClassShiftController), "GetCustomFields")]

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

        public ClassShiftRouteTests()
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