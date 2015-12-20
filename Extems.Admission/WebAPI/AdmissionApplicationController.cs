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
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Admission Applications.
    /// </summary>
    [RoutePrefix("api/v1.0/admission/admission-application")]
    public class AdmissionApplicationController : FrapidApiController
    {
        /// <summary>
        ///     The AdmissionApplication repository.
        /// </summary>
        private readonly IAdmissionApplicationRepository AdmissionApplicationRepository;

        public AdmissionApplicationController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.To<long>();
            this._UserId = AppUsers.GetCurrent().View.UserId.To<int>();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.To<int>();
            this._Catalog = AppUsers.GetCatalog();

            this.AdmissionApplicationRepository = new Extems.Admission.DataAccess.AdmissionApplication
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public AdmissionApplicationController(IAdmissionApplicationRepository repository, string catalog, LoginView view)
        {
            this._LoginId = view.LoginId.To<long>();
            this._UserId = view.UserId.To<int>();
            this._OfficeId = view.OfficeId.To<int>();
            this._Catalog = catalog;

            this.AdmissionApplicationRepository = repository;
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "admission application" entity.
        /// </summary>
        /// <returns>Returns the "admission application" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/admission/admission-application/meta")]
        [Authorize]
        public EntityView GetEntityView()
        {
            if (this._LoginId == 0)
            {
                return new EntityView();
            }

            return new EntityView
            {
                PrimaryKey = "admission_application_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "admission_application_id",  PropertyName = "AdmissionApplicationId",  DataType = "long",  DbDataType = "int8",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "office_id",  PropertyName = "OfficeId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "date_of_application",  PropertyName = "DateOfApplication",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "first_name",  PropertyName = "FirstName",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 50 },
                                        new EntityColumn { ColumnName = "middle_name",  PropertyName = "MiddleName",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 50 },
                                        new EntityColumn { ColumnName = "last_name",  PropertyName = "LastName",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 50 },
                                        new EntityColumn { ColumnName = "photo",  PropertyName = "Photo",  DataType = "string",  DbDataType = "image",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "zip_code",  PropertyName = "ZipCode",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "address_line_1",  PropertyName = "AddressLine1",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "address_line_2",  PropertyName = "AddressLine2",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "street",  PropertyName = "Street",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "city",  PropertyName = "City",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "state",  PropertyName = "State",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "country_id",  PropertyName = "CountryId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "phone_home",  PropertyName = "PhoneHome",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "phone_cell",  PropertyName = "PhoneCell",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "email_address",  PropertyName = "EmailAddress",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "date_of_birth",  PropertyName = "DateOfBirth",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "gender_id",  PropertyName = "GenderId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "blood_group_id",  PropertyName = "BloodGroupId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "other_details",  PropertyName = "OtherDetails",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 250 },
                                        new EntityColumn { ColumnName = "course_id",  PropertyName = "CourseId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "batch_id",  PropertyName = "BatchId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "last_institution_name",  PropertyName = "LastInstitutionName",  DataType = "string",  DbDataType = "text",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "passed_year",  PropertyName = "PassedYear",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "grade_obtained",  PropertyName = "GradeObtained",  DataType = "string",  DbDataType = "varchar",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 20 },
                                        new EntityColumn { ColumnName = "percentage_obtained",  PropertyName = "PercentageObtained",  DataType = "decimal",  DbDataType = "decimal_strict",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "apply_for_scholorship",  PropertyName = "ApplyForScholorship",  DataType = "bool",  DbDataType = "bool",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "last_verified_on",  PropertyName = "LastVerifiedOn",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verified_by_user_id",  PropertyName = "VerifiedByUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verification_status_id",  PropertyName = "VerificationStatusId",  DataType = "short",  DbDataType = "int2",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "verification_reason",  PropertyName = "VerificationReason",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "is_addmitted",  PropertyName = "IsAddmitted",  DataType = "bool",  DbDataType = "bool",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of admission applications.
        /// </summary>
        /// <returns>Returns the count of the admission applications.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/admission/admission-application/count")]
        [Authorize]
        public long Count()
        {
            try
            {
                return this.AdmissionApplicationRepository.Count();
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
        ///     Returns all collection of admission application.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("all")]
        [Route("~/api/admission/admission-application/all")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetAll()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetAll();
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
        ///     Returns collection of admission application for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/admission/admission-application/export")]
        [Authorize]
        public IEnumerable<dynamic> Export()
        {
            try
            {
                return this.AdmissionApplicationRepository.Export();
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
        ///     Returns an instance of admission application.
        /// </summary>
        /// <param name="admissionApplicationId">Enter AdmissionApplicationId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{admissionApplicationId}")]
        [Route("~/api/admission/admission-application/{admissionApplicationId}")]
        [Authorize]
        public Extems.Admission.Entities.AdmissionApplication Get(long admissionApplicationId)
        {
            try
            {
                return this.AdmissionApplicationRepository.Get(admissionApplicationId);
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
        [Route("~/api/admission/admission-application/get")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> Get([FromUri] long[] admissionApplicationIds)
        {
            try
            {
                return this.AdmissionApplicationRepository.Get(admissionApplicationIds);
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
        ///     Returns the first instance of admission application.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("first")]
        [Route("~/api/admission/admission-application/first")]
        [Authorize]
        public Extems.Admission.Entities.AdmissionApplication GetFirst()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetFirst();
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
        ///     Returns the previous instance of admission application.
        /// </summary>
        /// <param name="admissionApplicationId">Enter AdmissionApplicationId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("previous/{admissionApplicationId}")]
        [Route("~/api/admission/admission-application/previous/{admissionApplicationId}")]
        [Authorize]
        public Extems.Admission.Entities.AdmissionApplication GetPrevious(long admissionApplicationId)
        {
            try
            {
                return this.AdmissionApplicationRepository.GetPrevious(admissionApplicationId);
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
        ///     Returns the next instance of admission application.
        /// </summary>
        /// <param name="admissionApplicationId">Enter AdmissionApplicationId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("next/{admissionApplicationId}")]
        [Route("~/api/admission/admission-application/next/{admissionApplicationId}")]
        [Authorize]
        public Extems.Admission.Entities.AdmissionApplication GetNext(long admissionApplicationId)
        {
            try
            {
                return this.AdmissionApplicationRepository.GetNext(admissionApplicationId);
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
        ///     Returns the last instance of admission application.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("last")]
        [Route("~/api/admission/admission-application/last")]
        [Authorize]
        public Extems.Admission.Entities.AdmissionApplication GetLast()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetLast();
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
        ///     Creates a paginated collection containing 10 admission applications on each page, sorted by the property AdmissionApplicationId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/admission/admission-application")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetPaginatedResult();
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
        ///     Creates a paginated collection containing 10 admission applications on each page, sorted by the property AdmissionApplicationId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/admission/admission-application/page/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult(long pageNumber)
        {
            try
            {
                return this.AdmissionApplicationRepository.GetPaginatedResult(pageNumber);
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
        ///     Counts the number of admission applications using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered admission applications.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/admission/admission-application/count-where")]
        [Authorize]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.AdmissionApplicationRepository.CountWhere(f);
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
        ///     Creates a filtered and paginated collection containing 10 admission applications on each page, sorted by the property AdmissionApplicationId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/admission/admission-application/get-where/{pageNumber}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<Frapid.DataAccess.Models.Filter> f = filters.ToObject<List<Frapid.DataAccess.Models.Filter>>(JsonHelper.GetJsonSerializer());
                return this.AdmissionApplicationRepository.GetWhere(pageNumber, f);
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
        ///     Counts the number of admission applications using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered admission applications.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/admission/admission-application/count-filtered/{filterName}")]
        [Authorize]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.AdmissionApplicationRepository.CountFiltered(filterName);
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
        ///     Creates a filtered and paginated collection containing 10 admission applications on each page, sorted by the property AdmissionApplicationId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/admission/admission-application/get-filtered/{pageNumber}/{filterName}")]
        [Authorize]
        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.AdmissionApplicationRepository.GetFiltered(pageNumber, filterName);
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
        ///     Displayfield is a lightweight key/value collection of admission applications.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of admission applications.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/admission/admission-application/display-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetDisplayFields();
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
        ///     A custom field is a user defined field for admission applications.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of admission applications.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/admission/admission-application/custom-fields")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            try
            {
                return this.AdmissionApplicationRepository.GetCustomFields(null);
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
        ///     A custom field is a user defined field for admission applications.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of admission applications.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/admission/admission-application/custom-fields/{resourceId}")]
        [Authorize]
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.AdmissionApplicationRepository.GetCustomFields(resourceId);
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
        ///     Adds or edits your instance of AdmissionApplication class.
        /// </summary>
        /// <param name="admissionApplication">Your instance of admission applications class to add or edit.</param>
        [AcceptVerbs("POST")]
        [Route("add-or-edit")]
        [Route("~/api/admission/admission-application/add-or-edit")]
        [Authorize]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            dynamic admissionApplication = form[0].ToObject<ExpandoObject>(JsonHelper.GetJsonSerializer());
            List<Frapid.DataAccess.Models.CustomField> customFields = form[1].ToObject<List<Frapid.DataAccess.Models.CustomField>>(JsonHelper.GetJsonSerializer());

            if (admissionApplication == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.AdmissionApplicationRepository.AddOrEdit(admissionApplication, customFields);
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
        ///     Adds your instance of AdmissionApplication class.
        /// </summary>
        /// <param name="admissionApplication">Your instance of admission applications class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{admissionApplication}")]
        [Route("~/api/admission/admission-application/add/{admissionApplication}")]
        [Authorize]
        public void Add(Extems.Admission.Entities.AdmissionApplication admissionApplication)
        {
            if (admissionApplication == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.AdmissionApplicationRepository.Add(admissionApplication);
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
        ///     Edits existing record with your instance of AdmissionApplication class.
        /// </summary>
        /// <param name="admissionApplication">Your instance of AdmissionApplication class to edit.</param>
        /// <param name="admissionApplicationId">Enter the value for AdmissionApplicationId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{admissionApplicationId}")]
        [Route("~/api/admission/admission-application/edit/{admissionApplicationId}")]
        [Authorize]
        public void Edit(long admissionApplicationId, [FromBody] Extems.Admission.Entities.AdmissionApplication admissionApplication)
        {
            if (admissionApplication == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.AdmissionApplicationRepository.Update(admissionApplication, admissionApplicationId);
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
        ///     Adds or edits multiple instances of AdmissionApplication class.
        /// </summary>
        /// <param name="collection">Your collection of AdmissionApplication class to bulk import.</param>
        /// <returns>Returns list of imported admissionApplicationIds.</returns>
        /// <exception cref="DataAccessException">Thrown when your any AdmissionApplication class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("POST")]
        [Route("bulk-import")]
        [Route("~/api/admission/admission-application/bulk-import")]
        [Authorize]
        public List<object> BulkImport([FromBody]JArray collection)
        {
            List<ExpandoObject> admissionApplicationCollection = this.ParseCollection(collection);

            if (admissionApplicationCollection == null || admissionApplicationCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.AdmissionApplicationRepository.BulkImport(admissionApplicationCollection);
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
        ///     Deletes an existing instance of AdmissionApplication class via AdmissionApplicationId.
        /// </summary>
        /// <param name="admissionApplicationId">Enter the value for AdmissionApplicationId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{admissionApplicationId}")]
        [Route("~/api/admission/admission-application/delete/{admissionApplicationId}")]
        [Authorize]
        public void Delete(long admissionApplicationId)
        {
            try
            {
                this.AdmissionApplicationRepository.Delete(admissionApplicationId);
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
        ///     Verifies the admission application.
        /// </summary>
        /// <param name="admissionApplicationId">Enter the value for AdmissionApplicationId in order to approve or reject.</param>
        /// <param name="verificationStatusId">Provide verification status id code to approve or reject this admission application.</param>
        /// <param name="reason">Provide the reason why you are approving or rejecting this admission application.</param>
        [AcceptVerbs("PUT")]
        [Route("verify/{admissionApplicationId}/{verificationStatusId}/{reason}")]
        [Route("~/api/admission/admission-application/verify/{admissionApplicationId}/{verificationStatusId}/{reason}")]
        [Authorize]
        public void Verifiy(long admissionApplicationId, short verificationStatusId, string reason)
        {
            try
            {
                this.AdmissionApplicationRepository.Verify(admissionApplicationId, verificationStatusId, reason);
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