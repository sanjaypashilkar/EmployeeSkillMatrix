using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IEmployeeService
    {
        vwEmployee GetEmployees(int pg=0);
        List<Employee> GetEmployees(string fileName, string accountType);
        void SaveEmployees(string fileName, string accountType);
        Dictionary<string, string> mtdGetAccountTypes();
    }
}
