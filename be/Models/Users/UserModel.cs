using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoV3API.Models.Users
{
    public class UserModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfileID { get; set; }
        public string ProfileName { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchTypeID { get; set; }
        public string BranchTypeName { get; set; }
        public string Divisi { get; set; }
        public string Phone { get; set; }
        public DateTime DateEntry { get; set; }
        public string UserEntry { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
