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
    public class VerificationStatusRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/delete/{verificationStatusId}", "DELETE", typeof(VerificationStatusController), "Delete")]
        [InlineData("/api/admission/verification-status/delete/{verificationStatusId}", "DELETE", typeof(VerificationStatusController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/edit/{verificationStatusId}", "PUT", typeof(VerificationStatusController), "Edit")]
        [InlineData("/api/admission/verification-status/edit/{verificationStatusId}", "PUT", typeof(VerificationStatusController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/count-where", "POST", typeof(VerificationStatusController), "CountWhere")]
        [InlineData("/api/admission/verification-status/count-where", "POST", typeof(VerificationStatusController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/get-where/{pageNumber}", "POST", typeof(VerificationStatusController), "GetWhere")]
        [InlineData("/api/admission/verification-status/get-where/{pageNumber}", "POST", typeof(VerificationStatusController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/add-or-edit", "POST", typeof(VerificationStatusController), "AddOrEdit")]
        [InlineData("/api/admission/verification-status/add-or-edit", "POST", typeof(VerificationStatusController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/add/{verificationStatus}", "POST", typeof(VerificationStatusController), "Add")]
        [InlineData("/api/admission/verification-status/add/{verificationStatus}", "POST", typeof(VerificationStatusController), "Add")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/bulk-import", "POST", typeof(VerificationStatusController), "BulkImport")]
        [InlineData("/api/admission/verification-status/bulk-import", "POST", typeof(VerificationStatusController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/meta", "GET", typeof(VerificationStatusController), "GetEntityView")]
        [InlineData("/api/admission/verification-status/meta", "GET", typeof(VerificationStatusController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/count", "GET", typeof(VerificationStatusController), "Count")]
        [InlineData("/api/admission/verification-status/count", "GET", typeof(VerificationStatusController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/all", "GET", typeof(VerificationStatusController), "GetAll")]
        [InlineData("/api/admission/verification-status/all", "GET", typeof(VerificationStatusController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/export", "GET", typeof(VerificationStatusController), "Export")]
        [InlineData("/api/admission/verification-status/export", "GET", typeof(VerificationStatusController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/1", "GET", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/admission/verification-status/1", "GET", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/get?verificationStatusIds=1", "GET", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/admission/verification-status/get?verificationStatusIds=1", "GET", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status", "GET", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/admission/verification-status", "GET", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/page/1", "GET", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/admission/verification-status/page/1", "GET", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/count-filtered/{filterName}", "GET", typeof(VerificationStatusController), "CountFiltered")]
        [InlineData("/api/admission/verification-status/count-filtered/{filterName}", "GET", typeof(VerificationStatusController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/get-filtered/{pageNumber}/{filterName}", "GET", typeof(VerificationStatusController), "GetFiltered")]
        [InlineData("/api/admission/verification-status/get-filtered/{pageNumber}/{filterName}", "GET", typeof(VerificationStatusController), "GetFiltered")]
        [InlineData("/api/admission/verification-status/first", "GET", typeof(VerificationStatusController), "GetFirst")]
        [InlineData("/api/admission/verification-status/previous/1", "GET", typeof(VerificationStatusController), "GetPrevious")]
        [InlineData("/api/admission/verification-status/next/1", "GET", typeof(VerificationStatusController), "GetNext")]
        [InlineData("/api/admission/verification-status/last", "GET", typeof(VerificationStatusController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/verification-status/custom-fields", "GET", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/admission/verification-status/custom-fields", "GET", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/custom-fields/{resourceId}", "GET", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/admission/verification-status/custom-fields/{resourceId}", "GET", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/meta", "HEAD", typeof(VerificationStatusController), "GetEntityView")]
        [InlineData("/api/admission/verification-status/meta", "HEAD", typeof(VerificationStatusController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/count", "HEAD", typeof(VerificationStatusController), "Count")]
        [InlineData("/api/admission/verification-status/count", "HEAD", typeof(VerificationStatusController), "Count")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/all", "HEAD", typeof(VerificationStatusController), "GetAll")]
        [InlineData("/api/admission/verification-status/all", "HEAD", typeof(VerificationStatusController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/export", "HEAD", typeof(VerificationStatusController), "Export")]
        [InlineData("/api/admission/verification-status/export", "HEAD", typeof(VerificationStatusController), "Export")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/1", "HEAD", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/admission/verification-status/1", "HEAD", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/get?verificationStatusIds=1", "HEAD", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/admission/verification-status/get?verificationStatusIds=1", "HEAD", typeof(VerificationStatusController), "Get")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status", "HEAD", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/admission/verification-status", "HEAD", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/page/1", "HEAD", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/admission/verification-status/page/1", "HEAD", typeof(VerificationStatusController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/count-filtered/{filterName}", "HEAD", typeof(VerificationStatusController), "CountFiltered")]
        [InlineData("/api/admission/verification-status/count-filtered/{filterName}", "HEAD", typeof(VerificationStatusController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(VerificationStatusController), "GetFiltered")]
        [InlineData("/api/admission/verification-status/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(VerificationStatusController), "GetFiltered")]
        [InlineData("/api/admission/verification-status/first", "HEAD", typeof(VerificationStatusController), "GetFirst")]
        [InlineData("/api/admission/verification-status/previous/1", "HEAD", typeof(VerificationStatusController), "GetPrevious")]
        [InlineData("/api/admission/verification-status/next/1", "HEAD", typeof(VerificationStatusController), "GetNext")]
        [InlineData("/api/admission/verification-status/last", "HEAD", typeof(VerificationStatusController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/admission/verification-status/custom-fields", "HEAD", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/admission/verification-status/custom-fields", "HEAD", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/admission/verification-status/custom-fields/{resourceId}", "HEAD", typeof(VerificationStatusController), "GetCustomFields")]
        [InlineData("/api/admission/verification-status/custom-fields/{resourceId}", "HEAD", typeof(VerificationStatusController), "GetCustomFields")]

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

        public VerificationStatusRouteTests()
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