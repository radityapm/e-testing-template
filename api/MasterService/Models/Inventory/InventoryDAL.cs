using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public class InventoryDAL : IInventory
    {
        private InventoryContext _inventoryContext;
        public InventoryDAL(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
       
        public List<InventoryModel> GetInventories()
        {
            return _inventoryContext.Inventories.ToList();
        }

        public InventoryModel GetInventory(int id)
        {
            var inventory = _inventoryContext.Inventories.Find(id);
            return inventory;
        }
    }
}
