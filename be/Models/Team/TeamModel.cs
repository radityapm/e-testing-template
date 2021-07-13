using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Team
{
    public class TeamModel
    {
        public int  No { get; set; }
        public string ID { get; set; }
        public string Nik { get; set; }
        public string Name { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public string DivisiID { get; set; }
        public string DivisiName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateEntry { get; set; }
        public string UserEntry { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
