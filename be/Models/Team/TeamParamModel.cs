using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Team
{
    public class TeamParamModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Divisi { get; set; }
        public string Email { get; set; }
        public DataTableBindingModel Arg { get; set; }

    }
}
