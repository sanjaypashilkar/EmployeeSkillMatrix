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
        const int pageSize = 10;

        public EmployeeService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public vwEmployee GetEmployees(int pg = 0)
        {
            vwEmployee employees = new vwEmployee();
            var entEmployees = _skillMatrixRepository.GetEmployees().ToList();
            if (entEmployees.Count > 0)
            {
                var sortedList = entEmployees.OrderBy(s => s.Name).ToList();
                if (pg < 1)
                    pg = 1;

                int rescCount = sortedList.Count();
                int recSkip = (pg - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, pg, pageSize);
                employees.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                employees.PaginatedEmployees = paginatedData;
                employees.Employees = sortedList;
            }
            return employees;
        }

        public List<Employee> GetEmployees(string fileName, string accountType)
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
                            string sapUserName = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : string.Empty;
                            string spiEmployeeNo = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : string.Empty;
                            string employeeName = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : string.Empty;
                            var dateHired = reader.GetValue(3) != null ? reader.GetValue(3).ToString() : string.Empty;
                            DateTime dateHired_DT;
                            bool isValidHiredDate = DateTime.TryParse(dateHired, out dateHired_DT);
                            if (isValidHiredDate)
                            {
                                string engagement = reader.GetValue(4) != null ? reader.GetValue(4).ToString() : string.Empty;
                                var createdDate = DateTime.Now.Date;
                                employees.Add(new Employee
                                {
                                    AccountType = accountType,
                                    SAPUserName = sapUserName.ToUpper(),
                                    SPIEmployeeNo = spiEmployeeNo.ToUpper(),
                                    Name = employeeName,
                                    DateHired = dateHired_DT,
                                    Engagement = engagement,
                                    CreatedDate = createdDate,
                                    UpdatedDate = createdDate
                                });
                            }
                        }
                    }
                }
            }
            return employees;
        }

        public void SaveEmployees(string fileName, string accountType)
        {
            var employees = GetEmployees(fileName, accountType);
            if (employees.Count > 0)
            {
                var entEmployees = _skillMatrixRepository.GetEmployees().ToList();
                var newEmployees = employees.Where(x => !entEmployees.Any(e => e.SPIEmployeeNo.ToUpper() == x.SPIEmployeeNo.ToLower())).OrderByDescending(o => o.DateHired);
                if (newEmployees.Count() > 0)
                {
                    _skillMatrixRepository.SaveEmployees(newEmployees);
                }
            }
        }

        public Dictionary<string, string> mtdGetAccountTypes()
        {
            var departments = Helper.GetEnumValuesAndDescriptions<AccountType>();
            var selectList = departments.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }
    }
}
