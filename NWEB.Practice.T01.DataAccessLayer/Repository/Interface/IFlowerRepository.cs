using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.DataAccessLayer.Repository.Interface
{
    public interface IFlowerRepository : IGenericRepository<Flower>
    {
        List<Flower> GetByCategoryAndFlowerName(string categoryName, string flowerName);
    }
}
