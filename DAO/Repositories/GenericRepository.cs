using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAO.Contexts;

namespace DAO.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int page = 0, int pagesize = 20)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }




            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip(page*pagesize).Take(pagesize);

            return query.ToList();
        }


        public virtual int Count(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            try
            {
                if (filter != null)
                {
                    return context.Set<TEntity>().Where(filter).Count();
                }
                return context.Set<TEntity>().Count();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public virtual TEntity GetFirst(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                    
                var consulta =  context.Set<TEntity>().Where(filter);
                if(!String.IsNullOrEmpty(includeProperties))
                foreach (var p in includeProperties.Split(','))
                {
                    consulta = consulta.Include(p);
                }
                if (orderBy != null)
                {
                    return orderBy(consulta).FirstOrDefault();
                }
                return consulta.FirstOrDefault();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void InsertMany(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
