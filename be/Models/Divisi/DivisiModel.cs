using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Divisi
{
    public class DivisiModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserEntry { get; set; }
        public DateTime DateEntry { get; set; }
        public string UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DataTableBindingModel Arg { get; set; }
    }
}
