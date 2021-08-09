using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Repository.DbConnector
{
    public static class MySqlDbConnectorFactory
    {
        public static MySqlDbConnector GetMySqlDbConnector(string dbConnectOption, string defaultConnectionString)
        {
            return dbConnectOption switch
            {
                "ONPREMMYSQLAUTH" => new OnPremDbConnector(defaultConnectionString),
                _=>throw new InvalidOperationException("Invalid Argument dbConnectOption" + dbConnectOption)
            };
        }
    }
}
