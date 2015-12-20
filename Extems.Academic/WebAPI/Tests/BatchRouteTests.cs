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
    public class BatchRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/batch/delete/{batchId}", "DELETE", typeof(BatchController), "Delete")]
        [InlineData("/api/academic/batch/delete/{batchId}", "DELETE", typeof(BatchController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/edit/{batchId}", "PUT", typeof(BatchController), "Edit")]
        [InlineData("/api/academic/batch/edit/{batchId}", "PUT", typeof(BatchController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/count-where", "POST", typeof(BatchController), "CountWhere")]
        [InlineData("/api/academic/batch/count-where", "POST", typeof(BatchController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/get-where/{pageNumber}", "POST", typeof(BatchController), "GetWhere")]
        [InlineData("/api/academic/batch/get-where/{pageNumber}", "POST", typeof(BatchController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/add-or-edit", "POST", typeof(BatchController), "AddOrEdit")]
        [InlineData("/api/academic/batch/add-or-edit", "POST", typeof(BatchController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/add/{batch}", "POST", typeof(BatchController), "Add")]
        [InlineData("/api/academic/batch/add/{batch}", "POST", typeof(BatchController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/bulk-import", "POST", typeof(BatchController), "BulkImport")]
        [InlineData("/api/academic/batch/bulk-import", "POST", typeof(BatchController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/meta", "GET", typeof(BatchController), "GetEntityView")]
        [InlineData("/api/academic/batch/meta", "GET", typeof(BatchController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/count", "GET", typeof(BatchController), "Count")]
        [InlineData("/api/academic/batch/count", "GET", typeof(BatchController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/all", "GET", typeof(BatchController), "GetAll")]
        [InlineData("/api/academic/batch/all", "GET", typeof(BatchController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/export", "GET", typeof(BatchController), "Export")]
        [InlineData("/api/academic/batch/export", "GET", typeof(BatchController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/1", "GET", typeof(BatchController), "Get")]
        [InlineData("/api/academic/batch/1", "GET", typeof(BatchController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/get?batchIds=1", "GET", typeof(BatchController), "Get")]
        [InlineData("/api/academic/batch/get?batchIds=1", "GET", typeof(BatchController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/batch", "GET", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/academic/batch", "GET", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/page/1", "GET", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/academic/batch/page/1", "GET", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/count-filtered/{filterName}", "GET", typeof(BatchController), "CountFiltered")]
        [InlineData("/api/academic/batch/count-filtered/{filterName}", "GET", typeof(BatchController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/get-filtered/{pageNumber}/{filterName}", "GET", typeof(BatchController), "GetFiltered")]
        [InlineData("/api/academic/batch/get-filtered/{pageNumber}/{filterName}", "GET", typeof(BatchController), "GetFiltered")]
        [InlineData("/api/academic/batch/first", "GET", typeof(BatchController), "GetFirst")]
        [InlineData("/api/academic/batch/previous/1", "GET", typeof(BatchController), "GetPrevious")]
        [InlineData("/api/academic/batch/next/1", "GET", typeof(BatchController), "GetNext")]
        [InlineData("/api/academic/batch/last", "GET", typeof(BatchController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/batch/custom-fields", "GET", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/academic/batch/custom-fields", "GET", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/custom-fields/{resourceId}", "GET", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/academic/batch/custom-fields/{resourceId}", "GET", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/meta", "HEAD", typeof(BatchController), "GetEntityView")]
        [InlineData("/api/academic/batch/meta", "HEAD", typeof(BatchController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/count", "HEAD", typeof(BatchController), "Count")]
        [InlineData("/api/academic/batch/count", "HEAD", typeof(BatchController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/all", "HEAD", typeof(BatchController), "GetAll")]
        [InlineData("/api/academic/batch/all", "HEAD", typeof(BatchController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/export", "HEAD", typeof(BatchController), "Export")]
        [InlineData("/api/academic/batch/export", "HEAD", typeof(BatchController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/1", "HEAD", typeof(BatchController), "Get")]
        [InlineData("/api/academic/batch/1", "HEAD", typeof(BatchController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/get?batchIds=1", "HEAD", typeof(BatchController), "Get")]
        [InlineData("/api/academic/batch/get?batchIds=1", "HEAD", typeof(BatchController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/batch", "HEAD", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/academic/batch", "HEAD", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/page/1", "HEAD", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/academic/batch/page/1", "HEAD", typeof(BatchController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/count-filtered/{filterName}", "HEAD", typeof(BatchController), "CountFiltered")]
        [InlineData("/api/academic/batch/count-filtered/{filterName}", "HEAD", typeof(BatchController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(BatchController), "GetFiltered")]
        [InlineData("/api/academic/batch/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(BatchController), "GetFiltered")]
        [InlineData("/api/academic/batch/first", "HEAD", typeof(BatchController), "GetFirst")]
        [InlineData("/api/academic/batch/previous/1", "HEAD", typeof(BatchController), "GetPrevious")]
        [InlineData("/api/academic/batch/next/1", "HEAD", typeof(BatchController), "GetNext")]
        [InlineData("/api/academic/batch/last", "HEAD", typeof(BatchController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/batch/custom-fields", "HEAD", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/academic/batch/custom-fields", "HEAD", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/batch/custom-fields/{resourceId}", "HEAD", typeof(BatchController), "GetCustomFields")]
        [InlineData("/api/academic/batch/custom-fields/{resourceId}", "HEAD", typeof(BatchController), "GetCustomFields")]

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

        public BatchRouteTests()
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