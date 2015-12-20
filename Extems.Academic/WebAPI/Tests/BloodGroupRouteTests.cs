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
    public class BloodGroupRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/delete/{bloodGroupId}", "DELETE", typeof(BloodGroupController), "Delete")]
        [InlineData("/api/academic/blood-group/delete/{bloodGroupId}", "DELETE", typeof(BloodGroupController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/edit/{bloodGroupId}", "PUT", typeof(BloodGroupController), "Edit")]
        [InlineData("/api/academic/blood-group/edit/{bloodGroupId}", "PUT", typeof(BloodGroupController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/count-where", "POST", typeof(BloodGroupController), "CountWhere")]
        [InlineData("/api/academic/blood-group/count-where", "POST", typeof(BloodGroupController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/get-where/{pageNumber}", "POST", typeof(BloodGroupController), "GetWhere")]
        [InlineData("/api/academic/blood-group/get-where/{pageNumber}", "POST", typeof(BloodGroupController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/add-or-edit", "POST", typeof(BloodGroupController), "AddOrEdit")]
        [InlineData("/api/academic/blood-group/add-or-edit", "POST", typeof(BloodGroupController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/add/{bloodGroup}", "POST", typeof(BloodGroupController), "Add")]
        [InlineData("/api/academic/blood-group/add/{bloodGroup}", "POST", typeof(BloodGroupController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/bulk-import", "POST", typeof(BloodGroupController), "BulkImport")]
        [InlineData("/api/academic/blood-group/bulk-import", "POST", typeof(BloodGroupController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/meta", "GET", typeof(BloodGroupController), "GetEntityView")]
        [InlineData("/api/academic/blood-group/meta", "GET", typeof(BloodGroupController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/count", "GET", typeof(BloodGroupController), "Count")]
        [InlineData("/api/academic/blood-group/count", "GET", typeof(BloodGroupController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/all", "GET", typeof(BloodGroupController), "GetAll")]
        [InlineData("/api/academic/blood-group/all", "GET", typeof(BloodGroupController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/export", "GET", typeof(BloodGroupController), "Export")]
        [InlineData("/api/academic/blood-group/export", "GET", typeof(BloodGroupController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/1", "GET", typeof(BloodGroupController), "Get")]
        [InlineData("/api/academic/blood-group/1", "GET", typeof(BloodGroupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/get?bloodGroupIds=1", "GET", typeof(BloodGroupController), "Get")]
        [InlineData("/api/academic/blood-group/get?bloodGroupIds=1", "GET", typeof(BloodGroupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group", "GET", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/academic/blood-group", "GET", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/page/1", "GET", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/academic/blood-group/page/1", "GET", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/count-filtered/{filterName}", "GET", typeof(BloodGroupController), "CountFiltered")]
        [InlineData("/api/academic/blood-group/count-filtered/{filterName}", "GET", typeof(BloodGroupController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/get-filtered/{pageNumber}/{filterName}", "GET", typeof(BloodGroupController), "GetFiltered")]
        [InlineData("/api/academic/blood-group/get-filtered/{pageNumber}/{filterName}", "GET", typeof(BloodGroupController), "GetFiltered")]
        [InlineData("/api/academic/blood-group/first", "GET", typeof(BloodGroupController), "GetFirst")]
        [InlineData("/api/academic/blood-group/previous/1", "GET", typeof(BloodGroupController), "GetPrevious")]
        [InlineData("/api/academic/blood-group/next/1", "GET", typeof(BloodGroupController), "GetNext")]
        [InlineData("/api/academic/blood-group/last", "GET", typeof(BloodGroupController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/blood-group/custom-fields", "GET", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/academic/blood-group/custom-fields", "GET", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/custom-fields/{resourceId}", "GET", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/academic/blood-group/custom-fields/{resourceId}", "GET", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/meta", "HEAD", typeof(BloodGroupController), "GetEntityView")]
        [InlineData("/api/academic/blood-group/meta", "HEAD", typeof(BloodGroupController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/count", "HEAD", typeof(BloodGroupController), "Count")]
        [InlineData("/api/academic/blood-group/count", "HEAD", typeof(BloodGroupController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/all", "HEAD", typeof(BloodGroupController), "GetAll")]
        [InlineData("/api/academic/blood-group/all", "HEAD", typeof(BloodGroupController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/export", "HEAD", typeof(BloodGroupController), "Export")]
        [InlineData("/api/academic/blood-group/export", "HEAD", typeof(BloodGroupController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/1", "HEAD", typeof(BloodGroupController), "Get")]
        [InlineData("/api/academic/blood-group/1", "HEAD", typeof(BloodGroupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/get?bloodGroupIds=1", "HEAD", typeof(BloodGroupController), "Get")]
        [InlineData("/api/academic/blood-group/get?bloodGroupIds=1", "HEAD", typeof(BloodGroupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group", "HEAD", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/academic/blood-group", "HEAD", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/page/1", "HEAD", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/academic/blood-group/page/1", "HEAD", typeof(BloodGroupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/count-filtered/{filterName}", "HEAD", typeof(BloodGroupController), "CountFiltered")]
        [InlineData("/api/academic/blood-group/count-filtered/{filterName}", "HEAD", typeof(BloodGroupController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(BloodGroupController), "GetFiltered")]
        [InlineData("/api/academic/blood-group/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(BloodGroupController), "GetFiltered")]
        [InlineData("/api/academic/blood-group/first", "HEAD", typeof(BloodGroupController), "GetFirst")]
        [InlineData("/api/academic/blood-group/previous/1", "HEAD", typeof(BloodGroupController), "GetPrevious")]
        [InlineData("/api/academic/blood-group/next/1", "HEAD", typeof(BloodGroupController), "GetNext")]
        [InlineData("/api/academic/blood-group/last", "HEAD", typeof(BloodGroupController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/blood-group/custom-fields", "HEAD", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/academic/blood-group/custom-fields", "HEAD", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/blood-group/custom-fields/{resourceId}", "HEAD", typeof(BloodGroupController), "GetCustomFields")]
        [InlineData("/api/academic/blood-group/custom-fields/{resourceId}", "HEAD", typeof(BloodGroupController), "GetCustomFields")]

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

        public BloodGroupRouteTests()
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