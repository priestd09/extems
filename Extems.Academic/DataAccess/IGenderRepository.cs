// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IGenderRepository
    {
        /// <summary>
        /// Counts the number of Gender in IGenderRepository.
        /// </summary>
        /// <returns>Returns the count of IGenderRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Gender. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Gender.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> GetAll();

        /// <summary>
        /// Returns all instances of Gender to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Gender.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Gender against genderId. 
        /// </summary>
        /// <param name="genderId">The column "gender_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Gender.</returns>
        Extems.Academic.Entities.Gender Get(int genderId);

        /// <summary>
        /// Gets the first record of Gender.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Gender.</returns>
        Extems.Academic.Entities.Gender GetFirst();

        /// <summary>
        /// Gets the previous record of Gender sorted by genderId. 
        /// </summary>
        /// <param name="genderId">The column "gender_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Gender.</returns>
        Extems.Academic.Entities.Gender GetPrevious(int genderId);

        /// <summary>
        /// Gets the next record of Gender sorted by genderId. 
        /// </summary>
        /// <param name="genderId">The column "gender_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Gender.</returns>
        Extems.Academic.Entities.Gender GetNext(int genderId);

        /// <summary>
        /// Gets the last record of Gender.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Gender.</returns>
        Extems.Academic.Entities.Gender GetLast();

        /// <summary>
        /// Returns multiple instances of the Gender against genderIds. 
        /// </summary>
        /// <param name="genderIds">Array of column "gender_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Gender.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> Get(int[] genderIds);

        /// <summary>
        /// Custom fields are user defined form elements for IGenderRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Gender.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Gender.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Gender.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Gender class to IGenderRepository.
        /// </summary>
        /// <param name="gender">The instance of Gender class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic gender, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Gender class to IGenderRepository.
        /// </summary>
        /// <param name="gender">The instance of Gender class to insert.</param>
        object Add(dynamic gender);

        /// <summary>
        /// Inserts or updates multiple instances of Gender class to IGenderRepository.;
        /// </summary>
        /// <param name="genders">List of Gender class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> genders);


        /// <summary>
        /// Updates IGenderRepository with an instance of Gender class against the primary key value.
        /// </summary>
        /// <param name="gender">The instance of Gender class to update.</param>
        /// <param name="genderId">The value of the column "gender_id" which will be updated.</param>
        void Update(dynamic gender, int genderId);

        /// <summary>
        /// Deletes Gender from  IGenderRepository against the primary key value.
        /// </summary>
        /// <param name="genderId">The value of the column "gender_id" which will be deleted.</param>
        void Delete(int genderId);

        /// <summary>
        /// Produces a paginated result of 10 Gender classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Gender class.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Gender classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Gender class.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IGenderRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Gender class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IGenderRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Gender class.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IGenderRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Gender class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IGenderRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Gender class.</returns>
        IEnumerable<Extems.Academic.Entities.Gender> GetFiltered(long pageNumber, string filterName);



    }
}