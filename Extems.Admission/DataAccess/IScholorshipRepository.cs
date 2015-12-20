// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IScholorshipRepository
    {
        /// <summary>
        /// Counts the number of Scholorship in IScholorshipRepository.
        /// </summary>
        /// <returns>Returns the count of IScholorshipRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Scholorship. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Scholorship.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> GetAll();

        /// <summary>
        /// Returns all instances of Scholorship to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Scholorship.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Scholorship against scholorshipId. 
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Scholorship.</returns>
        Extems.Admission.Entities.Scholorship Get(long scholorshipId);

        /// <summary>
        /// Gets the first record of Scholorship.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Scholorship.</returns>
        Extems.Admission.Entities.Scholorship GetFirst();

        /// <summary>
        /// Gets the previous record of Scholorship sorted by scholorshipId. 
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Scholorship.</returns>
        Extems.Admission.Entities.Scholorship GetPrevious(long scholorshipId);

        /// <summary>
        /// Gets the next record of Scholorship sorted by scholorshipId. 
        /// </summary>
        /// <param name="scholorshipId">The column "scholorship_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Scholorship.</returns>
        Extems.Admission.Entities.Scholorship GetNext(long scholorshipId);

        /// <summary>
        /// Gets the last record of Scholorship.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Scholorship.</returns>
        Extems.Admission.Entities.Scholorship GetLast();

        /// <summary>
        /// Returns multiple instances of the Scholorship against scholorshipIds. 
        /// </summary>
        /// <param name="scholorshipIds">Array of column "scholorship_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Scholorship.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> Get(long[] scholorshipIds);

        /// <summary>
        /// Custom fields are user defined form elements for IScholorshipRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Scholorship.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Scholorship.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Scholorship.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Scholorship class to IScholorshipRepository.
        /// </summary>
        /// <param name="scholorship">The instance of Scholorship class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic scholorship, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Scholorship class to IScholorshipRepository.
        /// </summary>
        /// <param name="scholorship">The instance of Scholorship class to insert.</param>
        object Add(dynamic scholorship);

        /// <summary>
        /// Inserts or updates multiple instances of Scholorship class to IScholorshipRepository.;
        /// </summary>
        /// <param name="scholorships">List of Scholorship class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> scholorships);


        /// <summary>
        /// Updates IScholorshipRepository with an instance of Scholorship class against the primary key value.
        /// </summary>
        /// <param name="scholorship">The instance of Scholorship class to update.</param>
        /// <param name="scholorshipId">The value of the column "scholorship_id" which will be updated.</param>
        void Update(dynamic scholorship, long scholorshipId);

        /// <summary>
        /// Deletes Scholorship from  IScholorshipRepository against the primary key value.
        /// </summary>
        /// <param name="scholorshipId">The value of the column "scholorship_id" which will be deleted.</param>
        void Delete(long scholorshipId);

        /// <summary>
        /// Produces a paginated result of 10 Scholorship classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Scholorship class.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Scholorship classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Scholorship class.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IScholorshipRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Scholorship class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IScholorshipRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Scholorship class.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IScholorshipRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Scholorship class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IScholorshipRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Scholorship class.</returns>
        IEnumerable<Extems.Admission.Entities.Scholorship> GetFiltered(long pageNumber, string filterName);


        void Verify(long scholorshipId, short verificationStatusId, string reason);

    }
}