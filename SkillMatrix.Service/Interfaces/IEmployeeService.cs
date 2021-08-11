using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IEmployeeService
    {
        List<vwEmployee> GetEmployees();
        List<vwEmployee> GetEmployees(string fileName);
        void SaveEmployees(string fileName);
    }
}
