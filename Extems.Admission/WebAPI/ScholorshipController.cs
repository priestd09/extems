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
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Scholorships.
    /// </summary>
    [RoutePrefix("api/v1.0/admission/scholorship")]
    public class ScholorshipController : FrapidApiController
    {
        /// <summary>
        ///     The Scholorship repository.
        /// </summary>
        private readonly IScholorshipRepository ScholorshipRepository;

        public ScholorshipController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.To<long>();
            this._UserId = AppUsers.GetCurrent().View.UserId.To<int>();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.To<int>();
            this._Catalog = AppUsers.GetCatalog();

            this.ScholorshipRepository = new Extems.Admission.DataAccess.Scholorship
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public ScholorshipController(IScholorshipRepository repository, string catalog, LoginView view)
        {
            this._LoginId = view.LoginId.To<long>();
            this._UserId = view.UserId.To<int>();
            this._OfficeId = view.OfficeId.To<int>();
            this._Catalog = catalog;

            this.ScholorshipRepository = repository;
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "scholorship" entity.
        /// </summary>
        /// <returns>Returns the "scholorship" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/admission/scholorship/meta")]
        [Authorize]
        public EntityView GetEntityView()
        {
            if (this._LoginId == 0)
            {
                return new EntityView();
            }

            return new EntityView
            {
                PrimaryKey = "scholorship_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "scholorship_id",  PropertyName = "ScholorshipId",  DataType = "long",  DbDataType = "int8",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "admission_application_id",  PropertyName = "AdmissionApplicationId",  DataType = "long",  DbDataType = "int8",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "scholorship_type_id",  PropertyName = "ScholorshipTypeId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "last_verified_on",  PropertyName = "LastVerifiedOn",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verified_by_user_id",  PropertyName = "VerifiedByUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verification_status_id",  PropertyName = "VerificationStatusId",  DataType = "short",  DbDataType = "int2",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verification_reason",  PropertyName = "VerificationReason",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of scholorships.
        /// </summary>
        /// <returns>Returns the count of the scholorships.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/admission/scholorship/count")]
        [Authorize]
        public long Count()
        {
            try
            {
                return this.ScholorshipRepository.Count();
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
        ///     Returns all collection of scholorship.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("all")]
        [Route("~/api/admission/scholorship/all")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetAll()
        {
            try
            {
                return this.ScholorshipRepository.GetAll();
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
        ///     Returns collection of scholorship for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/admission/scholorship/export")]
        [Authorize]
        public IEnumerable<dynamic> Export()
        {
            try
            {
                return this.ScholorshipRepository.Export();
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
        ///     Returns an instance of scholorship.
        /// </summary>
        /// <param name="scholorshipId">Enter ScholorshipId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{scholorshipId}")]
        [Route("~/api/admission/scholorship/{scholorshipId}")]
        [Authorize]
        public Extems.Admission.Entities.Scholorship Get(long scholorshipId)
        {
            try
            {
                return this.ScholorshipRepository.Get(scholorshipId);
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
        [Route("~/api/admission/scholorship/get")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> Get([FromUri] long[] scholorshipIds)
        {
            try
            {
                return this.ScholorshipRepository.Get(scholorshipIds);
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
        ///     Returns the first instance of scholorship.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("first")]
        [Route("~/api/admission/scholorship/first")]
        [Authorize]
        public Extems.Admission.Entities.Scholorship GetFirst()
        {
            try
            {
                return this.ScholorshipRepository.GetFirst();
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
        ///     Returns the previous instance of scholorship.
        /// </summary>
        /// <param name="scholorshipId">Enter ScholorshipId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("previous/{scholorshipId}")]
        [Route("~/api/admission/scholorship/previous/{scholorshipId}")]
        [Authorize]
        public Extems.Admission.Entities.Scholorship GetPrevious(long scholorshipId)
        {
            try
            {
                return this.ScholorshipRepository.GetPrevious(scholorshipId);
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
        ///     Returns the next instance of scholorship.
        /// </summary>
        /// <param name="scholorshipId">Enter ScholorshipId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("next/{scholorshipId}")]
        [Route("~/api/admission/scholorship/next/{scholorshipId}")]
        [Authorize]
        public Extems.Admission.Entities.Scholorship GetNext(long scholorshipId)
        {
            try
            {
                return this.ScholorshipRepository.GetNext(scholorshipId);
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
        ///     Returns the last instance of scholorship.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("last")]
        [Route("~/api/admission/scholorship/last")]
        [Authorize]
        public Extems.Admission.Entities.Scholorship GetLast()
        {
            try
            {
                return this.ScholorshipRepository.GetLast();
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
        ///     Creates a paginated collection containing 10 scholorships on each page, sorted by the property ScholorshipId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/admission/scholorship")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult()
        {
            try
            {
                return this.ScholorshipRepository.GetPaginatedResult();
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
        ///     Creates a paginated collection containing 10 scholorships on each page, sorted by the property ScholorshipId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/admission/scholorship/page/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult(long pageNumber)
        {
            try
            {
                return this.ScholorshipRepository.GetPaginatedResult(pageNumber);
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
        ///     Counts the number of scholorships using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered scholorships.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/admission/scholorship/count-where")]
        [Authorize]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ScholorshipRepository.CountWhere(f);
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
        ///     Creates a filtered and paginated collection containing 10 scholorships on each page, sorted by the property ScholorshipId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/admission/scholorship/get-where/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ScholorshipRepository.GetWhere(pageNumber, f);
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
        ///     Counts the number of scholorships using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered scholorships.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/admission/scholorship/count-filtered/{filterName}")]
        [Authorize]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.ScholorshipRepository.CountFiltered(filterName);
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
        ///     Creates a filtered and paginated collection containing 10 scholorships on each page, sorted by the property ScholorshipId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/admission/scholorship/get-filtered/{pageNumber}/{filterName}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.ScholorshipRepository.GetFiltered(pageNumber, filterName);
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
        ///     Displayfield is a lightweight key/value collection of scholorships.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of scholorships.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/admission/scholorship/display-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            try
            {
                return this.ScholorshipRepository.GetDisplayFields();
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
        ///     A custom field is a user defined field for scholorships.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of scholorships.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/admission/scholorship/custom-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            try
            {
                return this.ScholorshipRepository.GetCustomFields(null);
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
        ///     A custom field is a user defined field for scholorships.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of scholorships.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/admission/scholorship/custom-fields/{resourceId}")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.ScholorshipRepository.GetCustomFields(resourceId);
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
        ///     Adds or edits your instance of Scholorship class.
        /// </summary>
        /// <param name="scholorship">Your instance of scholorships class to add or edit.</param>
        [AcceptVerbs("POST")]
        [Route("add-or-edit")]
        [Route("~/api/admission/scholorship/add-or-edit")]
        [Authorize]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            dynamic scholorship = form[0].ToObject<ExpandoObject>(JsonHelper.GetJsonSerializer());
            List<Frapid.DataAccess.Models.CustomField> customFields = form[1].ToObject<List<Frapid.DataAccess.Models.CustomField>>(JsonHelper.GetJsonSerializer());

            if (scholorship == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.ScholorshipRepository.AddOrEdit(scholorship, customFields);
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
        ///     Adds your instance of Scholorship class.
        /// </summary>
        /// <param name="scholorship">Your instance of scholorships class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{scholorship}")]
        [Route("~/api/admission/scholorship/add/{scholorship}")]
        [Authorize]
        public void Add(Extems.Admission.Entities.Scholorship scholorship)
        {
            if (scholorship == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.ScholorshipRepository.Add(scholorship);
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
        ///     Edits existing record with your instance of Scholorship class.
        /// </summary>
        /// <param name="scholorship">Your instance of Scholorship class to edit.</param>
        /// <param name="scholorshipId">Enter the value for ScholorshipId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{scholorshipId}")]
        [Route("~/api/admission/scholorship/edit/{scholorshipId}")]
        [Authorize]
        public void Edit(long scholorshipId, [FromBody] Extems.Admission.Entities.Scholorship scholorship)
        {
            if (scholorship == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.ScholorshipRepository.Update(scholorship, scholorshipId);
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
        ///     Adds or edits multiple instances of Scholorship class.
        /// </summary>
        /// <param name="collection">Your collection of Scholorship class to bulk import.</param>
        /// <returns>Returns list of imported scholorshipIds.</returns>
        /// <exception cref="DataAccessException">Thrown when your any Scholorship class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("POST")]
        [Route("bulk-import")]
        [Route("~/api/admission/scholorship/bulk-import")]
        [Authorize]
        public List<object> BulkImport([FromBody]JArray collection)
        {
            List<ExpandoObject> scholorshipCollection = this.ParseCollection(collection);

            if (scholorshipCollection == null || scholorshipCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.ScholorshipRepository.BulkImport(scholorshipCollection);
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
        ///     Deletes an existing instance of Scholorship class via ScholorshipId.
        /// </summary>
        /// <param name="scholorshipId">Enter the value for ScholorshipId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{scholorshipId}")]
        [Route("~/api/admission/scholorship/delete/{scholorshipId}")]
        [Authorize]
        public void Delete(long scholorshipId)
        {
            try
            {
                this.ScholorshipRepository.Delete(scholorshipId);
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
        ///     Verifies the scholorship.
        /// </summary>
        /// <param name="scholorshipId">Enter the value for ScholorshipId in order to approve or reject.</param>
        /// <param name="verificationStatusId">Provide verification status id code to approve or reject this scholorship.</param>
        /// <param name="reason">Provide the reason why you are approving or rejecting this scholorship.</param>
        [AcceptVerbs("PUT")]
        [Route("verify/{scholorshipId}/{verificationStatusId}/{reason}")]
        [Route("~/api/admission/scholorship/verify/{scholorshipId}/{verificationStatusId}/{reason}")]
        [Authorize]
        public void Verifiy(long scholorshipId, short verificationStatusId, string reason)
        {
            try
            {
                this.ScholorshipRepository.Verify(scholorshipId, verificationStatusId, reason);
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