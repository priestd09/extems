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
    public class CourseRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/course/delete/{courseId}", "DELETE", typeof(CourseController), "Delete")]
        [InlineData("/api/academic/course/delete/{courseId}", "DELETE", typeof(CourseController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/course/edit/{courseId}", "PUT", typeof(CourseController), "Edit")]
        [InlineData("/api/academic/course/edit/{courseId}", "PUT", typeof(CourseController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/course/count-where", "POST", typeof(CourseController), "CountWhere")]
        [InlineData("/api/academic/course/count-where", "POST", typeof(CourseController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/course/get-where/{pageNumber}", "POST", typeof(CourseController), "GetWhere")]
        [InlineData("/api/academic/course/get-where/{pageNumber}", "POST", typeof(CourseController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/course/add-or-edit", "POST", typeof(CourseController), "AddOrEdit")]
        [InlineData("/api/academic/course/add-or-edit", "POST", typeof(CourseController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/course/add/{course}", "POST", typeof(CourseController), "Add")]
        [InlineData("/api/academic/course/add/{course}", "POST", typeof(CourseController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/course/bulk-import", "POST", typeof(CourseController), "BulkImport")]
        [InlineData("/api/academic/course/bulk-import", "POST", typeof(CourseController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/course/meta", "GET", typeof(CourseController), "GetEntityView")]
        [InlineData("/api/academic/course/meta", "GET", typeof(CourseController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/course/count", "GET", typeof(CourseController), "Count")]
        [InlineData("/api/academic/course/count", "GET", typeof(CourseController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/course/all", "GET", typeof(CourseController), "GetAll")]
        [InlineData("/api/academic/course/all", "GET", typeof(CourseController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/course/export", "GET", typeof(CourseController), "Export")]
        [InlineData("/api/academic/course/export", "GET", typeof(CourseController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/course/1", "GET", typeof(CourseController), "Get")]
        [InlineData("/api/academic/course/1", "GET", typeof(CourseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/course/get?courseIds=1", "GET", typeof(CourseController), "Get")]
        [InlineData("/api/academic/course/get?courseIds=1", "GET", typeof(CourseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/course", "GET", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/academic/course", "GET", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/course/page/1", "GET", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/academic/course/page/1", "GET", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/course/count-filtered/{filterName}", "GET", typeof(CourseController), "CountFiltered")]
        [InlineData("/api/academic/course/count-filtered/{filterName}", "GET", typeof(CourseController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/course/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CourseController), "GetFiltered")]
        [InlineData("/api/academic/course/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CourseController), "GetFiltered")]
        [InlineData("/api/academic/course/first", "GET", typeof(CourseController), "GetFirst")]
        [InlineData("/api/academic/course/previous/1", "GET", typeof(CourseController), "GetPrevious")]
        [InlineData("/api/academic/course/next/1", "GET", typeof(CourseController), "GetNext")]
        [InlineData("/api/academic/course/last", "GET", typeof(CourseController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/course/custom-fields", "GET", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/academic/course/custom-fields", "GET", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/course/custom-fields/{resourceId}", "GET", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/academic/course/custom-fields/{resourceId}", "GET", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/course/meta", "HEAD", typeof(CourseController), "GetEntityView")]
        [InlineData("/api/academic/course/meta", "HEAD", typeof(CourseController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/course/count", "HEAD", typeof(CourseController), "Count")]
        [InlineData("/api/academic/course/count", "HEAD", typeof(CourseController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/course/all", "HEAD", typeof(CourseController), "GetAll")]
        [InlineData("/api/academic/course/all", "HEAD", typeof(CourseController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/course/export", "HEAD", typeof(CourseController), "Export")]
        [InlineData("/api/academic/course/export", "HEAD", typeof(CourseController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/course/1", "HEAD", typeof(CourseController), "Get")]
        [InlineData("/api/academic/course/1", "HEAD", typeof(CourseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/course/get?courseIds=1", "HEAD", typeof(CourseController), "Get")]
        [InlineData("/api/academic/course/get?courseIds=1", "HEAD", typeof(CourseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/course", "HEAD", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/academic/course", "HEAD", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/course/page/1", "HEAD", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/academic/course/page/1", "HEAD", typeof(CourseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/course/count-filtered/{filterName}", "HEAD", typeof(CourseController), "CountFiltered")]
        [InlineData("/api/academic/course/count-filtered/{filterName}", "HEAD", typeof(CourseController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/course/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CourseController), "GetFiltered")]
        [InlineData("/api/academic/course/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CourseController), "GetFiltered")]
        [InlineData("/api/academic/course/first", "HEAD", typeof(CourseController), "GetFirst")]
        [InlineData("/api/academic/course/previous/1", "HEAD", typeof(CourseController), "GetPrevious")]
        [InlineData("/api/academic/course/next/1", "HEAD", typeof(CourseController), "GetNext")]
        [InlineData("/api/academic/course/last", "HEAD", typeof(CourseController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/course/custom-fields", "HEAD", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/academic/course/custom-fields", "HEAD", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/course/custom-fields/{resourceId}", "HEAD", typeof(CourseController), "GetCustomFields")]
        [InlineData("/api/academic/course/custom-fields/{resourceId}", "HEAD", typeof(CourseController), "GetCustomFields")]

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

        public CourseRouteTests()
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