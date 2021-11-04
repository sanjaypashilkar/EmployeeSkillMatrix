using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwBusinessPartner
    {
        public virtual DateTime Date { get; set; }
        public virtual string Comments { get; set; }
        public virtual string Modified { get; set; }
        public virtual string Valid { get; set; }
        public virtual string TLRemarks { get; set; }
        public virtual string Team { get; set; }
        public virtual double BusinessPartnerNumber { get; set; }
        public virtual uint PartnerCategory { get; set; }
        public virtual string PartnerType { get; set; }
        public virtual string Title { get; set; }
        public virtual string Name1 { get; set; }
        public virtual string Name2 { get; set; }
        public virtual string Name3 { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Institute1 { get; set; }
        public virtual string Institute2 { get; set; }
        public virtual string Street { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string PostalCode1 { get; set; }
        public virtual string POBox { get; set; }
        public virtual string PostalCode2 { get; set; }
        public virtual string City { get; set; }
        public virtual string CountryKey { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string SalesOrganization1 { get; set; }
        public virtual string SalesOrganization2 { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual DateTime ChangedOn { get; set; }
        public virtual string Remarks { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }

    public class vwImportAndSaveBusinessPartner
    {
        public virtual List<vwBusinessPartner> BusinessPartners { get; set; }
        public virtual BusinessPartnerFilter BusinessPartnerFilter { get; set; }

        public vwImportAndSaveBusinessPartner()
        {
            BusinessPartners = new List<vwBusinessPartner>();
            BusinessPartnerFilter = new BusinessPartnerFilter();
        }
    }
}
