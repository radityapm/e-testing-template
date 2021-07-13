using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Branch
{
    public class BranchModel
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchType { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string AreaCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PIC1 { get; set; }
        public string PIC2 { get; set; }
        public string PIC3 { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public decimal Accuracy { get; set; }
        public string AddressPoint { get; set; }
        public string Location { get; set; }
        public string UserEntry { get; set; }
        public DateTime DateEntry { get; set; }
        public string UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
