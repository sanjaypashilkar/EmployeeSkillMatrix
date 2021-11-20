using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkillMatrix.Model
{
    public class BusinessPartner
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public string Modified { get; set; }
        public string Valid { get; set; }
        public string TLRemarks { get; set; }        
        public string Team { get; set; }
        public double BusinessPartnerNumber { get; set; }
        public int PartnerCategory { get; set; }
        public string PartnerType { get; set; }
        public string Title { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Institute1 { get; set; }
        public string Institute2 { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode1 { get; set; }
        public string POBox { get; set; }
        public string PostalCode2 { get; set; }
        public string City { get; set; }
        public string CountryKey { get; set; }
        public string EmailAddress { get; set; }
        public string SalesOrganization1 { get; set; }
        public string SalesOrganization2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public string Remarks { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
