using MovieReview.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet; 
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State != EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            else
            {
                dbEntityEntry.State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity);
        }
    }
}
