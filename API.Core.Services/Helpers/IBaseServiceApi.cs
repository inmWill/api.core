using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Repository.Interfaces;

namespace API.Core.Service.Helpers
{
    public interface IBaseServiceApi<T, TDest> 
        where T : class, IIdentifier
        where TDest : class
    {
        IEnumerable<TDest> Get();
        TDest Get(int id);
        TDest Post(TDest value);
        int Put(TDest value);
        int Delete(int id);
        int Delete(TDest value);
        IEnumerable<TDest> Filter(Expression<Func<T, bool>> predicate);
    }
}
