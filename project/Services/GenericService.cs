using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Repositories.Interface;

namespace Services
{
    public abstract class GenericService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        protected GenericService (IRepository<T>repository)
        {
            _repository = repository;
        }  
            
        public bool Delete(string ids)
        {
            return _repository.Delete(ids);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public T FindById(int id)
        {
            return _repository.FindById(id);
        }

        public IPagedList<T> FindPagedList(string orderBy, string where = "", object parameters = null, int pageIndex = 0, int pageSize = 20)
        {
            return _repository.FindPagedList(orderBy,where,parameters,pageIndex,pageSize);
        }

        public int Insert(T entity)
        {
                return _repository.Insert(entity);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
