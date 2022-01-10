using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwCertificationReport
    {
        public virtual List<vwCertifcationLevelReport> CertificationLevelReport { get; set; }
        public virtual List<vwCertifcationLevelReport> PaginatedLevelReport { get; set; }
        public virtual CertificationFilter CertificationFilter { get; set; }
        public virtual Dictionary<string, string> lstAccountTypes { get; set; }
        public virtual Pager Pager { get; set; }

        public vwCertificationReport()
        {
            CertificationLevelReport = new List<vwCertifcationLevelReport>();
            PaginatedLevelReport = new List<vwCertifcationLevelReport>();
            CertificationFilter = new CertificationFilter();
            lstAccountTypes = new Dictionary<string, string>();
            Pager = new Pager();
        }
    }

    public class vwCertifcationLevelReport
    {
        public string AccountType { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual string Position { get; set; }
        public virtual DateTime HiredDate { get; set; }
        public virtual string Status { get; set; }
        public virtual int TenureYears { get; set; }
        public virtual int TenureMonths { get; set; }
        public virtual string Tenure { get; set; }
        public virtual DateTime CertificationDate { get; set; }
        public virtual string OSVC_Score { get; set; }
        public virtual string OA_Score { get; set; }
        public virtual string EM_Score { get; set; }
        public virtual string Score_Earned { get; set; }
        public virtual string Max_Score { get; set; }
        public virtual string Average { get; set; }
        public virtual string Level { get; set; }
        
        public vwCertifcationLevelReport()
        {
            
        }
    }
}
