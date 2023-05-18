using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trial.Interface;
using Trial.Models;

namespace Trial.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {


        private Employee_ManagementEntities _Entities = null;
        private DbSet<T> managementEntities = null;
        public GenericRepository()
        {
            this._Entities = new Employee_ManagementEntities();

            managementEntities = _Entities.Set<T>();
        }
        public GenericRepository(Employee_ManagementEntities _Entities)
        {
            this._Entities = _Entities;
            managementEntities = _Entities.Set<T>();
        }
       public List<T> GetAllList()
        {
            return _Entities.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _Entities.Set<T>().Find(id);   
        }
        public void Save()
        {
            _Entities.SaveChanges();
        }
        public void Insert(T obj)
        {
            managementEntities.Add(obj);
        }
        public void Update(T obj)
        {
            managementEntities.Attach(obj);

        }
        public void Delete(int id)
        {
            T delete = managementEntities.Find(id);
            managementEntities.Remove(delete);

        }

    }
}