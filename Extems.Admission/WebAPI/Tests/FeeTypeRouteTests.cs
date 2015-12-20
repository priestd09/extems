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
    public class FeeTypeRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/delete/{feeTypeId}", "DELETE", typeof(FeeTypeController), "Delete")]
        [InlineData("/api/admission/fee-type/delete/{feeTypeId}", "DELETE", typeof(FeeTypeController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/edit/{feeTypeId}", "PUT", typeof(FeeTypeController), "Edit")]
        [InlineData("/api/admission/fee-type/edit/{feeTypeId}", "PUT", typeof(FeeTypeController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/count-where", "POST", typeof(FeeTypeController), "CountWhere")]
        [InlineData("/api/admission/fee-type/count-where", "POST", typeof(FeeTypeController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/get-where/{pageNumber}", "POST", typeof(FeeTypeController), "GetWhere")]
        [InlineData("/api/admission/fee-type/get-where/{pageNumber}", "POST", typeof(FeeTypeController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/add-or-edit", "POST", typeof(FeeTypeController), "AddOrEdit")]
        [InlineData("/api/admission/fee-type/add-or-edit", "POST", typeof(FeeTypeController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/add/{feeType}", "POST", typeof(FeeTypeController), "Add")]
        [InlineData("/api/admission/fee-type/add/{feeType}", "POST", typeof(FeeTypeController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/bulk-import", "POST", typeof(FeeTypeController), "BulkImport")]
        [InlineData("/api/admission/fee-type/bulk-import", "POST", typeof(FeeTypeController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/meta", "GET", typeof(FeeTypeController), "GetEntityView")]
        [InlineData("/api/admission/fee-type/meta", "GET", typeof(FeeTypeController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/count", "GET", typeof(FeeTypeController), "Count")]
        [InlineData("/api/admission/fee-type/count", "GET", typeof(FeeTypeController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/all", "GET", typeof(FeeTypeController), "GetAll")]
        [InlineData("/api/admission/fee-type/all", "GET", typeof(FeeTypeController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/export", "GET", typeof(FeeTypeController), "Export")]
        [InlineData("/api/admission/fee-type/export", "GET", typeof(FeeTypeController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/1", "GET", typeof(FeeTypeController), "Get")]
        [InlineData("/api/admission/fee-type/1", "GET", typeof(FeeTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/get?feeTypeIds=1", "GET", typeof(FeeTypeController), "Get")]
        [InlineData("/api/admission/fee-type/get?feeTypeIds=1", "GET", typeof(FeeTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type", "GET", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/fee-type", "GET", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/page/1", "GET", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/fee-type/page/1", "GET", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/count-filtered/{filterName}", "GET", typeof(FeeTypeController), "CountFiltered")]
        [InlineData("/api/admission/fee-type/count-filtered/{filterName}", "GET", typeof(FeeTypeController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FeeTypeController), "GetFiltered")]
        [InlineData("/api/admission/fee-type/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FeeTypeController), "GetFiltered")]
        [InlineData("/api/admission/fee-type/first", "GET", typeof(FeeTypeController), "GetFirst")]
        [InlineData("/api/admission/fee-type/previous/1", "GET", typeof(FeeTypeController), "GetPrevious")]
        [InlineData("/api/admission/fee-type/next/1", "GET", typeof(FeeTypeController), "GetNext")]
        [InlineData("/api/admission/fee-type/last", "GET", typeof(FeeTypeController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/fee-type/custom-fields", "GET", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/admission/fee-type/custom-fields", "GET", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/custom-fields/{resourceId}", "GET", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/admission/fee-type/custom-fields/{resourceId}", "GET", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/meta", "HEAD", typeof(FeeTypeController), "GetEntityView")]
        [InlineData("/api/admission/fee-type/meta", "HEAD", typeof(FeeTypeController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/count", "HEAD", typeof(FeeTypeController), "Count")]
        [InlineData("/api/admission/fee-type/count", "HEAD", typeof(FeeTypeController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/all", "HEAD", typeof(FeeTypeController), "GetAll")]
        [InlineData("/api/admission/fee-type/all", "HEAD", typeof(FeeTypeController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/export", "HEAD", typeof(FeeTypeController), "Export")]
        [InlineData("/api/admission/fee-type/export", "HEAD", typeof(FeeTypeController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/1", "HEAD", typeof(FeeTypeController), "Get")]
        [InlineData("/api/admission/fee-type/1", "HEAD", typeof(FeeTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/get?feeTypeIds=1", "HEAD", typeof(FeeTypeController), "Get")]
        [InlineData("/api/admission/fee-type/get?feeTypeIds=1", "HEAD", typeof(FeeTypeController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type", "HEAD", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/fee-type", "HEAD", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/page/1", "HEAD", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/admission/fee-type/page/1", "HEAD", typeof(FeeTypeController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/count-filtered/{filterName}", "HEAD", typeof(FeeTypeController), "CountFiltered")]
        [InlineData("/api/admission/fee-type/count-filtered/{filterName}", "HEAD", typeof(FeeTypeController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FeeTypeController), "GetFiltered")]
        [InlineData("/api/admission/fee-type/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FeeTypeController), "GetFiltered")]
        [InlineData("/api/admission/fee-type/first", "HEAD", typeof(FeeTypeController), "GetFirst")]
        [InlineData("/api/admission/fee-type/previous/1", "HEAD", typeof(FeeTypeController), "GetPrevious")]
        [InlineData("/api/admission/fee-type/next/1", "HEAD", typeof(FeeTypeController), "GetNext")]
        [InlineData("/api/admission/fee-type/last", "HEAD", typeof(FeeTypeController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/fee-type/custom-fields", "HEAD", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/admission/fee-type/custom-fields", "HEAD", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/fee-type/custom-fields/{resourceId}", "HEAD", typeof(FeeTypeController), "GetCustomFields")]
        [InlineData("/api/admission/fee-type/custom-fields/{resourceId}", "HEAD", typeof(FeeTypeController), "GetCustomFields")]

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

        public FeeTypeRouteTests()
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