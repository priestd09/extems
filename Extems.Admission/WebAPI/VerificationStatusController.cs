// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Frapid.ApplicationState.Cache;
using Frapid.ApplicationState.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Extems.Admission.DataAccess;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using Frapid.Framework;
using Frapid.Framework.Extensions;

namespace Extems.Admission.Api
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Verification Statuses.
    /// </summary>
    [RoutePrefix("api/v1.0/admission/verification-status")]
    public class VerificationStatusController : FrapidApiController
    {
        /// <summary>
        ///     The VerificationStatus repository.
        /// </summary>
        private readonly IVerificationStatusRepository VerificationStatusRepository;

        public VerificationStatusController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.To<long>();
            this._UserId = AppUsers.GetCurrent().View.UserId.To<int>();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.To<int>();
            this._Catalog = AppUsers.GetCatalog();

            this.VerificationStatusRepository = new Extems.Admission.DataAccess.VerificationStatus
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public VerificationStatusController(IVerificationStatusRepository repository, string catalog, LoginView view)
        {
            this._LoginId = view.LoginId.To<long>();
            this._UserId = view.UserId.To<int>();
            this._OfficeId = view.OfficeId.To<int>();
            this._Catalog = catalog;

            this.VerificationStatusRepository = repository;
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "verification status" entity.
        /// </summary>
        /// <returns>Returns the "verification status" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/admission/verification-status/meta")]
        [Authorize]
        public EntityView GetEntityView()
        {
            if (this._LoginId == 0)
            {
                return new EntityView();
            }

            return new EntityView
            {
                PrimaryKey = "verification_status_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "verification_status_id",  PropertyName = "VerificationStatusId",  DataType = "short",  DbDataType = "int2",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of verification statuses.
        /// </summary>
        /// <returns>Returns the count of the verification statuses.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/admission/verification-status/count")]
        [Authorize]
        public long Count()
        {
            try
            {
                return this.VerificationStatusRepository.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns all collection of verification status.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("all")]
        [Route("~/api/admission/verification-status/all")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetAll()
        {
            try
            {
                return this.VerificationStatusRepository.GetAll();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns collection of verification status for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/admission/verification-status/export")]
        [Authorize]
        public IEnumerable<dynamic> Export()
        {
            try
            {
                return this.VerificationStatusRepository.Export();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns an instance of verification status.
        /// </summary>
        /// <param name="verificationStatusId">Enter VerificationStatusId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{verificationStatusId}")]
        [Route("~/api/admission/verification-status/{verificationStatusId}")]
        [Authorize]
        public Extems.Admission.Entities.VerificationStatus Get(short verificationStatusId)
        {
            try
            {
                return this.VerificationStatusRepository.Get(verificationStatusId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("get")]
        [Route("~/api/admission/verification-status/get")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> Get([FromUri] short[] verificationStatusIds)
        {
            try
            {
                return this.VerificationStatusRepository.Get(verificationStatusIds);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns the first instance of verification status.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("first")]
        [Route("~/api/admission/verification-status/first")]
        [Authorize]
        public Extems.Admission.Entities.VerificationStatus GetFirst()
        {
            try
            {
                return this.VerificationStatusRepository.GetFirst();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns the previous instance of verification status.
        /// </summary>
        /// <param name="verificationStatusId">Enter VerificationStatusId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("previous/{verificationStatusId}")]
        [Route("~/api/admission/verification-status/previous/{verificationStatusId}")]
        [Authorize]
        public Extems.Admission.Entities.VerificationStatus GetPrevious(short verificationStatusId)
        {
            try
            {
                return this.VerificationStatusRepository.GetPrevious(verificationStatusId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns the next instance of verification status.
        /// </summary>
        /// <param name="verificationStatusId">Enter VerificationStatusId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("next/{verificationStatusId}")]
        [Route("~/api/admission/verification-status/next/{verificationStatusId}")]
        [Authorize]
        public Extems.Admission.Entities.VerificationStatus GetNext(short verificationStatusId)
        {
            try
            {
                return this.VerificationStatusRepository.GetNext(verificationStatusId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Returns the last instance of verification status.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("last")]
        [Route("~/api/admission/verification-status/last")]
        [Authorize]
        public Extems.Admission.Entities.VerificationStatus GetLast()
        {
            try
            {
                return this.VerificationStatusRepository.GetLast();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Creates a paginated collection containing 10 verification statuses on each page, sorted by the property VerificationStatusId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/admission/verification-status")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetPaginatedResult()
        {
            try
            {
                return this.VerificationStatusRepository.GetPaginatedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Creates a paginated collection containing 10 verification statuses on each page, sorted by the property VerificationStatusId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/admission/verification-status/page/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetPaginatedResult(long pageNumber)
        {
            try
            {
                return this.VerificationStatusRepository.GetPaginatedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Counts the number of verification statuses using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered verification statuses.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/admission/verification-status/count-where")]
        [Authorize]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.VerificationStatusRepository.CountWhere(f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 verification statuses on each page, sorted by the property VerificationStatusId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/admission/verification-status/get-where/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.VerificationStatusRepository.GetWhere(pageNumber, f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Counts the number of verification statuses using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered verification statuses.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/admission/verification-status/count-filtered/{filterName}")]
        [Authorize]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.VerificationStatusRepository.CountFiltered(filterName);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 verification statuses on each page, sorted by the property VerificationStatusId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/admission/verification-status/get-filtered/{pageNumber}/{filterName}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.VerificationStatusRepository.GetFiltered(pageNumber, filterName);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of verification statuses.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of verification statuses.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/admission/verification-status/display-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            try
            {
                return this.VerificationStatusRepository.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     A custom field is a user defined field for verification statuses.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of verification statuses.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/admission/verification-status/custom-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            try
            {
                return this.VerificationStatusRepository.GetCustomFields(null);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     A custom field is a user defined field for verification statuses.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of verification statuses.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/admission/verification-status/custom-fields/{resourceId}")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.VerificationStatusRepository.GetCustomFields(resourceId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Adds or edits your instance of VerificationStatus class.
        /// </summary>
        /// <param name="verificationStatus">Your instance of verification statuses class to add or edit.</param>
        [AcceptVerbs("POST")]
        [Route("add-or-edit")]
        [Route("~/api/admission/verification-status/add-or-edit")]
        [Authorize]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            dynamic verificationStatus = form[0].ToObject<ExpandoObject>(JsonHelper.GetJsonSerializer());
            List<Frapid.DataAccess.Models.CustomField> customFields = form[1].ToObject<List<Frapid.DataAccess.Models.CustomField>>(JsonHelper.GetJsonSerializer());

            if (verificationStatus == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.VerificationStatusRepository.AddOrEdit(verificationStatus, customFields);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Adds your instance of VerificationStatus class.
        /// </summary>
        /// <param name="verificationStatus">Your instance of verification statuses class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{verificationStatus}")]
        [Route("~/api/admission/verification-status/add/{verificationStatus}")]
        [Authorize]
        public void Add(Extems.Admission.Entities.VerificationStatus verificationStatus)
        {
            if (verificationStatus == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.VerificationStatusRepository.Add(verificationStatus);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Edits existing record with your instance of VerificationStatus class.
        /// </summary>
        /// <param name="verificationStatus">Your instance of VerificationStatus class to edit.</param>
        /// <param name="verificationStatusId">Enter the value for VerificationStatusId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{verificationStatusId}")]
        [Route("~/api/admission/verification-status/edit/{verificationStatusId}")]
        [Authorize]
        public void Edit(short verificationStatusId, [FromBody] Extems.Admission.Entities.VerificationStatus verificationStatus)
        {
            if (verificationStatus == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.VerificationStatusRepository.Update(verificationStatus, verificationStatusId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        private List<ExpandoObject> ParseCollection(JArray collection)
        {
            return JsonConvert.DeserializeObject<List<ExpandoObject>>(collection.ToString(), JsonHelper.GetJsonSerializerSettings());
        }

        /// <summary>
        ///     Adds or edits multiple instances of VerificationStatus class.
        /// </summary>
        /// <param name="collection">Your collection of VerificationStatus class to bulk import.</param>
        /// <returns>Returns list of imported verificationStatusIds.</returns>
        /// <exception cref="DataAccessException">Thrown when your any VerificationStatus class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("POST")]
        [Route("bulk-import")]
        [Route("~/api/admission/verification-status/bulk-import")]
        [Authorize]
        public List<object> BulkImport([FromBody]JArray collection)
        {
            List<ExpandoObject> verificationStatusCollection = this.ParseCollection(collection);

            if (verificationStatusCollection == null || verificationStatusCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.VerificationStatusRepository.BulkImport(verificationStatusCollection);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        /// <summary>
        ///     Deletes an existing instance of VerificationStatus class via VerificationStatusId.
        /// </summary>
        /// <param name="verificationStatusId">Enter the value for VerificationStatusId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{verificationStatusId}")]
        [Route("~/api/admission/verification-status/delete/{verificationStatusId}")]
        [Authorize]
        public void Delete(short verificationStatusId)
        {
            try
            {
                this.VerificationStatusRepository.Delete(verificationStatusId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }


    }
}