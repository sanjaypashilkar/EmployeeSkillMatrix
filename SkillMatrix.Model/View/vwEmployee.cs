using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwEmployee
    {
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Employee> PaginatedEmployees { get; set; }
        public virtual Pager Pager { get; set; }

        public vwEmployee()
        {
            Employees = new List<Employee>();
        }
    }
}
