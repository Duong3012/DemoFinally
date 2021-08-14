using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.DataAccessLayer.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        T FindById(int id);
        IList<T> GetAll();
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
    }
}
