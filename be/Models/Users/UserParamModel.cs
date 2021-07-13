using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoV3API.Models.Users
{
    public class UserParamModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
        public string Branch { get; set; }
        public DataTableBindingModel Arg { get; set; }

    }
}
