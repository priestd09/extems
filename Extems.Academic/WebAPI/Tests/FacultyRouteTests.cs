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
    public class FacultyRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/delete/{facultyId}", "DELETE", typeof(FacultyController), "Delete")]
        [InlineData("/api/academic/faculty/delete/{facultyId}", "DELETE", typeof(FacultyController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/edit/{facultyId}", "PUT", typeof(FacultyController), "Edit")]
        [InlineData("/api/academic/faculty/edit/{facultyId}", "PUT", typeof(FacultyController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/count-where", "POST", typeof(FacultyController), "CountWhere")]
        [InlineData("/api/academic/faculty/count-where", "POST", typeof(FacultyController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/get-where/{pageNumber}", "POST", typeof(FacultyController), "GetWhere")]
        [InlineData("/api/academic/faculty/get-where/{pageNumber}", "POST", typeof(FacultyController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/add-or-edit", "POST", typeof(FacultyController), "AddOrEdit")]
        [InlineData("/api/academic/faculty/add-or-edit", "POST", typeof(FacultyController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/add/{faculty}", "POST", typeof(FacultyController), "Add")]
        [InlineData("/api/academic/faculty/add/{faculty}", "POST", typeof(FacultyController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/bulk-import", "POST", typeof(FacultyController), "BulkImport")]
        [InlineData("/api/academic/faculty/bulk-import", "POST", typeof(FacultyController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/meta", "GET", typeof(FacultyController), "GetEntityView")]
        [InlineData("/api/academic/faculty/meta", "GET", typeof(FacultyController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/count", "GET", typeof(FacultyController), "Count")]
        [InlineData("/api/academic/faculty/count", "GET", typeof(FacultyController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/all", "GET", typeof(FacultyController), "GetAll")]
        [InlineData("/api/academic/faculty/all", "GET", typeof(FacultyController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/export", "GET", typeof(FacultyController), "Export")]
        [InlineData("/api/academic/faculty/export", "GET", typeof(FacultyController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/1", "GET", typeof(FacultyController), "Get")]
        [InlineData("/api/academic/faculty/1", "GET", typeof(FacultyController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/get?facultyIds=1", "GET", typeof(FacultyController), "Get")]
        [InlineData("/api/academic/faculty/get?facultyIds=1", "GET", typeof(FacultyController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty", "GET", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/academic/faculty", "GET", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/page/1", "GET", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/academic/faculty/page/1", "GET", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/count-filtered/{filterName}", "GET", typeof(FacultyController), "CountFiltered")]
        [InlineData("/api/academic/faculty/count-filtered/{filterName}", "GET", typeof(FacultyController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FacultyController), "GetFiltered")]
        [InlineData("/api/academic/faculty/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FacultyController), "GetFiltered")]
        [InlineData("/api/academic/faculty/first", "GET", typeof(FacultyController), "GetFirst")]
        [InlineData("/api/academic/faculty/previous/1", "GET", typeof(FacultyController), "GetPrevious")]
        [InlineData("/api/academic/faculty/next/1", "GET", typeof(FacultyController), "GetNext")]
        [InlineData("/api/academic/faculty/last", "GET", typeof(FacultyController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/faculty/custom-fields", "GET", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/academic/faculty/custom-fields", "GET", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/custom-fields/{resourceId}", "GET", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/academic/faculty/custom-fields/{resourceId}", "GET", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/meta", "HEAD", typeof(FacultyController), "GetEntityView")]
        [InlineData("/api/academic/faculty/meta", "HEAD", typeof(FacultyController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/count", "HEAD", typeof(FacultyController), "Count")]
        [InlineData("/api/academic/faculty/count", "HEAD", typeof(FacultyController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/all", "HEAD", typeof(FacultyController), "GetAll")]
        [InlineData("/api/academic/faculty/all", "HEAD", typeof(FacultyController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/export", "HEAD", typeof(FacultyController), "Export")]
        [InlineData("/api/academic/faculty/export", "HEAD", typeof(FacultyController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/1", "HEAD", typeof(FacultyController), "Get")]
        [InlineData("/api/academic/faculty/1", "HEAD", typeof(FacultyController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/get?facultyIds=1", "HEAD", typeof(FacultyController), "Get")]
        [InlineData("/api/academic/faculty/get?facultyIds=1", "HEAD", typeof(FacultyController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty", "HEAD", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/academic/faculty", "HEAD", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/page/1", "HEAD", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/academic/faculty/page/1", "HEAD", typeof(FacultyController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/count-filtered/{filterName}", "HEAD", typeof(FacultyController), "CountFiltered")]
        [InlineData("/api/academic/faculty/count-filtered/{filterName}", "HEAD", typeof(FacultyController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FacultyController), "GetFiltered")]
        [InlineData("/api/academic/faculty/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FacultyController), "GetFiltered")]
        [InlineData("/api/academic/faculty/first", "HEAD", typeof(FacultyController), "GetFirst")]
        [InlineData("/api/academic/faculty/previous/1", "HEAD", typeof(FacultyController), "GetPrevious")]
        [InlineData("/api/academic/faculty/next/1", "HEAD", typeof(FacultyController), "GetNext")]
        [InlineData("/api/academic/faculty/last", "HEAD", typeof(FacultyController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/faculty/custom-fields", "HEAD", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/academic/faculty/custom-fields", "HEAD", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/faculty/custom-fields/{resourceId}", "HEAD", typeof(FacultyController), "GetCustomFields")]
        [InlineData("/api/academic/faculty/custom-fields/{resourceId}", "HEAD", typeof(FacultyController), "GetCustomFields")]

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

        public FacultyRouteTests()
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