using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {                
        }
        public DbSet<InventoryModel> Inventories { get; set; }
    }
}
