// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface ISectionRepository
    {
        /// <summary>
        /// Counts the number of Section in ISectionRepository.
        /// </summary>
        /// <returns>Returns the count of ISectionRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Section. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Section.</returns>
        IEnumerable<Extems.Academic.Entities.Section> GetAll();

        /// <summary>
        /// Returns all instances of Section to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Section.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Section against sectionId. 
        /// </summary>
        /// <param name="sectionId">The column "section_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Section.</returns>
        Extems.Academic.Entities.Section Get(int sectionId);

        /// <summary>
        /// Gets the first record of Section.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Section.</returns>
        Extems.Academic.Entities.Section GetFirst();

        /// <summary>
        /// Gets the previous record of Section sorted by sectionId. 
        /// </summary>
        /// <param name="sectionId">The column "section_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Section.</returns>
        Extems.Academic.Entities.Section GetPrevious(int sectionId);

        /// <summary>
        /// Gets the next record of Section sorted by sectionId. 
        /// </summary>
        /// <param name="sectionId">The column "section_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Section.</returns>
        Extems.Academic.Entities.Section GetNext(int sectionId);

        /// <summary>
        /// Gets the last record of Section.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Section.</returns>
        Extems.Academic.Entities.Section GetLast();

        /// <summary>
        /// Returns multiple instances of the Section against sectionIds. 
        /// </summary>
        /// <param name="sectionIds">Array of column "section_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Section.</returns>
        IEnumerable<Extems.Academic.Entities.Section> Get(int[] sectionIds);

        /// <summary>
        /// Custom fields are user defined form elements for ISectionRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Section.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Section.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Section.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Section class to ISectionRepository.
        /// </summary>
        /// <param name="section">The instance of Section class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic section, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Section class to ISectionRepository.
        /// </summary>
        /// <param name="section">The instance of Section class to insert.</param>
        object Add(dynamic section);

        /// <summary>
        /// Inserts or updates multiple instances of Section class to ISectionRepository.;
        /// </summary>
        /// <param name="sections">List of Section class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> sections);


        /// <summary>
        /// Updates ISectionRepository with an instance of Section class against the primary key value.
        /// </summary>
        /// <param name="section">The instance of Section class to update.</param>
        /// <param name="sectionId">The value of the column "section_id" which will be updated.</param>
        void Update(dynamic section, int sectionId);

        /// <summary>
        /// Deletes Section from  ISectionRepository against the primary key value.
        /// </summary>
        /// <param name="sectionId">The value of the column "section_id" which will be deleted.</param>
        void Delete(int sectionId);

        /// <summary>
        /// Produces a paginated result of 10 Section classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Section class.</returns>
        IEnumerable<Extems.Academic.Entities.Section> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Section classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Section class.</returns>
        IEnumerable<Extems.Academic.Entities.Section> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ISectionRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Section class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against ISectionRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Section class.</returns>
        IEnumerable<Extems.Academic.Entities.Section> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ISectionRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Section class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of ISectionRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Section class.</returns>
        IEnumerable<Extems.Academic.Entities.Section> GetFiltered(long pageNumber, string filterName);



    }
}