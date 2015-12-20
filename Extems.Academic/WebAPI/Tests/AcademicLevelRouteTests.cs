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
    public class AcademicLevelRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/delete/{academicLevelId}", "DELETE", typeof(AcademicLevelController), "Delete")]
        [InlineData("/api/academic/academic-level/delete/{academicLevelId}", "DELETE", typeof(AcademicLevelController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/edit/{academicLevelId}", "PUT", typeof(AcademicLevelController), "Edit")]
        [InlineData("/api/academic/academic-level/edit/{academicLevelId}", "PUT", typeof(AcademicLevelController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/count-where", "POST", typeof(AcademicLevelController), "CountWhere")]
        [InlineData("/api/academic/academic-level/count-where", "POST", typeof(AcademicLevelController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/get-where/{pageNumber}", "POST", typeof(AcademicLevelController), "GetWhere")]
        [InlineData("/api/academic/academic-level/get-where/{pageNumber}", "POST", typeof(AcademicLevelController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/add-or-edit", "POST", typeof(AcademicLevelController), "AddOrEdit")]
        [InlineData("/api/academic/academic-level/add-or-edit", "POST", typeof(AcademicLevelController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/add/{academicLevel}", "POST", typeof(AcademicLevelController), "Add")]
        [InlineData("/api/academic/academic-level/add/{academicLevel}", "POST", typeof(AcademicLevelController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/bulk-import", "POST", typeof(AcademicLevelController), "BulkImport")]
        [InlineData("/api/academic/academic-level/bulk-import", "POST", typeof(AcademicLevelController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/meta", "GET", typeof(AcademicLevelController), "GetEntityView")]
        [InlineData("/api/academic/academic-level/meta", "GET", typeof(AcademicLevelController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/count", "GET", typeof(AcademicLevelController), "Count")]
        [InlineData("/api/academic/academic-level/count", "GET", typeof(AcademicLevelController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/all", "GET", typeof(AcademicLevelController), "GetAll")]
        [InlineData("/api/academic/academic-level/all", "GET", typeof(AcademicLevelController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/export", "GET", typeof(AcademicLevelController), "Export")]
        [InlineData("/api/academic/academic-level/export", "GET", typeof(AcademicLevelController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/1", "GET", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/academic/academic-level/1", "GET", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/get?academicLevelIds=1", "GET", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/academic/academic-level/get?academicLevelIds=1", "GET", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level", "GET", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/academic/academic-level", "GET", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/page/1", "GET", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/academic/academic-level/page/1", "GET", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/count-filtered/{filterName}", "GET", typeof(AcademicLevelController), "CountFiltered")]
        [InlineData("/api/academic/academic-level/count-filtered/{filterName}", "GET", typeof(AcademicLevelController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AcademicLevelController), "GetFiltered")]
        [InlineData("/api/academic/academic-level/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AcademicLevelController), "GetFiltered")]
        [InlineData("/api/academic/academic-level/first", "GET", typeof(AcademicLevelController), "GetFirst")]
        [InlineData("/api/academic/academic-level/previous/1", "GET", typeof(AcademicLevelController), "GetPrevious")]
        [InlineData("/api/academic/academic-level/next/1", "GET", typeof(AcademicLevelController), "GetNext")]
        [InlineData("/api/academic/academic-level/last", "GET", typeof(AcademicLevelController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/academic-level/custom-fields", "GET", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/academic/academic-level/custom-fields", "GET", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/custom-fields/{resourceId}", "GET", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/academic/academic-level/custom-fields/{resourceId}", "GET", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/meta", "HEAD", typeof(AcademicLevelController), "GetEntityView")]
        [InlineData("/api/academic/academic-level/meta", "HEAD", typeof(AcademicLevelController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/count", "HEAD", typeof(AcademicLevelController), "Count")]
        [InlineData("/api/academic/academic-level/count", "HEAD", typeof(AcademicLevelController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/all", "HEAD", typeof(AcademicLevelController), "GetAll")]
        [InlineData("/api/academic/academic-level/all", "HEAD", typeof(AcademicLevelController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/export", "HEAD", typeof(AcademicLevelController), "Export")]
        [InlineData("/api/academic/academic-level/export", "HEAD", typeof(AcademicLevelController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/1", "HEAD", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/academic/academic-level/1", "HEAD", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/get?academicLevelIds=1", "HEAD", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/academic/academic-level/get?academicLevelIds=1", "HEAD", typeof(AcademicLevelController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level", "HEAD", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/academic/academic-level", "HEAD", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/page/1", "HEAD", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/academic/academic-level/page/1", "HEAD", typeof(AcademicLevelController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/count-filtered/{filterName}", "HEAD", typeof(AcademicLevelController), "CountFiltered")]
        [InlineData("/api/academic/academic-level/count-filtered/{filterName}", "HEAD", typeof(AcademicLevelController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AcademicLevelController), "GetFiltered")]
        [InlineData("/api/academic/academic-level/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AcademicLevelController), "GetFiltered")]
        [InlineData("/api/academic/academic-level/first", "HEAD", typeof(AcademicLevelController), "GetFirst")]
        [InlineData("/api/academic/academic-level/previous/1", "HEAD", typeof(AcademicLevelController), "GetPrevious")]
        [InlineData("/api/academic/academic-level/next/1", "HEAD", typeof(AcademicLevelController), "GetNext")]
        [InlineData("/api/academic/academic-level/last", "HEAD", typeof(AcademicLevelController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/academic-level/custom-fields", "HEAD", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/academic/academic-level/custom-fields", "HEAD", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/academic-level/custom-fields/{resourceId}", "HEAD", typeof(AcademicLevelController), "GetCustomFields")]
        [InlineData("/api/academic/academic-level/custom-fields/{resourceId}", "HEAD", typeof(AcademicLevelController), "GetCustomFields")]

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

        public AcademicLevelRouteTests()
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