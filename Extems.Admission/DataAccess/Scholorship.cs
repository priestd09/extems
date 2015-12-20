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
    /// Provides simplified data access features to perform SCRUD operation on the database table "admission.scholorships".
    /// </summary>
    public class Scholorship : DbAccess, IScholorshipRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "admission".
        /// </summary>
        public override string _ObjectNamespace => "admission";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "scholorships".
        /// </summary>
        public override string _ObjectName => "scholorships";

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
        /// Performs SQL count on the table "admission.scholorships".
        /// </summary>
        /// <returns>Returns the number of rows of the table "admission.scholorships".</returns>
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
                    Log.Information("Access to count entity \"Scholorship\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM admission.scholorships;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.scholorships" to return all instances of the "Scholorship" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "Scholorship" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetAll()
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
                    Log.Information("Access to the export entity \"Scholorship\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.scholorships" to return all instances of the "Scholorship" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "Scholorship" class.</returns>
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
                    Log.Information("Access to the export entity \"Scholorship\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "admission.scholorships" with a where filter on the column "scholorship_id" to return a single instance of the "Scholorship" class. 
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.Scholorship Get(long scholorshipId)
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
                    Log.Information("Access to the get entity \"Scholorship\" filtered by \"ScholorshipId\" with value {ScholorshipId} was denied to the user with Login ID {_LoginId}", scholorshipId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships WHERE scholorship_id=@0;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql, scholorshipId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first record of the table "admission.scholorships". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.Scholorship GetFirst()
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
                    Log.Information("Access to the get the first record of entity \"Scholorship\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Gets the previous record of the table "admission.scholorships" sorted by scholorshipId.
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.Scholorship GetPrevious(long scholorshipId)
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
                    Log.Information("Access to the get the previous entity of \"Scholorship\" by \"ScholorshipId\" with value {ScholorshipId} was denied to the user with Login ID {_LoginId}", scholorshipId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships WHERE scholorship_id < @0 ORDER BY scholorship_id DESC LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql, scholorshipId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the next record of the table "admission.scholorships" sorted by scholorshipId.
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.Scholorship GetNext(long scholorshipId)
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
                    Log.Information("Access to the get the next entity of \"Scholorship\" by \"ScholorshipId\" with value {ScholorshipId} was denied to the user with Login ID {_LoginId}", scholorshipId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships WHERE scholorship_id > @0 ORDER BY scholorship_id LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql, scholorshipId).FirstOrDefault();
        }


        /// <summary>
        /// Gets the last record of the table "admission.scholorships". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Admission.Entities.Scholorship GetLast()
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
                    Log.Information("Access to the get the last record of entity \"Scholorship\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id DESC LIMIT 1;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "admission.scholorships" with a where filter on the column "scholorship_id" to return a multiple instances of the "Scholorship" class. 
        /// </summary>
        /// <param name="scholorshipIds">Array of column "scholorship_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "Scholorship" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> Get(long[] scholorshipIds)
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
                    Log.Information("Access to entity \"Scholorship\" was denied to the user with Login ID {LoginId}. scholorshipIds: {scholorshipIds}.", this._LoginId, scholorshipIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships WHERE scholorship_id IN (@0);";

            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql, scholorshipIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for admission.scholorships.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table admission.scholorships</returns>
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
                    Log.Information("Access to get custom fields for entity \"Scholorship\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM config.custom_field_definition_view WHERE table_name='admission.scholorships' ORDER BY field_order;";
                return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from config.get_custom_field_definition('admission.scholorships'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of admission.scholorships.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table admission.scholorships</returns>
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
                    Log.Information("Access to get display field for entity \"Scholorship\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT scholorship_id AS key, scholorship_id as value FROM admission.scholorships;";
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
        /// Inserts or updates the instance of Scholorship class on the database table "admission.scholorships".
        /// </summary>
        /// <param name="scholorship">The instance of "Scholorship" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic scholorship, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            scholorship.audit_user_id = this._UserId;
            scholorship.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = scholorship.scholorship_id;

            if (Cast.To<long>(primaryKeyValue) > 0)
            {
                this.Update(scholorship, Cast.To<long>(primaryKeyValue));
            }
            else
            {
                primaryKeyValue = this.Add(scholorship);
            }

            string sql = "DELETE FROM config.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM config.custom_field_setup " +
                         "WHERE form_name=config.get_custom_field_form_name('admission.scholorships')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO config.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT config.get_custom_field_setup_id_by_table_name('admission.scholorships', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of Scholorship class on the database table "admission.scholorships".
        /// </summary>
        /// <param name="scholorship">The instance of "Scholorship" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic scholorship)
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
                    Log.Information("Access to add entity \"Scholorship\" was denied to the user with Login ID {LoginId}. {Scholorship}", this._LoginId, scholorship);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, scholorship, "admission.scholorships", "scholorship_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of Scholorship class on the database table "admission.scholorships";
        /// </summary>
        /// <param name="scholorships">List of "Scholorship" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> scholorships)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"Scholorship\" was denied to the user with Login ID {LoginId}. {scholorships}", this._LoginId, scholorships);
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
                        foreach (dynamic scholorship in scholorships)
                        {
                            line++;

                            scholorship.audit_user_id = this._UserId;
                            scholorship.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = scholorship.scholorship_id;

                            if (Cast.To<long>(primaryKeyValue) > 0)
                            {
                                result.Add(scholorship.scholorship_id);
                                db.Update("admission.scholorships", "scholorship_id", scholorship, scholorship.scholorship_id);
                            }
                            else
                            {
                                result.Add(db.Insert("admission.scholorships", "scholorship_id", scholorship));
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
        /// Updates the row of the table "admission.scholorships" with an instance of "Scholorship" class against the primary key value.
        /// </summary>
        /// <param name="scholorship">The instance of "Scholorship" class to update.</param>
        /// <param name="scholorshipId">The value of the column "scholorship_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic scholorship, long scholorshipId)
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
                    Log.Information("Access to edit entity \"Scholorship\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {Scholorship}", scholorshipId, this._LoginId, scholorship);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, scholorship, scholorshipId, "admission.scholorships", "scholorship_id");
        }

        /// <summary>
        /// Deletes the row of the table "admission.scholorships" against the primary key value.
        /// </summary>
        /// <param name="scholorshipId">The value of the column "scholorship_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(long scholorshipId)
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
                    Log.Information("Access to delete entity \"Scholorship\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", scholorshipId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM admission.scholorships WHERE scholorship_id=@0;";
            Factory.NonQuery(this._Catalog, sql, scholorshipId);
        }

        /// <summary>
        /// Performs a select statement on table "admission.scholorships" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "Scholorship" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult()
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
                    Log.Information("Access to the first page of the entity \"Scholorship\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id LIMIT 10 OFFSET 0;";
            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "admission.scholorships" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "Scholorship" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"Scholorship\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM admission.scholorships ORDER BY scholorship_id LIMIT 10 OFFSET @0;";

            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql, offset);
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM config.filters WHERE object_name='admission.scholorships' AND lower(filter_name)=lower(@0);";
            return Factory.Get<Frapid.DataAccess.Models.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "admission.scholorships".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "Scholorship" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"Scholorship\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM admission.scholorships WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.Scholorship(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "admission.scholorships" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "Scholorship" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"Scholorship\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM admission.scholorships WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.Scholorship(), filters);

            sql.OrderBy("scholorship_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "admission.scholorships".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "Scholorship" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"Scholorship\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM admission.scholorships WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.Scholorship(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "admission.scholorships" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "Scholorship" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Admission.Entities.Scholorship> GetFiltered(long pageNumber, string filterName)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"Scholorship\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM admission.scholorships WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Admission.Entities.Scholorship(), filters);

            sql.OrderBy("scholorship_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Admission.Entities.Scholorship>(this._Catalog, sql);
        }

        public void Verify(long scholorshipId, short verificationStatusId, string reason)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Verify, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to verify entity \"Scholorship\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", scholorshipId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            if (scholorshipId > 0)
            {
                const string sql =
                    "UPDATE admission.scholorships SET verification_status_id=@0, verified_by_user_id=@1, verified_on=NOW(), verification_reason=@2 WHERE scholorship_id = @3;";

                Factory.NonQuery(this._Catalog, sql, verificationStatusId, this._UserId, reason, scholorshipId);
            }
        }

    }
}