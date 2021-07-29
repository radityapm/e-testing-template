using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Libs
{
    public class PagedResult<T>
    {
        public int Total { get; set; } = 0;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 15;

        public int TotalPages { get; set; } = 1;

        public List<T> Items { get; set; }

        public PagedResult(List<T> items, int total, int page, int pageSize)
        {
            Total = total;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(Total / (double)pageSize);
            Items = items;
        }
    }
}
