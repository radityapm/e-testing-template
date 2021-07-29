using MasterService.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Libs
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<InventoryModel> Inventories { get; set; }

        /*
         * Set updated date timestamp when batch order record are updated
         */
        //private void AddTimeStamps()
        //{
        //    var entities = ChangeTracker.Entries()
        //            .Where(x => x.Entity is BatchOrder && (x.State == EntityState.Modified));

        //    foreach (var entity in entities)
        //    {
        //        var now = DateTime.UtcNow;

        //        ((BatchOrder)entity.Entity).UpdatedDate = now;
        //    }
        //}
    }
}
