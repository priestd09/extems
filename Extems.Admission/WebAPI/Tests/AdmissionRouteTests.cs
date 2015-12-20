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
    public class AdmissionRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/admission/delete/{admissionId}", "DELETE", typeof(AdmissionController), "Delete")]
        [InlineData("/api/admission/admission/delete/{admissionId}", "DELETE", typeof(AdmissionController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/edit/{admissionId}", "PUT", typeof(AdmissionController), "Edit")]
        [InlineData("/api/admission/admission/edit/{admissionId}", "PUT", typeof(AdmissionController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/count-where", "POST", typeof(AdmissionController), "CountWhere")]
        [InlineData("/api/admission/admission/count-where", "POST", typeof(AdmissionController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/get-where/{pageNumber}", "POST", typeof(AdmissionController), "GetWhere")]
        [InlineData("/api/admission/admission/get-where/{pageNumber}", "POST", typeof(AdmissionController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/add-or-edit", "POST", typeof(AdmissionController), "AddOrEdit")]
        [InlineData("/api/admission/admission/add-or-edit", "POST", typeof(AdmissionController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/add/{admission}", "POST", typeof(AdmissionController), "Add")]
        [InlineData("/api/admission/admission/add/{admission}", "POST", typeof(AdmissionController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/bulk-import", "POST", typeof(AdmissionController), "BulkImport")]
        [InlineData("/api/admission/admission/bulk-import", "POST", typeof(AdmissionController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/meta", "GET", typeof(AdmissionController), "GetEntityView")]
        [InlineData("/api/admission/admission/meta", "GET", typeof(AdmissionController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/count", "GET", typeof(AdmissionController), "Count")]
        [InlineData("/api/admission/admission/count", "GET", typeof(AdmissionController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/all", "GET", typeof(AdmissionController), "GetAll")]
        [InlineData("/api/admission/admission/all", "GET", typeof(AdmissionController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/export", "GET", typeof(AdmissionController), "Export")]
        [InlineData("/api/admission/admission/export", "GET", typeof(AdmissionController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/1", "GET", typeof(AdmissionController), "Get")]
        [InlineData("/api/admission/admission/1", "GET", typeof(AdmissionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/get?admissionIds=1", "GET", typeof(AdmissionController), "Get")]
        [InlineData("/api/admission/admission/get?admissionIds=1", "GET", typeof(AdmissionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission", "GET", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission", "GET", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/page/1", "GET", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission/page/1", "GET", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/count-filtered/{filterName}", "GET", typeof(AdmissionController), "CountFiltered")]
        [InlineData("/api/admission/admission/count-filtered/{filterName}", "GET", typeof(AdmissionController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AdmissionController), "GetFiltered")]
        [InlineData("/api/admission/admission/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AdmissionController), "GetFiltered")]
        [InlineData("/api/admission/admission/first", "GET", typeof(AdmissionController), "GetFirst")]
        [InlineData("/api/admission/admission/previous/1", "GET", typeof(AdmissionController), "GetPrevious")]
        [InlineData("/api/admission/admission/next/1", "GET", typeof(AdmissionController), "GetNext")]
        [InlineData("/api/admission/admission/last", "GET", typeof(AdmissionController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/admission/custom-fields", "GET", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/admission/admission/custom-fields", "GET", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/custom-fields/{resourceId}", "GET", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/admission/admission/custom-fields/{resourceId}", "GET", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/meta", "HEAD", typeof(AdmissionController), "GetEntityView")]
        [InlineData("/api/admission/admission/meta", "HEAD", typeof(AdmissionController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/count", "HEAD", typeof(AdmissionController), "Count")]
        [InlineData("/api/admission/admission/count", "HEAD", typeof(AdmissionController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/all", "HEAD", typeof(AdmissionController), "GetAll")]
        [InlineData("/api/admission/admission/all", "HEAD", typeof(AdmissionController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/export", "HEAD", typeof(AdmissionController), "Export")]
        [InlineData("/api/admission/admission/export", "HEAD", typeof(AdmissionController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/1", "HEAD", typeof(AdmissionController), "Get")]
        [InlineData("/api/admission/admission/1", "HEAD", typeof(AdmissionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/get?admissionIds=1", "HEAD", typeof(AdmissionController), "Get")]
        [InlineData("/api/admission/admission/get?admissionIds=1", "HEAD", typeof(AdmissionController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission", "HEAD", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission", "HEAD", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/page/1", "HEAD", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission/page/1", "HEAD", typeof(AdmissionController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/count-filtered/{filterName}", "HEAD", typeof(AdmissionController), "CountFiltered")]
        [InlineData("/api/admission/admission/count-filtered/{filterName}", "HEAD", typeof(AdmissionController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AdmissionController), "GetFiltered")]
        [InlineData("/api/admission/admission/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AdmissionController), "GetFiltered")]
        [InlineData("/api/admission/admission/first", "HEAD", typeof(AdmissionController), "GetFirst")]
        [InlineData("/api/admission/admission/previous/1", "HEAD", typeof(AdmissionController), "GetPrevious")]
        [InlineData("/api/admission/admission/next/1", "HEAD", typeof(AdmissionController), "GetNext")]
        [InlineData("/api/admission/admission/last", "HEAD", typeof(AdmissionController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/admission/custom-fields", "HEAD", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/admission/admission/custom-fields", "HEAD", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission/custom-fields/{resourceId}", "HEAD", typeof(AdmissionController), "GetCustomFields")]
        [InlineData("/api/admission/admission/custom-fields/{resourceId}", "HEAD", typeof(AdmissionController), "GetCustomFields")]

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

        public AdmissionRouteTests()
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