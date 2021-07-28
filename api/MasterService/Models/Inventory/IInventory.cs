using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public interface IInventory
    {
        List<InventoryModel> GetInventories();
        InventoryModel GetInventory(int id);

    }
}
