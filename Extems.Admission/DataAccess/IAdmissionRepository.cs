// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IAdmissionRepository
    {
        /// <summary>
        /// Counts the number of Admission in IAdmissionRepository.
        /// </summary>
        /// <returns>Returns the count of IAdmissionRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Admission. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Admission.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> GetAll();

        /// <summary>
        /// Returns all instances of Admission to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Admission.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Admission against admissionId. 
        /// </summary>
        /// <param name="admissionId">The column "admission_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Admission.</returns>
        Extems.Admission.Entities.Admission Get(long admissionId);

        /// <summary>
        /// Gets the first record of Admission.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Admission.</returns>
        Extems.Admission.Entities.Admission GetFirst();

        /// <summary>
        /// Gets the previous record of Admission sorted by admissionId. 
        /// </summary>
        /// <param name="admissionId">The column "admission_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Admission.</returns>
        Extems.Admission.Entities.Admission GetPrevious(long admissionId);

        /// <summary>
        /// Gets the next record of Admission sorted by admissionId. 
        /// </summary>
        /// <param name="admissionId">The column "admission_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Admission.</returns>
        Extems.Admission.Entities.Admission GetNext(long admissionId);

        /// <summary>
        /// Gets the last record of Admission.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Admission.</returns>
        Extems.Admission.Entities.Admission GetLast();

        /// <summary>
        /// Returns multiple instances of the Admission against admissionIds. 
        /// </summary>
        /// <param name="admissionIds">Array of column "admission_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Admission.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> Get(long[] admissionIds);

        /// <summary>
        /// Custom fields are user defined form elements for IAdmissionRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Admission.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Admission.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Admission.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Admission class to IAdmissionRepository.
        /// </summary>
        /// <param name="admission">The instance of Admission class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic admission, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Admission class to IAdmissionRepository.
        /// </summary>
        /// <param name="admission">The instance of Admission class to insert.</param>
        object Add(dynamic admission);

        /// <summary>
        /// Inserts or updates multiple instances of Admission class to IAdmissionRepository.;
        /// </summary>
        /// <param name="admissions">List of Admission class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> admissions);


        /// <summary>
        /// Updates IAdmissionRepository with an instance of Admission class against the primary key value.
        /// </summary>
        /// <param name="admission">The instance of Admission class to update.</param>
        /// <param name="admissionId">The value of the column "admission_id" which will be updated.</param>
        void Update(dynamic admission, long admissionId);

        /// <summary>
        /// Deletes Admission from  IAdmissionRepository against the primary key value.
        /// </summary>
        /// <param name="admissionId">The value of the column "admission_id" which will be deleted.</param>
        void Delete(long admissionId);

        /// <summary>
        /// Produces a paginated result of 10 Admission classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Admission class.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Admission classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Admission class.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IAdmissionRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Admission class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IAdmissionRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Admission class.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IAdmissionRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Admission class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IAdmissionRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Admission class.</returns>
        IEnumerable<Extems.Admission.Entities.Admission> GetFiltered(long pageNumber, string filterName);



    }
}