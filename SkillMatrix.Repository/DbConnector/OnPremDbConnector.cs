using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.Repository.DbConnector
{
    public class OnPremDbConnector : MySqlDbConnector
    {
        public OnPremDbConnector(string defaultConnectionString):base(defaultConnectionString)
        {
        }

        public override string GetConnectionString()
        {
            return DefaultConnectionString;
        }

        public override DbContextOptionsBuilder GetDbContextOptions(DbContextOptionsBuilder options)
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            options.UseMySQL(DefaultConnectionString);
            return options;
        }
    }
}
