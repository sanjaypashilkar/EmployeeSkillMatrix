using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Repository.DbConnector
{
    public abstract class MySqlDbConnector
    {
        #region Global Protected Variables

        protected string ConnectionString { get; set; }
        protected string DefaultConnectionString { get; set; }

        #endregion

        public MySqlDbConnector(string defaultConnectionString)
        {
            DefaultConnectionString = defaultConnectionString;
        }

        protected string GetConnectionString(string defaultConnectionString)
        {
            ConnectionString = defaultConnectionString;
            return ConnectionString;
        }

        #region Abstract Methods

        public abstract string GetConnectionString();
        public abstract DbContextOptionsBuilder GetDbContextOptions(DbContextOptionsBuilder options);

        #endregion
    }
}
