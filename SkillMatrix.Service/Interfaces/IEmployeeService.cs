using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IEmployeeService
    {
        vwEmployee GetEmployees(int pg=0);
        vwEmployee GetEmployees(string fileName);
        void SaveEmployees(string fileName);
    }
}
