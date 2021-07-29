//using MasterService.Entities;
using MasterService.Libs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public class InventoryDAL : BaseService<InventoryModel, DatabaseContext>
    {
        public InventoryDAL(DatabaseContext context) : base(context) { }

        public async Task<List<InventoryModel>> Filter(int Page, int PageSize)
        {
            var query = _entity
                        .Select(x => x)
                        .OrderByDescending(x => x.Inventory_item_ID);

            List<InventoryModel> items = await query
                .Skip((Page -1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return items;
        }
        public async Task<InventoryModel> FindOne(int id)
        {
            return await _entity.FindAsync(id);
        }


    }
}