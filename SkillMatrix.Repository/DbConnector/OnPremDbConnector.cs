using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
