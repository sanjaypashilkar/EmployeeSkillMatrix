using Microsoft.EntityFrameworkCore;
using SkillMatrix.Model;
using System;

namespace SkillMatrix.Repository
{
    public class SkillMatrixDb : DbContext
    {
        private static string _dbConnectionString;

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSkillMatrix> EmployeeSkillMatrix { get; set; }
        public DbSet<CategoryScoring> CategoryScoring { get; set; }
        public DbSet<CompetencyLevelScoring> CompetencyLevelScoring { get; set; }
        public DbSet<TenureLevel> TenureLevel { get; set; }
        public DbSet<QualityRating> QualityRating { get; set; }
        public DbSet<QualityRating2> QualityRating2 { get; set; }
        public SkillMatrixDb()
        { }

        public SkillMatrixDb(DbContextOptions<SkillMatrixDb> options) :base(options)
        {
            _dbConnectionString = Database.GetDbConnection().ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                optionsBuilder.UseMySQL(_dbConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<EmployeeSkillMatrix>();
            modelBuilder.Entity<QualityRating>();
            modelBuilder.Entity<QualityRating2>();

            #region DataSeed

            modelBuilder.Entity<CategoryScoring>().HasData(
                new CategoryScoring
                {
                    Id = 1,
                    LowerScore = 0,
                    UpperScore = 1,
                    Score = 0.00,
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CategoryScoring
                {
                    Id = 2,
                    LowerScore = 1,
                    UpperScore = 85,
                    Score = 1.00,
                    CreatedDate = DateTime.Today, 
                    UpdatedDate = DateTime.Today
                },
                new CategoryScoring
                {
                    Id = 3,
                    LowerScore = 85,
                    UpperScore = 92,
                    Score = 2.00,
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CategoryScoring
                {
                    Id = 4,
                    LowerScore = 92,
                    UpperScore = 94,
                    Score = 3.00,
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CategoryScoring
                {
                    Id = 5,
                    LowerScore = 94,
                    UpperScore = 99,
                    Score = 4.00,
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CategoryScoring
                {
                    Id = 6,
                    LowerScore = 99,
                    UpperScore = 10000,
                    Score = 5.0,
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                }
            );

            modelBuilder.Entity<CompetencyLevelScoring>().HasData(
                new CompetencyLevelScoring
                {
                    Id = 1,
                    LowerScore = 0,
                    UpperScore = 2.49,
                    Level = "Novice",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CompetencyLevelScoring
                {
                    Id = 2,
                    LowerScore = 2.50,
                    UpperScore = 3.49,
                    Level = "Advanced Beginner",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CompetencyLevelScoring
                {
                    Id = 3,
                    LowerScore = 3.50,
                    UpperScore = 3.99,
                    Level = "Competent",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CompetencyLevelScoring
                {
                    Id = 4,
                    LowerScore = 4.00,
                    UpperScore = 4.49,
                    Level = "Proficient",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new CompetencyLevelScoring
                {
                    Id = 5,
                    LowerScore = 4.50,
                    UpperScore = 5.00,
                    Level = "Expert",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                }
            );

            modelBuilder.Entity<TenureLevel>().HasData(
                new TenureLevel
                {
                    Id = 1,
                    LowerScore = 6,
                    UpperScore = 9,
                    Level = "Novice",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new TenureLevel
                {
                    Id = 2,
                    LowerScore = 10,
                    UpperScore = 12,
                    Level = "Advanced Beginner",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new TenureLevel
                {
                    Id = 3,
                    LowerScore = 13,
                    UpperScore = 1000,
                    Level = "Competent",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new TenureLevel
                {
                    Id = 4,
                    LowerScore = 13,
                    UpperScore = 1000,
                    Level = "Proficient",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                },
                new TenureLevel
                {
                    Id = 5,
                    LowerScore = 13,
                    UpperScore = 1000,
                    Level = "Expert",
                    CreatedDate = DateTime.Today,
                    UpdatedDate = DateTime.Today
                }
            );

            #endregion
        }
    }
}
