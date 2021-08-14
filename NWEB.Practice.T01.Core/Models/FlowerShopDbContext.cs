using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Core.Models
{
    public class FlowerShopDbContext : DbContext
    {
        public FlowerShopDbContext() : base("FlowerShopConnectString")
        {
            Database.SetInitializer<FlowerShopDbContext>(new FlowerShopDbInitializer());
        }

        public virtual DbSet<Category>Categories { get; set; } 
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Color> Colors { get; set; }

    }
}
