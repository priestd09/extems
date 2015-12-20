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

namespace Extems.Academic.DataAccess
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "academic.academic_levels".
    /// </summary>
    public class AcademicLevel : DbAccess, IAcademicLevelRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "academic".
        /// </summary>
        public override string _ObjectNamespace => "academic";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "academic_levels".
        /// </summary>
        public override string _ObjectName => "academic_levels";

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
        /// Performs SQL count on the table "academic.academic_levels".
        /// </summary>
        /// <returns>Returns the number of rows of the table "academic.academic_levels".</returns>
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
                    Log.Information("Access to count entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM academic.academic_levels;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "academic.academic_levels" to return all instances of the "AcademicLevel" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "AcademicLevel" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetAll()
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
                    Log.Information("Access to the export entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "academic.academic_levels" to return all instances of the "AcademicLevel" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "AcademicLevel" class.</returns>
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
                    Log.Information("Access to the export entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "academic.academic_levels" with a where filter on the column "academic_level_id" to return a single instance of the "AcademicLevel" class. 
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Academic.Entities.AcademicLevel Get(int academicLevelId)
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
                    Log.Information("Access to the get entity \"AcademicLevel\" filtered by \"AcademicLevelId\" with value {AcademicLevelId} was denied to the user with Login ID {_LoginId}", academicLevelId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels WHERE academic_level_id=@0;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql, academicLevelId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first record of the table "academic.academic_levels". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Academic.Entities.AcademicLevel GetFirst()
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
                    Log.Information("Access to the get the first record of entity \"AcademicLevel\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id LIMIT 1;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Gets the previous record of the table "academic.academic_levels" sorted by academicLevelId.
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Academic.Entities.AcademicLevel GetPrevious(int academicLevelId)
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
                    Log.Information("Access to the get the previous entity of \"AcademicLevel\" by \"AcademicLevelId\" with value {AcademicLevelId} was denied to the user with Login ID {_LoginId}", academicLevelId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels WHERE academic_level_id < @0 ORDER BY academic_level_id DESC LIMIT 1;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql, academicLevelId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the next record of the table "academic.academic_levels" sorted by academicLevelId.
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Academic.Entities.AcademicLevel GetNext(int academicLevelId)
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
                    Log.Information("Access to the get the next entity of \"AcademicLevel\" by \"AcademicLevelId\" with value {AcademicLevelId} was denied to the user with Login ID {_LoginId}", academicLevelId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels WHERE academic_level_id > @0 ORDER BY academic_level_id LIMIT 1;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql, academicLevelId).FirstOrDefault();
        }


        /// <summary>
        /// Gets the last record of the table "academic.academic_levels". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Extems.Academic.Entities.AcademicLevel GetLast()
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
                    Log.Information("Access to the get the last record of entity \"AcademicLevel\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id DESC LIMIT 1;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "academic.academic_levels" with a where filter on the column "academic_level_id" to return a multiple instances of the "AcademicLevel" class. 
        /// </summary>
        /// <param name="academicLevelIds">Array of column "academic_level_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "AcademicLevel" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> Get(int[] academicLevelIds)
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
                    Log.Information("Access to entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. academicLevelIds: {academicLevelIds}.", this._LoginId, academicLevelIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels WHERE academic_level_id IN (@0);";

            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql, academicLevelIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for academic.academic_levels.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table academic.academic_levels</returns>
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
                    Log.Information("Access to get custom fields for entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM config.custom_field_definition_view WHERE table_name='academic.academic_levels' ORDER BY field_order;";
                return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from config.get_custom_field_definition('academic.academic_levels'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of academic.academic_levels.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table academic.academic_levels</returns>
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
                    Log.Information("Access to get display field for entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT academic_level_id AS key, academic_level_code || ' (' || academic_level_name || ')' as value FROM academic.academic_levels;";
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
        /// Inserts or updates the instance of AcademicLevel class on the database table "academic.academic_levels".
        /// </summary>
        /// <param name="academicLevel">The instance of "AcademicLevel" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic academicLevel, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            academicLevel.audit_user_id = this._UserId;
            academicLevel.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = academicLevel.academic_level_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                this.Update(academicLevel, Cast.To<int>(primaryKeyValue));
            }
            else
            {
                primaryKeyValue = this.Add(academicLevel);
            }

            string sql = "DELETE FROM config.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM config.custom_field_setup " +
                         "WHERE form_name=config.get_custom_field_form_name('academic.academic_levels')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO config.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT config.get_custom_field_setup_id_by_table_name('academic.academic_levels', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of AcademicLevel class on the database table "academic.academic_levels".
        /// </summary>
        /// <param name="academicLevel">The instance of "AcademicLevel" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic academicLevel)
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
                    Log.Information("Access to add entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. {AcademicLevel}", this._LoginId, academicLevel);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, academicLevel, "academic.academic_levels", "academic_level_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of AcademicLevel class on the database table "academic.academic_levels";
        /// </summary>
        /// <param name="academicLevels">List of "AcademicLevel" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> academicLevels)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. {academicLevels}", this._LoginId, academicLevels);
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
                        foreach (dynamic academicLevel in academicLevels)
                        {
                            line++;

                            academicLevel.audit_user_id = this._UserId;
                            academicLevel.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = academicLevel.academic_level_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(academicLevel.academic_level_id);
                                db.Update("academic.academic_levels", "academic_level_id", academicLevel, academicLevel.academic_level_id);
                            }
                            else
                            {
                                result.Add(db.Insert("academic.academic_levels", "academic_level_id", academicLevel));
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
        /// Updates the row of the table "academic.academic_levels" with an instance of "AcademicLevel" class against the primary key value.
        /// </summary>
        /// <param name="academicLevel">The instance of "AcademicLevel" class to update.</param>
        /// <param name="academicLevelId">The value of the column "academic_level_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic academicLevel, int academicLevelId)
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
                    Log.Information("Access to edit entity \"AcademicLevel\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {AcademicLevel}", academicLevelId, this._LoginId, academicLevel);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, academicLevel, academicLevelId, "academic.academic_levels", "academic_level_id");
        }

        /// <summary>
        /// Deletes the row of the table "academic.academic_levels" against the primary key value.
        /// </summary>
        /// <param name="academicLevelId">The value of the column "academic_level_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int academicLevelId)
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
                    Log.Information("Access to delete entity \"AcademicLevel\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", academicLevelId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM academic.academic_levels WHERE academic_level_id=@0;";
            Factory.NonQuery(this._Catalog, sql, academicLevelId);
        }

        /// <summary>
        /// Performs a select statement on table "academic.academic_levels" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "AcademicLevel" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult()
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
                    Log.Information("Access to the first page of the entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id LIMIT 10 OFFSET 0;";
            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "academic.academic_levels" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "AcademicLevel" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM academic.academic_levels ORDER BY academic_level_id LIMIT 10 OFFSET @0;";

            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql, offset);
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM config.filters WHERE object_name='academic.academic_levels' AND lower(filter_name)=lower(@0);";
            return Factory.Get<Frapid.DataAccess.Models.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "academic.academic_levels".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "AcademicLevel" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM academic.academic_levels WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Academic.Entities.AcademicLevel(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "academic.academic_levels" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "AcademicLevel" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM academic.academic_levels WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Academic.Entities.AcademicLevel(), filters);

            sql.OrderBy("academic_level_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "academic.academic_levels".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "AcademicLevel" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM academic.academic_levels WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Academic.Entities.AcademicLevel(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "academic.academic_levels" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "AcademicLevel" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetFiltered(long pageNumber, string filterName)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"AcademicLevel\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM academic.academic_levels WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Extems.Academic.Entities.AcademicLevel(), filters);

            sql.OrderBy("academic_level_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Extems.Academic.Entities.AcademicLevel>(this._Catalog, sql);
        }


    }
}