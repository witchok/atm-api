using ATMBankDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace ATMBankDAL.Data.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly ATMBankContext _db;
        protected ATMBankContext Context => _db;

        public BaseRepository() : this(new ATMBankContext())
        {
        }
        public BaseRepository(ATMBankContext context)
        {
            _db = context;
            _table = _db.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _db.SaveChanges();
        }

        public int Add(IList<T> entities)
        {
            _table.AddRange(entities);
            return _db.SaveChanges();
        }

        public List<T> GetAll() => _table.ToList();

        public T GetOne(int? id) => _table.Find(id);

        public List<T> GetSome(Expression<Func<T, bool>> where) => _table.Where(where).ToList();

        public void Dispose()
        {
            _db?.Dispose();
        }

        public T GetOne(Expression<Func<T, bool>> where) => _table.FirstOrDefault(where);
    }
}
