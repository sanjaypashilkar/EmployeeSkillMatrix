using ExcelDataReader;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SkillMatrix.Service
{
    public class EmployeeService : IEmployeeService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }

        public EmployeeService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public List<vwEmployee> GetEmployees()
        {
            var entEmployees = _skillMatrixRepository.GetEmployees().ToList();
            List<vwEmployee> employees = new List<vwEmployee>();
            foreach (var employee in entEmployees)
            {
                employees.Add(new vwEmployee
                {
                    Name = employee.Name,
                    DateHired = employee.DateHired,
                    CreatedDate = employee.CreatedDate,
                    UpdatedDate = employee.UpdatedDate
                });
            }
            return employees;
        }

        public List<vwEmployee> GetEmployees(string fileName)
        {            
            List<vwEmployee> employees = new List<vwEmployee>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth != 0)
                        {
                            string employeeName = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : string.Empty;                            
                            var dateHired = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : string.Empty;
                            var createdDate = DateTime.Now.Date;
                            employees.Add(new vwEmployee
                            {
                                Name = employeeName,
                                DateHired = Convert.ToDateTime(dateHired),
                                CreatedDate = createdDate,
                                UpdatedDate = createdDate
                            });
                        }
                    }
                }
            }
            return employees;
        }

        public void SaveEmployees(string fileName)
        {
            List<Employee> employees = new List<Employee>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth != 0)
                        {
                            string employeeName = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : string.Empty;
                            var dateHired = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                            var createdDate = DateTime.Now.Date;
                            employees.Add(new Employee
                            {
                                Name = employeeName,
                                DateHired = Convert.ToDateTime(dateHired),
                                CreatedDate = createdDate,
                                UpdatedDate = createdDate
                            });
                        }
                    }
                }
            }
            if(employees.Count>0)
            {
                var entEmployees = _skillMatrixRepository.GetEmployees().ToList();
                var newEmployees = employees.Where(x => !entEmployees.Any(e => e.Name.ToLower() == x.Name.ToLower()));
                if(newEmployees.Count()>0)
                {
                    _skillMatrixRepository.SaveEmployees(newEmployees);
                }
            }
        }
    }
}
