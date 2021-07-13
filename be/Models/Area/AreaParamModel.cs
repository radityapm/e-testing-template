using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Area
{
    public class AreaParamModel
    {
		public string ProvinsiID { get; set; }
		public string ProvinsiName { get; set; }
		public string KotaID { get; set; }
		public string KotaName { get; set; }
		public string KecamatanID { get; set; }
		public string KecamatanName { get; set; }
		public string KelurahanID { get; set; }
		public string KelurahanName { get; set; }
		public DataTableBindingModel Arg { get; set; }		
	}
}
