using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Branch
{
    public class BranchParamModel
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchType { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public DataTableBindingModel Arg { get; set; }
    }
}
