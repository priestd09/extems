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
    public class HouseRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/house/delete/{houseId}", "DELETE", typeof(HouseController), "Delete")]
        [InlineData("/api/academic/house/delete/{houseId}", "DELETE", typeof(HouseController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/house/edit/{houseId}", "PUT", typeof(HouseController), "Edit")]
        [InlineData("/api/academic/house/edit/{houseId}", "PUT", typeof(HouseController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/house/count-where", "POST", typeof(HouseController), "CountWhere")]
        [InlineData("/api/academic/house/count-where", "POST", typeof(HouseController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/house/get-where/{pageNumber}", "POST", typeof(HouseController), "GetWhere")]
        [InlineData("/api/academic/house/get-where/{pageNumber}", "POST", typeof(HouseController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/house/add-or-edit", "POST", typeof(HouseController), "AddOrEdit")]
        [InlineData("/api/academic/house/add-or-edit", "POST", typeof(HouseController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/house/add/{house}", "POST", typeof(HouseController), "Add")]
        [InlineData("/api/academic/house/add/{house}", "POST", typeof(HouseController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/house/bulk-import", "POST", typeof(HouseController), "BulkImport")]
        [InlineData("/api/academic/house/bulk-import", "POST", typeof(HouseController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/house/meta", "GET", typeof(HouseController), "GetEntityView")]
        [InlineData("/api/academic/house/meta", "GET", typeof(HouseController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/house/count", "GET", typeof(HouseController), "Count")]
        [InlineData("/api/academic/house/count", "GET", typeof(HouseController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/house/all", "GET", typeof(HouseController), "GetAll")]
        [InlineData("/api/academic/house/all", "GET", typeof(HouseController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/house/export", "GET", typeof(HouseController), "Export")]
        [InlineData("/api/academic/house/export", "GET", typeof(HouseController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/house/1", "GET", typeof(HouseController), "Get")]
        [InlineData("/api/academic/house/1", "GET", typeof(HouseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/house/get?houseIds=1", "GET", typeof(HouseController), "Get")]
        [InlineData("/api/academic/house/get?houseIds=1", "GET", typeof(HouseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/house", "GET", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/academic/house", "GET", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/house/page/1", "GET", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/academic/house/page/1", "GET", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/house/count-filtered/{filterName}", "GET", typeof(HouseController), "CountFiltered")]
        [InlineData("/api/academic/house/count-filtered/{filterName}", "GET", typeof(HouseController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/house/get-filtered/{pageNumber}/{filterName}", "GET", typeof(HouseController), "GetFiltered")]
        [InlineData("/api/academic/house/get-filtered/{pageNumber}/{filterName}", "GET", typeof(HouseController), "GetFiltered")]
        [InlineData("/api/academic/house/first", "GET", typeof(HouseController), "GetFirst")]
        [InlineData("/api/academic/house/previous/1", "GET", typeof(HouseController), "GetPrevious")]
        [InlineData("/api/academic/house/next/1", "GET", typeof(HouseController), "GetNext")]
        [InlineData("/api/academic/house/last", "GET", typeof(HouseController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/house/custom-fields", "GET", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/academic/house/custom-fields", "GET", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/house/custom-fields/{resourceId}", "GET", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/academic/house/custom-fields/{resourceId}", "GET", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/house/meta", "HEAD", typeof(HouseController), "GetEntityView")]
        [InlineData("/api/academic/house/meta", "HEAD", typeof(HouseController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/house/count", "HEAD", typeof(HouseController), "Count")]
        [InlineData("/api/academic/house/count", "HEAD", typeof(HouseController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/house/all", "HEAD", typeof(HouseController), "GetAll")]
        [InlineData("/api/academic/house/all", "HEAD", typeof(HouseController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/house/export", "HEAD", typeof(HouseController), "Export")]
        [InlineData("/api/academic/house/export", "HEAD", typeof(HouseController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/house/1", "HEAD", typeof(HouseController), "Get")]
        [InlineData("/api/academic/house/1", "HEAD", typeof(HouseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/house/get?houseIds=1", "HEAD", typeof(HouseController), "Get")]
        [InlineData("/api/academic/house/get?houseIds=1", "HEAD", typeof(HouseController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/house", "HEAD", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/academic/house", "HEAD", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/house/page/1", "HEAD", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/academic/house/page/1", "HEAD", typeof(HouseController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/house/count-filtered/{filterName}", "HEAD", typeof(HouseController), "CountFiltered")]
        [InlineData("/api/academic/house/count-filtered/{filterName}", "HEAD", typeof(HouseController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/house/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(HouseController), "GetFiltered")]
        [InlineData("/api/academic/house/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(HouseController), "GetFiltered")]
        [InlineData("/api/academic/house/first", "HEAD", typeof(HouseController), "GetFirst")]
        [InlineData("/api/academic/house/previous/1", "HEAD", typeof(HouseController), "GetPrevious")]
        [InlineData("/api/academic/house/next/1", "HEAD", typeof(HouseController), "GetNext")]
        [InlineData("/api/academic/house/last", "HEAD", typeof(HouseController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/house/custom-fields", "HEAD", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/academic/house/custom-fields", "HEAD", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/house/custom-fields/{resourceId}", "HEAD", typeof(HouseController), "GetCustomFields")]
        [InlineData("/api/academic/house/custom-fields/{resourceId}", "HEAD", typeof(HouseController), "GetCustomFields")]

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

        public HouseRouteTests()
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