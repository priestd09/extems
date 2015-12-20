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
    public class AdmissionApplicationRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/delete/{admissionApplicationId}", "DELETE", typeof(AdmissionApplicationController), "Delete")]
        [InlineData("/api/admission/admission-application/delete/{admissionApplicationId}", "DELETE", typeof(AdmissionApplicationController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/edit/{admissionApplicationId}", "PUT", typeof(AdmissionApplicationController), "Edit")]
        [InlineData("/api/admission/admission-application/edit/{admissionApplicationId}", "PUT", typeof(AdmissionApplicationController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/verify/{admissionApplicationId}/{verificationStatusId}/{reason}", "PUT", typeof(AdmissionApplicationController), "Verifiy")]
        [InlineData("/api/admission/admission-application/verify/{admissionApplicationId}/{verificationStatusId}/{reason}", "PUT", typeof(AdmissionApplicationController), "Verifiy")]

        [InlineData("/api/{apiVersionNumber}/admission/admission-application/count-where", "POST", typeof(AdmissionApplicationController), "CountWhere")]
        [InlineData("/api/admission/admission-application/count-where", "POST", typeof(AdmissionApplicationController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/get-where/{pageNumber}", "POST", typeof(AdmissionApplicationController), "GetWhere")]
        [InlineData("/api/admission/admission-application/get-where/{pageNumber}", "POST", typeof(AdmissionApplicationController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/add-or-edit", "POST", typeof(AdmissionApplicationController), "AddOrEdit")]
        [InlineData("/api/admission/admission-application/add-or-edit", "POST", typeof(AdmissionApplicationController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/add/{admissionApplication}", "POST", typeof(AdmissionApplicationController), "Add")]
        [InlineData("/api/admission/admission-application/add/{admissionApplication}", "POST", typeof(AdmissionApplicationController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/bulk-import", "POST", typeof(AdmissionApplicationController), "BulkImport")]
        [InlineData("/api/admission/admission-application/bulk-import", "POST", typeof(AdmissionApplicationController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/meta", "GET", typeof(AdmissionApplicationController), "GetEntityView")]
        [InlineData("/api/admission/admission-application/meta", "GET", typeof(AdmissionApplicationController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/count", "GET", typeof(AdmissionApplicationController), "Count")]
        [InlineData("/api/admission/admission-application/count", "GET", typeof(AdmissionApplicationController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/all", "GET", typeof(AdmissionApplicationController), "GetAll")]
        [InlineData("/api/admission/admission-application/all", "GET", typeof(AdmissionApplicationController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/export", "GET", typeof(AdmissionApplicationController), "Export")]
        [InlineData("/api/admission/admission-application/export", "GET", typeof(AdmissionApplicationController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/1", "GET", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/admission/admission-application/1", "GET", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/get?admissionApplicationIds=1", "GET", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/admission/admission-application/get?admissionApplicationIds=1", "GET", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application", "GET", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission-application", "GET", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/page/1", "GET", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission-application/page/1", "GET", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/count-filtered/{filterName}", "GET", typeof(AdmissionApplicationController), "CountFiltered")]
        [InlineData("/api/admission/admission-application/count-filtered/{filterName}", "GET", typeof(AdmissionApplicationController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AdmissionApplicationController), "GetFiltered")]
        [InlineData("/api/admission/admission-application/get-filtered/{pageNumber}/{filterName}", "GET", typeof(AdmissionApplicationController), "GetFiltered")]
        [InlineData("/api/admission/admission-application/first", "GET", typeof(AdmissionApplicationController), "GetFirst")]
        [InlineData("/api/admission/admission-application/previous/1", "GET", typeof(AdmissionApplicationController), "GetPrevious")]
        [InlineData("/api/admission/admission-application/next/1", "GET", typeof(AdmissionApplicationController), "GetNext")]
        [InlineData("/api/admission/admission-application/last", "GET", typeof(AdmissionApplicationController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/admission-application/custom-fields", "GET", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/admission/admission-application/custom-fields", "GET", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/custom-fields/{resourceId}", "GET", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/admission/admission-application/custom-fields/{resourceId}", "GET", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/meta", "HEAD", typeof(AdmissionApplicationController), "GetEntityView")]
        [InlineData("/api/admission/admission-application/meta", "HEAD", typeof(AdmissionApplicationController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/count", "HEAD", typeof(AdmissionApplicationController), "Count")]
        [InlineData("/api/admission/admission-application/count", "HEAD", typeof(AdmissionApplicationController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/all", "HEAD", typeof(AdmissionApplicationController), "GetAll")]
        [InlineData("/api/admission/admission-application/all", "HEAD", typeof(AdmissionApplicationController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/export", "HEAD", typeof(AdmissionApplicationController), "Export")]
        [InlineData("/api/admission/admission-application/export", "HEAD", typeof(AdmissionApplicationController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/1", "HEAD", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/admission/admission-application/1", "HEAD", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/get?admissionApplicationIds=1", "HEAD", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/admission/admission-application/get?admissionApplicationIds=1", "HEAD", typeof(AdmissionApplicationController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application", "HEAD", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission-application", "HEAD", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/page/1", "HEAD", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/admission/admission-application/page/1", "HEAD", typeof(AdmissionApplicationController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/count-filtered/{filterName}", "HEAD", typeof(AdmissionApplicationController), "CountFiltered")]
        [InlineData("/api/admission/admission-application/count-filtered/{filterName}", "HEAD", typeof(AdmissionApplicationController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AdmissionApplicationController), "GetFiltered")]
        [InlineData("/api/admission/admission-application/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(AdmissionApplicationController), "GetFiltered")]
        [InlineData("/api/admission/admission-application/first", "HEAD", typeof(AdmissionApplicationController), "GetFirst")]
        [InlineData("/api/admission/admission-application/previous/1", "HEAD", typeof(AdmissionApplicationController), "GetPrevious")]
        [InlineData("/api/admission/admission-application/next/1", "HEAD", typeof(AdmissionApplicationController), "GetNext")]
        [InlineData("/api/admission/admission-application/last", "HEAD", typeof(AdmissionApplicationController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/admission-application/custom-fields", "HEAD", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/admission/admission-application/custom-fields", "HEAD", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/admission-application/custom-fields/{resourceId}", "HEAD", typeof(AdmissionApplicationController), "GetCustomFields")]
        [InlineData("/api/admission/admission-application/custom-fields/{resourceId}", "HEAD", typeof(AdmissionApplicationController), "GetCustomFields")]

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

        public AdmissionApplicationRouteTests()
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