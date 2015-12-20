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
    public class SubjectRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/academic/subject/delete/{subjectId}", "DELETE", typeof(SubjectController), "Delete")]
        [InlineData("/api/academic/subject/delete/{subjectId}", "DELETE", typeof(SubjectController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/edit/{subjectId}", "PUT", typeof(SubjectController), "Edit")]
        [InlineData("/api/academic/subject/edit/{subjectId}", "PUT", typeof(SubjectController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/count-where", "POST", typeof(SubjectController), "CountWhere")]
        [InlineData("/api/academic/subject/count-where", "POST", typeof(SubjectController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/get-where/{pageNumber}", "POST", typeof(SubjectController), "GetWhere")]
        [InlineData("/api/academic/subject/get-where/{pageNumber}", "POST", typeof(SubjectController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/add-or-edit", "POST", typeof(SubjectController), "AddOrEdit")]
        [InlineData("/api/academic/subject/add-or-edit", "POST", typeof(SubjectController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/add/{subject}", "POST", typeof(SubjectController), "Add")]
        [InlineData("/api/academic/subject/add/{subject}", "POST", typeof(SubjectController), "Add")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/bulk-import", "POST", typeof(SubjectController), "BulkImport")]
        [InlineData("/api/academic/subject/bulk-import", "POST", typeof(SubjectController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/meta", "GET", typeof(SubjectController), "GetEntityView")]
        [InlineData("/api/academic/subject/meta", "GET", typeof(SubjectController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/count", "GET", typeof(SubjectController), "Count")]
        [InlineData("/api/academic/subject/count", "GET", typeof(SubjectController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/all", "GET", typeof(SubjectController), "GetAll")]
        [InlineData("/api/academic/subject/all", "GET", typeof(SubjectController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/export", "GET", typeof(SubjectController), "Export")]
        [InlineData("/api/academic/subject/export", "GET", typeof(SubjectController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/1", "GET", typeof(SubjectController), "Get")]
        [InlineData("/api/academic/subject/1", "GET", typeof(SubjectController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/get?subjectIds=1", "GET", typeof(SubjectController), "Get")]
        [InlineData("/api/academic/subject/get?subjectIds=1", "GET", typeof(SubjectController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/subject", "GET", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/academic/subject", "GET", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/page/1", "GET", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/academic/subject/page/1", "GET", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/count-filtered/{filterName}", "GET", typeof(SubjectController), "CountFiltered")]
        [InlineData("/api/academic/subject/count-filtered/{filterName}", "GET", typeof(SubjectController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/get-filtered/{pageNumber}/{filterName}", "GET", typeof(SubjectController), "GetFiltered")]
        [InlineData("/api/academic/subject/get-filtered/{pageNumber}/{filterName}", "GET", typeof(SubjectController), "GetFiltered")]
        [InlineData("/api/academic/subject/first", "GET", typeof(SubjectController), "GetFirst")]
        [InlineData("/api/academic/subject/previous/1", "GET", typeof(SubjectController), "GetPrevious")]
        [InlineData("/api/academic/subject/next/1", "GET", typeof(SubjectController), "GetNext")]
        [InlineData("/api/academic/subject/last", "GET", typeof(SubjectController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/subject/custom-fields", "GET", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/academic/subject/custom-fields", "GET", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/custom-fields/{resourceId}", "GET", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/academic/subject/custom-fields/{resourceId}", "GET", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/meta", "HEAD", typeof(SubjectController), "GetEntityView")]
        [InlineData("/api/academic/subject/meta", "HEAD", typeof(SubjectController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/count", "HEAD", typeof(SubjectController), "Count")]
        [InlineData("/api/academic/subject/count", "HEAD", typeof(SubjectController), "Count")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/all", "HEAD", typeof(SubjectController), "GetAll")]
        [InlineData("/api/academic/subject/all", "HEAD", typeof(SubjectController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/export", "HEAD", typeof(SubjectController), "Export")]
        [InlineData("/api/academic/subject/export", "HEAD", typeof(SubjectController), "Export")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/1", "HEAD", typeof(SubjectController), "Get")]
        [InlineData("/api/academic/subject/1", "HEAD", typeof(SubjectController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/get?subjectIds=1", "HEAD", typeof(SubjectController), "Get")]
        [InlineData("/api/academic/subject/get?subjectIds=1", "HEAD", typeof(SubjectController), "Get")]
        [InlineData("/api/{apiVersionNumber}/academic/subject", "HEAD", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/academic/subject", "HEAD", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/page/1", "HEAD", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/academic/subject/page/1", "HEAD", typeof(SubjectController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/count-filtered/{filterName}", "HEAD", typeof(SubjectController), "CountFiltered")]
        [InlineData("/api/academic/subject/count-filtered/{filterName}", "HEAD", typeof(SubjectController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(SubjectController), "GetFiltered")]
        [InlineData("/api/academic/subject/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(SubjectController), "GetFiltered")]
        [InlineData("/api/academic/subject/first", "HEAD", typeof(SubjectController), "GetFirst")]
        [InlineData("/api/academic/subject/previous/1", "HEAD", typeof(SubjectController), "GetPrevious")]
        [InlineData("/api/academic/subject/next/1", "HEAD", typeof(SubjectController), "GetNext")]
        [InlineData("/api/academic/subject/last", "HEAD", typeof(SubjectController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/academic/subject/custom-fields", "HEAD", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/academic/subject/custom-fields", "HEAD", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/academic/subject/custom-fields/{resourceId}", "HEAD", typeof(SubjectController), "GetCustomFields")]
        [InlineData("/api/academic/subject/custom-fields/{resourceId}", "HEAD", typeof(SubjectController), "GetCustomFields")]

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

        public SubjectRouteTests()
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