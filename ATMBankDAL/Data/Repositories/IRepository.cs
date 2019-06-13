using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ATMBankDAL.Data.Repositories
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Add(IList<T> entities);
        T GetOne(int? id);
        T GetOne(Expression<Func<T, bool>> where);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
    }
}
