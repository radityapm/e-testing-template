using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Base
{
    public class DataTableBindingModel
    {
        public DataTableBindingModel()
        {
            order = new List<DataTableOrderBindingModel>();
            search = new DataTableSearchBindingModel();
            columns = new List<DataTableColumnBindingModel>();
        }
        public int draw { get; set; }
        public int start { get; set; }
        public int? firstLimit { get; set; }
        public int? lastLimit { get; set; }
        public string keyword { get; set; }
        public string sortType { get; set; }
        public int? sortIndex { get; set; }
        public List<DataTableOrderBindingModel> order { get; set; }
        public DataTableSearchBindingModel search { get; set; }
        public List<DataTableColumnBindingModel> columns { get; set; }
    }
}
