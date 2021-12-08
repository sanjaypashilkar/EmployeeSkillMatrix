using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwEmployee
    {
        public virtual Dictionary<string, string> lstAccountTypes { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Employee> PaginatedEmployees { get; set; }
        public virtual Pager Pager { get; set; }

        public vwEmployee()
        {
            lstAccountTypes = new Dictionary<string, string>();
            Employees = new List<Employee>();
            PaginatedEmployees = new List<Employee>();
            Pager = new Pager();
        }
    }
}
