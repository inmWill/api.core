using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using API.Core.Repository.DbContexts;
using API.Core.Repository.Helpers;
using API.Core.Repository.Interfaces;

namespace API.Core.Repository.Repositories
{
    /// <summary>
    /// Generic Repository provider for Entity Framework
    /// See interface for method comments
    /// TODO: Convert fully to ASYNC and remove extraneous methods
    /// </summary>
    public class EntityRepository : IRepository
    {
        private readonly APICoreContext _dbContext;

        /// <summary>
        /// Requires Entity Framework dbContext
        /// </summary>
        /// <param name="dbContext"></param>
        public EntityRepository(APICoreContext dbContext)
        {
            _dbContext = dbContext;

            // Serialize fails with proxied entities
            _dbContext.Configuration.ProxyCreationEnabled = false;

            // Lazy loading causes some issues with endless loops
            _dbContext.Configuration.LazyLoadingEnabled = false;
        }

        public IQueryable<T> All<T>(string[] includes = null) where T : class
        {
            // If relationship items are included we need to handle  TODO: look into a more DRY way of doing this.
            if (includes == null || !includes.Any()) 
                 return _dbContext.Set<T>().AsQueryable();
            
            var query = _dbContext.Set<T>().Include(includes.First());
            //query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.AsQueryable();            
        }

        public T Get<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class
        {
            return All<T>(includes).FirstOrDefault(predicate);
        }

        public virtual T Find<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class
        {
            if (includes == null || !includes.Any()) return _dbContext.Set<T>().FirstOrDefault<T>(predicate);
            var query = _dbContext.Set<T>().Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault<T>(predicate);
        }

        public virtual IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class
        {
            if (includes == null || !includes.Any()) return _dbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
            var query = _dbContext.Set<T>().Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            return query.Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> PagedFilter<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> order, int index = 0, int size = 50, string[] includes = null) where T : class
        {
            var skipCount = index * size;
            IQueryable<T> resultSet;

            if (includes == null || !includes.Any())
            {
                resultSet = predicate != null
                    ? _dbContext.Set<T>().Where<T>(predicate).OrderByWithDirection(order, true).AsQueryable()
                    : _dbContext.Set<T>().OrderByWithDirection(order, true).AsQueryable();
            }
            else
            {
                var query = _dbContext.Set<T>().Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                resultSet = predicate != null ? query.Where<T>(predicate).OrderBy(order).AsQueryable() : query.OrderBy(order).AsQueryable();
            }
            resultSet = skipCount == 0 ? resultSet.Take(size) : resultSet.Skip(skipCount).Take(size);
            return resultSet.AsQueryable();
        }

        public virtual T Create<T>(T TObject) where T : class
        {
            //Inherit from ICreatedOn and IModifiedOn for auto tagging 
            if (TObject is ICreatedOn)
            {
                (TObject as ICreatedOn).CreatedOn = DateTime.UtcNow;
            }

            if (TObject is IModifiedOn)
            {
                (TObject as IModifiedOn).ModifiedOn = DateTime.UtcNow;
            }

            var newEntry = _dbContext.Set<T>().Add(TObject);
            _dbContext.SaveChanges();
            return newEntry;
        }

        public virtual int Delete<T>(T TObject) where T : class
        {
            _dbContext.Set<T>().Remove(TObject);
            return _dbContext.SaveChanges();
        }

        public virtual int Update<T>(T TObject) where T : class
        {
            if (TObject is IModifiedOn)
            {
                (TObject as IModifiedOn).ModifiedOn = DateTime.UtcNow;
            }

            var entry = _dbContext.Entry(TObject);
            _dbContext.Set<T>().Attach(TObject);

            foreach (var item in _dbContext.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = item.Entity;
                item.State = ConvertState(stateInfo.State);
            }

            return _dbContext.SaveChanges();
        }

        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Deleted:
                    return EntityState.Deleted;
                case State.Modified:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
            }
        }

        public virtual int Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach (var obj in objects)
                _dbContext.Set<T>().Remove(obj);
            return _dbContext.SaveChanges();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual void ExecuteProcedure(string procedureCommand, params object[] sqlParams)
        {
            _dbContext.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}