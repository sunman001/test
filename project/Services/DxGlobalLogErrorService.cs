using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interface;
using Infrastructure;

namespace Services
{
    public class DxGlobalLogErrorService : GenericService<DxGlobalLogError>, IDxGlobalLogErrorService
    {
        private readonly IDxGlobalLogErrorRepository _repository;
        public DxGlobalLogErrorService(IDxGlobalLogErrorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IPagedList<DxGlobalLogError> FindPagedListBySql(string orderby, string where = "", object paramerters = null, int pageIndex = 0, int pageSize = 20)
        {
            return _repository.FindPagedListBySql(orderby,where,paramerters,pageIndex,pageSize);
        }

    }
}
