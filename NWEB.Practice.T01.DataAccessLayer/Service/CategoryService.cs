using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.DataAccessLayer.Repository;
using NWEB.Practice.T01.DataAccessLayer.Repository.Interface;

namespace NWEB.Practice.T01.DataAccessLayer.Service
{
    public class CategoryService : GenericRepository<Category>,ICategoryRepository
    {

    }
}
