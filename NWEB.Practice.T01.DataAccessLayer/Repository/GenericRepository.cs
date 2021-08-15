using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.DataAccessLayer.Repository.Interface;

namespace NWEB.Practice.T01.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FlowerShopDbContext _db;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _db = new FlowerShopDbContext();
            _dbSet = _db.Set<T>();
        }
        public bool Add(T obj)
        {
            _dbSet.Add(obj);
            return _db.SaveChanges() >0;
        }

        public bool Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            return _db.SaveChanges() > 0;
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool Update(T obj)
        {
            _dbSet.AddOrUpdate(obj);
            return _db.SaveChanges() > 0;
        }
    }
}
