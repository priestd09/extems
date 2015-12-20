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
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Admissions.
    /// </summary>
    [RoutePrefix("api/v1.0/admission/admission")]
    public class AdmissionController : FrapidApiController
    {
        /// <summary>
        ///     The Admission repository.
        /// </summary>
        private readonly IAdmissionRepository AdmissionRepository;

        public AdmissionController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.To<long>();
            this._UserId = AppUsers.GetCurrent().View.UserId.To<int>();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.To<int>();
            this._Catalog = AppUsers.GetCatalog();

            this.AdmissionRepository = new Extems.Admission.DataAccess.Admission
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public AdmissionController(IAdmissionRepository repository, string catalog, LoginView view)
        {
            this._LoginId = view.LoginId.To<long>();
            this._UserId = view.UserId.To<int>();
            this._OfficeId = view.OfficeId.To<int>();
            this._Catalog = catalog;

            this.AdmissionRepository = repository;
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "admission" entity.
        /// </summary>
        /// <returns>Returns the "admission" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/admission/admission/meta")]
        [Authorize]
        public EntityView GetEntityView()
        {
            if (this._LoginId == 0)
            {
                return new EntityView();
            }

            return new EntityView
            {
                PrimaryKey = "admission_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "admission_id",  PropertyName = "AdmissionId",  DataType = "long",  DbDataType = "int8",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "admission_application_id",  PropertyName = "AdmissionApplicationId",  DataType = "long",  DbDataType = "int8",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "admission_date",  PropertyName = "AdmissionDate",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "office_id",  PropertyName = "OfficeId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "batch_id",  PropertyName = "BatchId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "class_id",  PropertyName = "ClassId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "house_id",  PropertyName = "HouseId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "is_active",  PropertyName = "IsActive",  DataType = "bool",  DbDataType = "bool",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of admissions.
        /// </summary>
        /// <returns>Returns the count of the admissions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/admission/admission/count")]
        [Authorize]
        public long Count()
        {
            try
            {
                return this.AdmissionRepository.Count();
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
        ///     Returns all collection of admission.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("all")]
        [Route("~/api/admission/admission/all")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> GetAll()
        {
            try
            {
                return this.AdmissionRepository.GetAll();
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
        ///     Returns collection of admission for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/admission/admission/export")]
        [Authorize]
        public IEnumerable<dynamic> Export()
        {
            try
            {
                return this.AdmissionRepository.Export();
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
        ///     Returns an instance of admission.
        /// </summary>
        /// <param name="admissionId">Enter AdmissionId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{admissionId}")]
        [Route("~/api/admission/admission/{admissionId}")]
        [Authorize]
        public Extems.Admission.Entities.Admission Get(long admissionId)
        {
            try
            {
                return this.AdmissionRepository.Get(admissionId);
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
        [Route("~/api/admission/admission/get")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> Get([FromUri] long[] admissionIds)
        {
            try
            {
                return this.AdmissionRepository.Get(admissionIds);
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
        ///     Returns the first instance of admission.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("first")]
        [Route("~/api/admission/admission/first")]
        [Authorize]
        public Extems.Admission.Entities.Admission GetFirst()
        {
            try
            {
                return this.AdmissionRepository.GetFirst();
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
        ///     Returns the previous instance of admission.
        /// </summary>
        /// <param name="admissionId">Enter AdmissionId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("previous/{admissionId}")]
        [Route("~/api/admission/admission/previous/{admissionId}")]
        [Authorize]
        public Extems.Admission.Entities.Admission GetPrevious(long admissionId)
        {
            try
            {
                return this.AdmissionRepository.GetPrevious(admissionId);
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
        ///     Returns the next instance of admission.
        /// </summary>
        /// <param name="admissionId">Enter AdmissionId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("next/{admissionId}")]
        [Route("~/api/admission/admission/next/{admissionId}")]
        [Authorize]
        public Extems.Admission.Entities.Admission GetNext(long admissionId)
        {
            try
            {
                return this.AdmissionRepository.GetNext(admissionId);
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
        ///     Returns the last instance of admission.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("last")]
        [Route("~/api/admission/admission/last")]
        [Authorize]
        public Extems.Admission.Entities.Admission GetLast()
        {
            try
            {
                return this.AdmissionRepository.GetLast();
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
        ///     Creates a paginated collection containing 10 admissions on each page, sorted by the property AdmissionId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/admission/admission")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult()
        {
            try
            {
                return this.AdmissionRepository.GetPaginatedResult();
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
        ///     Creates a paginated collection containing 10 admissions on each page, sorted by the property AdmissionId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/admission/admission/page/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult(long pageNumber)
        {
            try
            {
                return this.AdmissionRepository.GetPaginatedResult(pageNumber);
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
        ///     Counts the number of admissions using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered admissions.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/admission/admission/count-where")]
        [Authorize]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.AdmissionRepository.CountWhere(f);
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
        ///     Creates a filtered and paginated collection containing 10 admissions on each page, sorted by the property AdmissionId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/admission/admission/get-where/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.AdmissionRepository.GetWhere(pageNumber, f);
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
        ///     Counts the number of admissions using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered admissions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/admission/admission/count-filtered/{filterName}")]
        [Authorize]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.AdmissionRepository.CountFiltered(filterName);
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
        ///     Creates a filtered and paginated collection containing 10 admissions on each page, sorted by the property AdmissionId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/admission/admission/get-filtered/{pageNumber}/{filterName}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.Admission> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.AdmissionRepository.GetFiltered(pageNumber, filterName);
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
        ///     Displayfield is a lightweight key/value collection of admissions.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of admissions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/admission/admission/display-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            try
            {
                return this.AdmissionRepository.GetDisplayFields();
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
        ///     A custom field is a user defined field for admissions.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of admissions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/admission/admission/custom-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            try
            {
                return this.AdmissionRepository.GetCustomFields(null);
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
        ///     A custom field is a user defined field for admissions.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of admissions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/admission/admission/custom-fields/{resourceId}")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.AdmissionRepository.GetCustomFields(resourceId);
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
        ///     Adds or edits your instance of Admission class.
        /// </summary>
        /// <param name="admission">Your instance of admissions class to add or edit.</param>
        [AcceptVerbs("POST")]
        [Route("add-or-edit")]
        [Route("~/api/admission/admission/add-or-edit")]
        [Authorize]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            dynamic admission = form[0].ToObject<ExpandoObject>(JsonHelper.GetJsonSerializer());
            List<Frapid.DataAccess.Models.CustomField> customFields = form[1].ToObject<List<Frapid.DataAccess.Models.CustomField>>(JsonHelper.GetJsonSerializer());

            if (admission == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.AdmissionRepository.AddOrEdit(admission, customFields);
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
        ///     Adds your instance of Admission class.
        /// </summary>
        /// <param name="admission">Your instance of admissions class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{admission}")]
        [Route("~/api/admission/admission/add/{admission}")]
        [Authorize]
        public void Add(Extems.Admission.Entities.Admission admission)
        {
            if (admission == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.AdmissionRepository.Add(admission);
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
        ///     Edits existing record with your instance of Admission class.
        /// </summary>
        /// <param name="admission">Your instance of Admission class to edit.</param>
        /// <param name="admissionId">Enter the value for AdmissionId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{admissionId}")]
        [Route("~/api/admission/admission/edit/{admissionId}")]
        [Authorize]
        public void Edit(long admissionId, [FromBody] Extems.Admission.Entities.Admission admission)
        {
            if (admission == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.AdmissionRepository.Update(admission, admissionId);
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
        ///     Adds or edits multiple instances of Admission class.
        /// </summary>
        /// <param name="collection">Your collection of Admission class to bulk import.</param>
        /// <returns>Returns list of imported admissionIds.</returns>
        /// <exception cref="DataAccessException">Thrown when your any Admission class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("POST")]
        [Route("bulk-import")]
        [Route("~/api/admission/admission/bulk-import")]
        [Authorize]
        public List<object> BulkImport([FromBody]JArray collection)
        {
            List<ExpandoObject> admissionCollection = this.ParseCollection(collection);

            if (admissionCollection == null || admissionCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.AdmissionRepository.BulkImport(admissionCollection);
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
        ///     Deletes an existing instance of Admission class via AdmissionId.
        /// </summary>
        /// <param name="admissionId">Enter the value for AdmissionId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{admissionId}")]
        [Route("~/api/admission/admission/delete/{admissionId}")]
        [Authorize]
        public void Delete(long admissionId)
        {
            try
            {
                this.AdmissionRepository.Delete(admissionId);
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