using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAllList();
        T GetById(int id);
        void Save();
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        
    }
}