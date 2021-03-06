using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Repository
{
    public interface ISkillMatrixRepository
    {
        IQueryable<Model.EmployeeSkillMatrix> GetSkillMatrix();
        IQueryable<Model.EmployeeSkillMatrix> GetSkillMatrixByYearAndQuarter(int year, int quarter);
        IQueryable<CategoryScoring> GetCategoryScoring();
        IQueryable<CompetencyLevelScoring> GetCompetencyLevelScoring();
        IQueryable<TenureLevel> GetTenureLevel();
        int SaveSkillMatrix(IEnumerable<Model.EmployeeSkillMatrix> employeeSkillMatrix);

        IQueryable<Employee> GetEmployees();
        int SaveEmployees(IEnumerable<Employee> employees);

        #region QUALITY RATING

        IQueryable<QualityRating> GetQualityRating();
        IQueryable<QualityRating> GetQualityRatingByDate(DateTime startDate, DateTime endDate);
        IQueryable<QualityRating2> GetQualityRatingByDate2(DateTime startDate, DateTime endDate);
        IQueryable<QualityRating3> GetQualityRatingByDate3(DateTime startDate, DateTime endDate);
        int SaveQualityRating(IEnumerable<QualityRating> qualityRating);
        int SaveQualityRating(IEnumerable<QualityRating2> qualityRating);
        int SaveQualityRating(IEnumerable<QualityRating3> qualityRating);

        #endregion

        #region TICKETING TOOL
        IQueryable<TicketingTool> GetTicketingRecordsByDate(DateTime startDate, DateTime endDate);
        int SaveTicketingRecords(IEnumerable<TicketingTool> ticketingRecords);
        #endregion

        #region BUSINESS PARTNER
        IQueryable<BusinessPartner> GetBusinessPartnerRecordsByDate(DateTime startDate, DateTime endDate);
        int SaveBusinessPartnersRecords(IEnumerable<BusinessPartner> businessPartnersRecords);
        #endregion

        #region CSAT
        IQueryable<CSAT> GetCSATRecordsByDate(DateTime startDate, DateTime endDate);
        int SaveCSATRecords(IEnumerable<CSAT> csatRecords);
        #endregion

        #region Certification
        IQueryable<Certification> GetCertificatiionRecordsByDate(DateTime startDate, DateTime endDate);
        IQueryable<Certification> GetCertificatiionRecordsByDateAndAccount(DateTime startDate, DateTime endDate, string account);
        int SaveCertifications(IEnumerable<Certification> certificationRecords);
        #endregion

        #region COMMON METHODS

        int AddEntry<TEntity>(TEntity entry) where TEntity : class;
        int UpdateEntry<TEntity>(TEntity entry) where TEntity : class;
        int DeleteEntry<TEntity>(TEntity entry) where TEntity : class;
        T Find<T>(object key) where T : class;
        int SaveChanges();
        Task<int> AddEntryAsync<TEntity>(TEntity entry) where TEntity : class;
        Task<int> UpdateEntryAsync<TEntity>(TEntity entry) where TEntity : class;
        Task<int> DeleteEntryAsync<TEntity>(TEntity entry) where TEntity : class;
        Task<T> FindAsync<T>(object key) where T : class;
        Task<int> SaveChangesAsync();

        #endregion
    }
}
