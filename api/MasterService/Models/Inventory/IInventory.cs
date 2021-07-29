using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public interface IInventory
    {
        List<InventoryModel> GetInventories();
        InventoryModel GetInventory(int id);
       //Task<InventoryModel> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    } 
}
