// ReSharper disable All
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using Frapid.Configuration;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using Frapid.DbPolicy;
using Frapid.Framework.Extensions;
using Npgsql;
using Frapid.NPoco;
using Serilog;

namespace Extems.Admission.DataAccess
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "admission.fee_types".
    /// </summary>
    public class FeeType : DbAccess, IFeeTypeRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "admission".
        /// </summary>
        public override string _ObjectNamespace => "admission";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "fee_types".
        /// </summary>
        public override string _ObjectName => "fee_types";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
        public long _LoginId { get; set; }

        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Performs SQL count on the table "admission.fee_types".
        /// </summary>
        /// <returns>Returns the number of rows of the table "admission.fee_types".</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Count()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"FeeType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM admission.fee_types;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.fee_types" to return all instances of the "FeeType" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> GetAll()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"FeeType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.fee_types" to return all instances of the "FeeType" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<dynamic> Export()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"FeeType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.fee_types" with a where filter on the column "fee_type_id" to return a single instance of the "FeeType" class. 
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.FeeType Get(int feeTypeId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"FeeType\" filtered by \"FeeTypeId\" with value {FeeTypeId} was denied to the user with Login ID {_LoginId}", feeTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types WHERE fee_type_id=@0;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql, feeTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first record of the table "admission.fee_types". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.FeeType GetFirst()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the first record of entity \"FeeType\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Gets the previous record of the table "admission.fee_types" sorted by feeTypeId.
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.FeeType GetPrevious(int feeTypeId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the previous entity of \"FeeType\" by \"FeeTypeId\" with value {FeeTypeId} was denied to the user with Login ID {_LoginId}", feeTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types WHERE fee_type_id < @0 ORDER BY fee_type_id DESC LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql, feeTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the next record of the table "admission.fee_types" sorted by feeTypeId.
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.FeeType GetNext(int feeTypeId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the next entity of \"FeeType\" by \"FeeTypeId\" with value {FeeTypeId} was denied to the user with Login ID {_LoginId}", feeTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types WHERE fee_type_id > @0 ORDER BY fee_type_id LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql, feeTypeId).FirstOrDefault();
        }


        /// <summary>
        /// Gets the last record of the table "admission.fee_types". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.FeeType GetLast()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the last record of entity \"FeeType\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id DESC LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "admission.fee_types" with a where filter on the column "fee_type_id" to return a multiple instances of the "FeeType" class. 
        /// </summary>
        /// <param name="feeTypeIds">Array of column "fee_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "FeeType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> Get(int[] feeTypeIds)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to entity \"FeeType\" was denied to the user with Login ID {LoginId}. feeTypeIds: {feeTypeIds}.", this._LoginId, feeTypeIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types WHERE fee_type_id IN (@0);";

            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql, feeTypeIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for admission.fee_types.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table admission.fee_types</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get custom fields for entity \"FeeType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM config.custom_field_definition_view WHERE table_name='admission.fee_types' ORDER BY field_order;";
                return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from config.get_custom_field_definition('admission.fee_types'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of admission.fee_types.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table admission.fee_types</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            List<Frapid.DataAccess.Models.DisplayField> displayFields = new List<Frapid.DataAccess.Models.DisplayField>();

            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return displayFields;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"FeeType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT fee_type_id AS key, fee_type_code || ' (' || fee_type_name || ')' as value FROM admission.fee_types;";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                using (DataTable table = DbOperation.GetDataTable(this._Catalog, command))
                {
                    if (table?.Rows == null || table.Rows.Count == 0)
                    {
                        return displayFields;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        if (row != null)
                        {
                            DisplayField displayField = new DisplayField
                            {
                                Key = row["key"].ToString(),
                                Value = row["value"].ToString()
                            };

                            displayFields.Add(displayField);
                        }
                    }
                }
            }

            return displayFields;
        }

        /// <summary>
        /// Inserts or updates the instance of FeeType class on the database table "admission.fee_types".
        /// </summary>
        /// <param name="feeType">The instance of "FeeType" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic feeType, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            feeType.audit_user_id = this._UserId;
            feeType.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = feeType.fee_type_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                this.Update(feeType, Cast.To<int>(primaryKeyValue));
            }
            else
            {
                primaryKeyValue = this.Add(feeType);
            }

            string sql = "DELETE FROM config.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM config.custom_field_setup " +
                         "WHERE form_name=config.get_custom_field_form_name('admission.fee_types')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO config.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT config.get_custom_field_setup_id_by_table_name('admission.fee_types', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of FeeType class on the database table "admission.fee_types".
        /// </summary>
        /// <param name="feeType">The instance of "FeeType" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic feeType)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"FeeType\" was denied to the user with Login ID {LoginId}. {FeeType}", this._LoginId, feeType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, feeType, "admission.fee_types", "fee_type_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of FeeType class on the database table "admission.fee_types";
        /// </summary>
        /// <param name="feeTypes">List of "FeeType" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> feeTypes)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"FeeType\" was denied to the user with Login ID {LoginId}. {feeTypes}", this._LoginId, feeTypes);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            var result = new List<object>();
            int line = 0;
            try
            {
                using (Database db = new Database(ConnectionString.GetConnectionString(this._Catalog), Factory.ProviderName))
                {
                    using (ITransaction transaction = db.GetTransaction())
                    {
                        foreach (dynamic feeType in feeTypes)
                        {
                            line++;

                            feeType.audit_user_id = this._UserId;
                            feeType.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = feeType.fee_type_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(feeType.fee_type_id);
                                db.Update("admission.fee_types", "fee_type_id", feeType, feeType.fee_type_id);
                            }
                            else
                            {
                                result.Add(db.Insert("admission.fee_types", "fee_type_id", feeType));
                            }
                        }

                        transaction.Complete();
                    }

                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                string errorMessage = $"Error on line {line} ";

                if (ex.Code.StartsWith("P"))
                {
                    errorMessage += Factory.GetDbErrorResource(ex);

                    throw new DataAccessException(errorMessage, ex);
                }

                errorMessage += ex.Message;
                throw new DataAccessException(errorMessage, ex);
            }
            catch (System.Exception ex)
            {
                string errorMessage = $"Error on line {line} ";
                throw new DataAccessException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Updates the row of the table "admission.fee_types" with an instance of "FeeType" class against the primary key value.
        /// </summary>
        /// <param name="feeType">The instance of "FeeType" class to update.</param>
        /// <param name="feeTypeId">The value of the column "fee_type_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic feeType, int feeTypeId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"FeeType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {FeeType}", feeTypeId, this._LoginId, feeType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, feeType, feeTypeId, "admission.fee_types", "fee_type_id");
        }

        /// <summary>
        /// Deletes the row of the table "admission.fee_types" against the primary key value.
        /// </summary>
        /// <param name="feeTypeId">The value of the column "fee_type_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int feeTypeId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"FeeType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", feeTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM admission.fee_types WHERE fee_type_id=@0;";
            Factory.NonQuery(this._Catalog, sql, feeTypeId);
        }

        /// <summary>
        /// Performs a select statement on table "admission.fee_types" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"FeeType\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id LIMIT 10 OFFSET 0;";
            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "admission.fee_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult(long pageNumber)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"FeeType\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM admission.fee_types ORDER BY fee_type_id LIMIT 10 OFFSET @0;";

            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql, offset);
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM config.filters WHERE object_name='admission.fee_types' AND lower(filter_name)=lower(@0);";
            return Factory.Get<Frapid.DataAccess.Models.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "admission.fee_types".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "FeeType" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"FeeType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM admission.fee_types WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.FeeType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "admission.fee_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"FeeType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM admission.fee_types WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.FeeType(), filters);

            sql.OrderBy("fee_type_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "admission.fee_types".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "FeeType" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountFiltered(string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"FeeType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM admission.fee_types WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.FeeType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "admission.fee_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "FeeType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.FeeType> GetFiltered(long pageNumber, string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"FeeType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM admission.fee_types WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.FeeType(), filters);

            sql.OrderBy("fee_type_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Admission.Entities.FeeType>(this._Catalog, sql);
        }


    }
}