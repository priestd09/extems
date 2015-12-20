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
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Scholorship Type Details.
    /// </summary>
    [RoutePrefix("api/v1.0/admission/scholorship-type-detail")]
    public class ScholorshipTypeDetailController : FrapidApiController
    {
        /// <summary>
        ///     The ScholorshipTypeDetail repository.
        /// </summary>
        private readonly IScholorshipTypeDetailRepository ScholorshipTypeDetailRepository;

        public ScholorshipTypeDetailController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.To<long>();
            this._UserId = AppUsers.GetCurrent().View.UserId.To<int>();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.To<int>();
            this._Catalog = AppUsers.GetCatalog();

            this.ScholorshipTypeDetailRepository = new Extems.Admission.DataAccess.ScholorshipTypeDetail
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public ScholorshipTypeDetailController(IScholorshipTypeDetailRepository repository, string catalog, LoginView view)
        {
            this._LoginId = view.LoginId.To<long>();
            this._UserId = view.UserId.To<int>();
            this._OfficeId = view.OfficeId.To<int>();
            this._Catalog = catalog;

            this.ScholorshipTypeDetailRepository = repository;
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "scholorship type detail" entity.
        /// </summary>
        /// <returns>Returns the "scholorship type detail" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/admission/scholorship-type-detail/meta")]
        [Authorize]
        public EntityView GetEntityView()
        {
            if (this._LoginId == 0)
            {
                return new EntityView();
            }

            return new EntityView
            {
                PrimaryKey = "scholorship_type_detail_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "scholorship_type_detail_id",  PropertyName = "ScholorshipTypeDetailId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "scholorship_type_id",  PropertyName = "ScholorshipTypeId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "fee_type_id",  PropertyName = "FeeTypeId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "discount_percentage",  PropertyName = "DiscountPercentage",  DataType = "decimal",  DbDataType = "decimal_strict",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of scholorship type details.
        /// </summary>
        /// <returns>Returns the count of the scholorship type details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/admission/scholorship-type-detail/count")]
        [Authorize]
        public long Count()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.Count();
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
        ///     Returns all collection of scholorship type detail.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("all")]
        [Route("~/api/admission/scholorship-type-detail/all")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetAll()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetAll();
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
        ///     Returns collection of scholorship type detail for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/admission/scholorship-type-detail/export")]
        [Authorize]
        public IEnumerable<dynamic> Export()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.Export();
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
        ///     Returns an instance of scholorship type detail.
        /// </summary>
        /// <param name="scholorshipTypeDetailId">Enter ScholorshipTypeDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{scholorshipTypeDetailId}")]
        [Route("~/api/admission/scholorship-type-detail/{scholorshipTypeDetailId}")]
        [Authorize]
        public Extems.Admission.Entities.ScholorshipTypeDetail Get(int scholorshipTypeDetailId)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.Get(scholorshipTypeDetailId);
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
        [Route("~/api/admission/scholorship-type-detail/get")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> Get([FromUri] int[] scholorshipTypeDetailIds)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.Get(scholorshipTypeDetailIds);
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
        ///     Returns the first instance of scholorship type detail.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("first")]
        [Route("~/api/admission/scholorship-type-detail/first")]
        [Authorize]
        public Extems.Admission.Entities.ScholorshipTypeDetail GetFirst()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetFirst();
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
        ///     Returns the previous instance of scholorship type detail.
        /// </summary>
        /// <param name="scholorshipTypeDetailId">Enter ScholorshipTypeDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("previous/{scholorshipTypeDetailId}")]
        [Route("~/api/admission/scholorship-type-detail/previous/{scholorshipTypeDetailId}")]
        [Authorize]
        public Extems.Admission.Entities.ScholorshipTypeDetail GetPrevious(int scholorshipTypeDetailId)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetPrevious(scholorshipTypeDetailId);
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
        ///     Returns the next instance of scholorship type detail.
        /// </summary>
        /// <param name="scholorshipTypeDetailId">Enter ScholorshipTypeDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("next/{scholorshipTypeDetailId}")]
        [Route("~/api/admission/scholorship-type-detail/next/{scholorshipTypeDetailId}")]
        [Authorize]
        public Extems.Admission.Entities.ScholorshipTypeDetail GetNext(int scholorshipTypeDetailId)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetNext(scholorshipTypeDetailId);
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
        ///     Returns the last instance of scholorship type detail.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("last")]
        [Route("~/api/admission/scholorship-type-detail/last")]
        [Authorize]
        public Extems.Admission.Entities.ScholorshipTypeDetail GetLast()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetLast();
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
        ///     Creates a paginated collection containing 10 scholorship type details on each page, sorted by the property ScholorshipTypeDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/admission/scholorship-type-detail")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetPaginatedResult();
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
        ///     Creates a paginated collection containing 10 scholorship type details on each page, sorted by the property ScholorshipTypeDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/admission/scholorship-type-detail/page/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult(long pageNumber)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetPaginatedResult(pageNumber);
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
        ///     Counts the number of scholorship type details using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered scholorship type details.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/admission/scholorship-type-detail/count-where")]
        [Authorize]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ScholorshipTypeDetailRepository.CountWhere(f);
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
        ///     Creates a filtered and paginated collection containing 10 scholorship type details on each page, sorted by the property ScholorshipTypeDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/admission/scholorship-type-detail/get-where/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ScholorshipTypeDetailRepository.GetWhere(pageNumber, f);
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
        ///     Counts the number of scholorship type details using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered scholorship type details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/admission/scholorship-type-detail/count-filtered/{filterName}")]
        [Authorize]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.CountFiltered(filterName);
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
        ///     Creates a filtered and paginated collection containing 10 scholorship type details on each page, sorted by the property ScholorshipTypeDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/admission/scholorship-type-detail/get-filtered/{pageNumber}/{filterName}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetFiltered(pageNumber, filterName);
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
        ///     Displayfield is a lightweight key/value collection of scholorship type details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of scholorship type details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/admission/scholorship-type-detail/display-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetDisplayFields();
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
        ///     A custom field is a user defined field for scholorship type details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of scholorship type details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/admission/scholorship-type-detail/custom-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetCustomFields(null);
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
        ///     A custom field is a user defined field for scholorship type details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of scholorship type details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/admission/scholorship-type-detail/custom-fields/{resourceId}")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.ScholorshipTypeDetailRepository.GetCustomFields(resourceId);
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
        ///     Adds or edits your instance of ScholorshipTypeDetail class.
        /// </summary>
        /// <param name="scholorshipTypeDetail">Your instance of scholorship type details class to add or edit.</param>
        [AcceptVerbs("POST")]
        [Route("add-or-edit")]
        [Route("~/api/admission/scholorship-type-detail/add-or-edit")]
        [Authorize]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            dynamic scholorshipTypeDetail = form[0].ToObject<ExpandoObject>(JsonHelper.GetJsonSerializer());
            List<Frapid.DataAccess.Models.CustomField> customFields = form[1].ToObject<List<Frapid.DataAccess.Models.CustomField>>(JsonHelper.GetJsonSerializer());

            if (scholorshipTypeDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.ScholorshipTypeDetailRepository.AddOrEdit(scholorshipTypeDetail, customFields);
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
        ///     Adds your instance of ScholorshipTypeDetail class.
        /// </summary>
        /// <param name="scholorshipTypeDetail">Your instance of scholorship type details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{scholorshipTypeDetail}")]
        [Route("~/api/admission/scholorship-type-detail/add/{scholorshipTypeDetail}")]
        [Authorize]
        public void Add(Extems.Admission.Entities.ScholorshipTypeDetail scholorshipTypeDetail)
        {
            if (scholorshipTypeDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.ScholorshipTypeDetailRepository.Add(scholorshipTypeDetail);
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
        ///     Edits existing record with your instance of ScholorshipTypeDetail class.
        /// </summary>
        /// <param name="scholorshipTypeDetail">Your instance of ScholorshipTypeDetail class to edit.</param>
        /// <param name="scholorshipTypeDetailId">Enter the value for ScholorshipTypeDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{scholorshipTypeDetailId}")]
        [Route("~/api/admission/scholorship-type-detail/edit/{scholorshipTypeDetailId}")]
        [Authorize]
        public void Edit(int scholorshipTypeDetailId, [FromBody] Extems.Admission.Entities.ScholorshipTypeDetail scholorshipTypeDetail)
        {
            if (scholorshipTypeDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.ScholorshipTypeDetailRepository.Update(scholorshipTypeDetail, scholorshipTypeDetailId);
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
        ///     Adds or edits multiple instances of ScholorshipTypeDetail class.
        /// </summary>
        /// <param name="collection">Your collection of ScholorshipTypeDetail class to bulk import.</param>
        /// <returns>Returns list of imported scholorshipTypeDetailIds.</returns>
        /// <exception cref="DataAccessException">Thrown when your any ScholorshipTypeDetail class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("POST")]
        [Route("bulk-import")]
        [Route("~/api/admission/scholorship-type-detail/bulk-import")]
        [Authorize]
        public List<object> BulkImport([FromBody]JArray collection)
        {
            List<ExpandoObject> scholorshipTypeDetailCollection = this.ParseCollection(collection);

            if (scholorshipTypeDetailCollection == null || scholorshipTypeDetailCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.ScholorshipTypeDetailRepository.BulkImport(scholorshipTypeDetailCollection);
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
        ///     Deletes an existing instance of ScholorshipTypeDetail class via ScholorshipTypeDetailId.
        /// </summary>
        /// <param name="scholorshipTypeDetailId">Enter the value for ScholorshipTypeDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{scholorshipTypeDetailId}")]
        [Route("~/api/admission/scholorship-type-detail/delete/{scholorshipTypeDetailId}")]
        [Authorize]
        public void Delete(int scholorshipTypeDetailId)
        {
            try
            {
                this.ScholorshipTypeDetailRepository.Delete(scholorshipTypeDetailId);
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