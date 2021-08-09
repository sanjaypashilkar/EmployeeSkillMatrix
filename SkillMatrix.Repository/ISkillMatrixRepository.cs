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
        IQueryable<EmployeeSkillMatrix> GetSkillMatrix();
        IQueryable<CategoryScoring> GetCategoryScoring();
        IQueryable<CompetencyLevelScoring> GetCompetencyLevelScoring();
        IQueryable<TenureAndCompetency> GetTenureAndCompetency();
        IQueryable<Employee> GetEmployees();
        int SaveEmployees(IEnumerable<Employee> employees);
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
    }
}
