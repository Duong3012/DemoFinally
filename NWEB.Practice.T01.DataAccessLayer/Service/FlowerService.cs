using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.DataAccessLayer.Repository;
using NWEB.Practice.T01.DataAccessLayer.Repository.Interface;

namespace NWEB.Practice.T01.DataAccessLayer.Service
{
    public class FlowerService : GenericRepository<Flower>, IFlowerRepository
    {
        public List<Flower> GetByCategoryAndFlowerName(string categoryName, string flowerName)
        {
            return _dbSet.Where(f => f.FlowerName.ToLower().Contains(flowerName.ToLower())
                                     && f.Category.CategoryName.ToLower().Contains(categoryName.ToLower())).ToList();
        }
    }
}
