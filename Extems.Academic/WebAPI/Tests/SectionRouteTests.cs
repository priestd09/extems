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
    public class SectionRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/section/delete/{sectionId}", "DELETE", typeof(SectionController), "Delete")]
        [InlineData("/api/academic/section/delete/{sectionId}", "DELETE", typeof(SectionController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/section/edit/{sectionId}", "PUT", typeof(SectionController), "Edit")]
        [InlineData("/api/academic/section/edit/{sectionId}", "PUT", typeof(SectionController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/section/count-where", "POST", typeof(SectionController), "CountWhere")]
        [InlineData("/api/academic/section/count-where", "POST", typeof(SectionController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/section/get-where/{pageNumber}", "POST", typeof(SectionController), "GetWhere")]
        [InlineData("/api/academic/section/get-where/{pageNumber}", "POST", typeof(SectionController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/section/add-or-edit", "POST", typeof(SectionController), "AddOrEdit")]
        [InlineData("/api/academic/section/add-or-edit", "POST", typeof(SectionController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/section/add/{section}", "POST", typeof(SectionController), "Add")]
        [InlineData("/api/academic/section/add/{section}", "POST", typeof(SectionController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/section/bulk-import", "POST", typeof(SectionController), "BulkImport")]
        [InlineData("/api/academic/section/bulk-import", "POST", typeof(SectionController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/section/meta", "GET", typeof(SectionController), "GetEntityView")]
        [InlineData("/api/academic/section/meta", "GET", typeof(SectionController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/section/count", "GET", typeof(SectionController), "Count")]
        [InlineData("/api/academic/section/count", "GET", typeof(SectionController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/section/all", "GET", typeof(SectionController), "GetAll")]
        [InlineData("/api/academic/section/all", "GET", typeof(SectionController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/section/export", "GET", typeof(SectionController), "Export")]
        [InlineData("/api/academic/section/export", "GET", typeof(SectionController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/section/1", "GET", typeof(SectionController), "Get")]
        [InlineData("/api/academic/section/1", "GET", typeof(SectionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/section/get?sectionIds=1", "GET", typeof(SectionController), "Get")]
        [InlineData("/api/academic/section/get?sectionIds=1", "GET", typeof(SectionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/section", "GET", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/academic/section", "GET", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/section/page/1", "GET", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/academic/section/page/1", "GET", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/section/count-filtered/{filterName}", "GET", typeof(SectionController), "CountFiltered")]
        [InlineData("/api/academic/section/count-filtered/{filterName}", "GET", typeof(SectionController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/section/get-filtered/{pageNumber}/{filterName}", "GET", typeof(SectionController), "GetFiltered")]
        [InlineData("/api/academic/section/get-filtered/{pageNumber}/{filterName}", "GET", typeof(SectionController), "GetFiltered")]
        [InlineData("/api/academic/section/first", "GET", typeof(SectionController), "GetFirst")]
        [InlineData("/api/academic/section/previous/1", "GET", typeof(SectionController), "GetPrevious")]
        [InlineData("/api/academic/section/next/1", "GET", typeof(SectionController), "GetNext")]
        [InlineData("/api/academic/section/last", "GET", typeof(SectionController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/section/custom-fields", "GET", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/academic/section/custom-fields", "GET", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/section/custom-fields/{resourceId}", "GET", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/academic/section/custom-fields/{resourceId}", "GET", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/section/meta", "HEAD", typeof(SectionController), "GetEntityView")]
        [InlineData("/api/academic/section/meta", "HEAD", typeof(SectionController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/section/count", "HEAD", typeof(SectionController), "Count")]
        [InlineData("/api/academic/section/count", "HEAD", typeof(SectionController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/section/all", "HEAD", typeof(SectionController), "GetAll")]
        [InlineData("/api/academic/section/all", "HEAD", typeof(SectionController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/section/export", "HEAD", typeof(SectionController), "Export")]
        [InlineData("/api/academic/section/export", "HEAD", typeof(SectionController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/section/1", "HEAD", typeof(SectionController), "Get")]
        [InlineData("/api/academic/section/1", "HEAD", typeof(SectionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/section/get?sectionIds=1", "HEAD", typeof(SectionController), "Get")]
        [InlineData("/api/academic/section/get?sectionIds=1", "HEAD", typeof(SectionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/section", "HEAD", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/academic/section", "HEAD", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/section/page/1", "HEAD", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/academic/section/page/1", "HEAD", typeof(SectionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/section/count-filtered/{filterName}", "HEAD", typeof(SectionController), "CountFiltered")]
        [InlineData("/api/academic/section/count-filtered/{filterName}", "HEAD", typeof(SectionController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/section/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(SectionController), "GetFiltered")]
        [InlineData("/api/academic/section/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(SectionController), "GetFiltered")]
        [InlineData("/api/academic/section/first", "HEAD", typeof(SectionController), "GetFirst")]
        [InlineData("/api/academic/section/previous/1", "HEAD", typeof(SectionController), "GetPrevious")]
        [InlineData("/api/academic/section/next/1", "HEAD", typeof(SectionController), "GetNext")]
        [InlineData("/api/academic/section/last", "HEAD", typeof(SectionController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/section/custom-fields", "HEAD", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/academic/section/custom-fields", "HEAD", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/section/custom-fields/{resourceId}", "HEAD", typeof(SectionController), "GetCustomFields")]
        [InlineData("/api/academic/section/custom-fields/{resourceId}", "HEAD", typeof(SectionController), "GetCustomFields")]

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

        public SectionRouteTests()
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