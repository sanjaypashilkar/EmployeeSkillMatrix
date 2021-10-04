using Microsoft.EntityFrameworkCore;
using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Repository
{
    public class SkillMatrixRepository: ISkillMatrixRepository, IDisposable
    { 

        private readonly SkillMatrixDb _context;
        public SkillMatrixRepository(SkillMatrixDb context = null)
        {
            if (context != null) {
                _context = context;
                _context.Database.Migrate();
            }
            else {
                _context = new SkillMatrixDb();
            }
        }

        public IQueryable<EmployeeSkillMatrix> GetSkillMatrix()
        {
            return _context.EmployeeSkillMatrix;
        }

        public IQueryable<EmployeeSkillMatrix> GetSkillMatrixByYearAndQuarter(int year, int quarter)
        {
            return _context.EmployeeSkillMatrix.Where(e=>e.Year == year && e.Quarter == quarter).AsNoTracking();
        }

        public IQueryable<CategoryScoring> GetCategoryScoring()
        {
            return _context.CategoryScoring;
        }

        public IQueryable<CompetencyLevelScoring> GetCompetencyLevelScoring()
        {
            return _context.CompetencyLevelScoring;
        }

        public IQueryable<TenureLevel> GetTenureLevel()
        {
            return _context.TenureLevel;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employee;
        }

        public IQueryable<QualityRating> GetQualityRating()
        {
            return _context.QualityRating;
        }

        public IQueryable<QualityRating> GetQualityRatingByDate(DateTime startDate, DateTime endDate)
        {
            return _context.QualityRating.Where(e => e.TaskCompletionDate >= startDate && e.TaskCompletionDate <= endDate).AsNoTracking();
        }

        public int AddEntry<TEntity>(TEntity entry) where TEntity:class
        {
            _context.Set<TEntity>().Add(entry);
            return _context.SaveChanges();
        }

        public int UpdateEntry<TEntity>(TEntity entry) where TEntity : class
        {
            var existingEntry = _context.Set<TEntity>().Find(GetKey(entry));
            if (existingEntry != null)
                _context.Entry(existingEntry).State = EntityState.Modified;
            _context.Entry(existingEntry).CurrentValues.SetValues(entry);
            return _context.SaveChanges();
        }

        public int DeleteEntry<TEntity>(TEntity entry) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entry);
            return _context.SaveChanges();
        }

        public T Find<T>(object key) where T : class
        {
            return _context.Find(typeof(T), key) as T;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public int SaveEmployees(IEnumerable<Employee> employees) 
        {
            employees.ToList().ForEach(emp => _context.Employee.Add(emp));            
            return _context.SaveChanges();
        }
        public int SaveSkillMatrix(IEnumerable<EmployeeSkillMatrix> employeeSkillMatrix)
        {
            employeeSkillMatrix.ToList().ForEach(e => _context.EmployeeSkillMatrix.Add(e));
            return _context.SaveChanges();
        }
        public int SaveQualityRating(IEnumerable<QualityRating> qualityRating)
        {
            qualityRating.ToList().ForEach(e => _context.QualityRating.Add(e));
            return _context.SaveChanges();
        }
        public int SaveQualityRating(IEnumerable<QualityRating2> qualityRating)
        {
            qualityRating.ToList().ForEach(e => _context.QualityRating2.Add(e));
            return _context.SaveChanges();
        }

        public async Task<int> AddEntryAsync<TEntity>(TEntity entry) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entry);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEntryAsync<TEntity>(TEntity entry) where TEntity : class
        {
            var existingEntry = _context.Set<TEntity>().Find(GetKey(entry));
            if (existingEntry != null)
                _context.Entry(existingEntry).State = EntityState.Modified;
            _context.Entry(existingEntry).CurrentValues.SetValues(entry);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEntryAsync<TEntity>(TEntity entry) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entry);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync<T>(object key) where T : class
        {
            return await _context.FindAsync(typeof(T), key) as T;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private object GetKey<T>(T entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }

        public void MigrateDatabase()
        {
            _context.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool all)
        {
            _context.Dispose();
        }
    }
}
