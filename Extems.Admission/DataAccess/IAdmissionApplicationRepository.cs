// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IAdmissionApplicationRepository
    {
        /// <summary>
        /// Counts the number of AdmissionApplication in IAdmissionApplicationRepository.
        /// </summary>
        /// <returns>Returns the count of IAdmissionApplicationRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of AdmissionApplication. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of AdmissionApplication.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetAll();

        /// <summary>
        /// Returns all instances of AdmissionApplication to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of AdmissionApplication.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the AdmissionApplication against admissionApplicationId. 
        /// </summary>
        /// <param name="admissionApplicationId">The column "admission_application_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of AdmissionApplication.</returns>
        Extems.Admission.Entities.AdmissionApplication Get(long admissionApplicationId);

        /// <summary>
        /// Gets the first record of AdmissionApplication.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of AdmissionApplication.</returns>
        Extems.Admission.Entities.AdmissionApplication GetFirst();

        /// <summary>
        /// Gets the previous record of AdmissionApplication sorted by admissionApplicationId. 
        /// </summary>
        /// <param name="admissionApplicationId">The column "admission_application_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of AdmissionApplication.</returns>
        Extems.Admission.Entities.AdmissionApplication GetPrevious(long admissionApplicationId);

        /// <summary>
        /// Gets the next record of AdmissionApplication sorted by admissionApplicationId. 
        /// </summary>
        /// <param name="admissionApplicationId">The column "admission_application_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of AdmissionApplication.</returns>
        Extems.Admission.Entities.AdmissionApplication GetNext(long admissionApplicationId);

        /// <summary>
        /// Gets the last record of AdmissionApplication.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of AdmissionApplication.</returns>
        Extems.Admission.Entities.AdmissionApplication GetLast();

        /// <summary>
        /// Returns multiple instances of the AdmissionApplication against admissionApplicationIds. 
        /// </summary>
        /// <param name="admissionApplicationIds">Array of column "admission_application_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of AdmissionApplication.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> Get(long[] admissionApplicationIds);

        /// <summary>
        /// Custom fields are user defined form elements for IAdmissionApplicationRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for AdmissionApplication.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding AdmissionApplication.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for AdmissionApplication.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of AdmissionApplication class to IAdmissionApplicationRepository.
        /// </summary>
        /// <param name="admissionApplication">The instance of AdmissionApplication class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic admissionApplication, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of AdmissionApplication class to IAdmissionApplicationRepository.
        /// </summary>
        /// <param name="admissionApplication">The instance of AdmissionApplication class to insert.</param>
        object Add(dynamic admissionApplication);

        /// <summary>
        /// Inserts or updates multiple instances of AdmissionApplication class to IAdmissionApplicationRepository.;
        /// </summary>
        /// <param name="admissionApplications">List of AdmissionApplication class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> admissionApplications);


        /// <summary>
        /// Updates IAdmissionApplicationRepository with an instance of AdmissionApplication class against the primary key value.
        /// </summary>
        /// <param name="admissionApplication">The instance of AdmissionApplication class to update.</param>
        /// <param name="admissionApplicationId">The value of the column "admission_application_id" which will be updated.</param>
        void Update(dynamic admissionApplication, long admissionApplicationId);

        /// <summary>
        /// Deletes AdmissionApplication from  IAdmissionApplicationRepository against the primary key value.
        /// </summary>
        /// <param name="admissionApplicationId">The value of the column "admission_application_id" which will be deleted.</param>
        void Delete(long admissionApplicationId);

        /// <summary>
        /// Produces a paginated result of 10 AdmissionApplication classes.
        /// </summary>
        /// <returns>Returns the first page of collection of AdmissionApplication class.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 AdmissionApplication classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of AdmissionApplication class.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IAdmissionApplicationRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of AdmissionApplication class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IAdmissionApplicationRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of AdmissionApplication class.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IAdmissionApplicationRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of AdmissionApplication class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IAdmissionApplicationRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of AdmissionApplication class.</returns>
        IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetFiltered(long pageNumber, string filterName);


        void Verify(long admissionApplicationId, short verificationStatusId, string reason);

    }
}