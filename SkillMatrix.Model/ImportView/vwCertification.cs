using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwCertification
    {
        public string AccountType { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual double? OSVC_Score { get; set; }
        public virtual double? OA_Score { get; set; }
        public virtual double? EM_Score { get; set; }
        public virtual DateTime CertificationDate { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }        
    }

    public class vwImportAndSaveCertification
    {
        public virtual List<vwCertification> CertificateScores { get; set; }
        public virtual Dictionary<string, string> lstAccountTypes { get; set; }

        public vwImportAndSaveCertification()
        {
            CertificateScores = new List<vwCertification>();
            lstAccountTypes = new Dictionary<string, string>();
        }
    }
}
