using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Entitys.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entity.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private DbContext _dbContext;
        public Repository(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
            _dbContext = _contextFactory.CreateDbContext();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Unspecified,
            CancellationToken cancellationToken = default)
        {
            IDbContextTransaction dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return dbContextTransaction;
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbContext.Set<T>();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await GetListAsync(false);
        }

        public async Task<List<T>> GetListAsync(int skip, int take)
        {
            IQueryable<T> query = _dbContext.Set<T>().Skip(skip * take).Take(take);
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetListAsync(bool asNoTracking)
        {
            Func<IQueryable<T>, IIncludableQueryable<T, object>> nullValue = null;
            return await GetListAsync(nullValue, asNoTracking);
        }

        public async Task<List<T>> GetListAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)
        {
            return await GetListAsync(includes, false);
        }

        public async Task<List<T>> GetListAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes, bool asNoTracking)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            List<T> entities = await query.ToListAsync();

            return entities;
        }

        [Obsolete]
        public async Task<List<T>> GetEntityListAsync(Expression<Func<T, bool>> condition, bool asNoTracking = false)
        {
            return await GetListAsync(condition, asNoTracking);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> condition)
        {
            return await GetListAsync(condition, false);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> condition, bool asNoTracking)
        {
            return await GetListAsync(condition, null, asNoTracking);
        }

        public async Task<List<T>> GetListAsync(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            List<T> entities = await query.ToListAsync();

            return entities;
        }

        [Obsolete]
        public async Task<List<T>> GetEntityListAsync(Specification<T> specification, bool asNoTracking = false)
        {
            return await GetListAsync(specification, asNoTracking);
        }

        public async Task<List<T>> GetListAsync(Specification<T> specification)
        {
            return await GetListAsync(specification, false);
        }

        public async Task<List<T>> GetListAsync(Specification<T> specification, bool asNoTracking)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            T enity = await GetByIdAsync(id, false);
            return enity;
        }

        public async Task<T> GetByIdAsync(object id, bool asNoTracking)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            T enity = await GetByIdAsync(id, null, asNoTracking);
            return enity;
        }

        public async Task<T> GetByIdAsync(object id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            T enity = await GetByIdAsync(id, includes, false);
            return enity;
        }

        public async Task<T> GetByIdAsync(object id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes, bool asNoTracking = false)

        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            IEntityType entityType = _dbContext.Model.FindEntityType(typeof(T));

            string primaryKeyName = entityType.FindPrimaryKey().Properties.Select(p => p.Name).FirstOrDefault();
            Type primaryKeyType = entityType.FindPrimaryKey().Properties.Select(p => p.ClrType).FirstOrDefault();

            if (primaryKeyName == null || primaryKeyType == null)
            {
                throw new ArgumentException("Entity does not have any primary key defined", nameof(id));
            }

            object primayKeyValue = null;

            try
            {
                primayKeyValue = Convert.ChangeType(id, primaryKeyType, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException($"You can not assign a value of type {id.GetType()} to a property of type {primaryKeyType}");
            }

            ParameterExpression pe = Expression.Parameter(typeof(T), "entity");
            MemberExpression me = Expression.Property(pe, primaryKeyName);
            ConstantExpression constant = Expression.Constant(primayKeyValue, primaryKeyType);
            BinaryExpression body = Expression.Equal(me, constant);
            Expression<Func<T, bool>> expressionTree = Expression.Lambda<Func<T, bool>>(body, new[] { pe });

            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            T enity = await query.FirstOrDefaultAsync(expressionTree);
            return enity;
        }


        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> condition, bool asNoTracking = false)
        {
            return await GetAsync(condition, asNoTracking);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condition)
        {
            return await GetAsync(condition, null, false);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condition, bool asNoTracking)
        {
            return await GetAsync(condition, null, asNoTracking);
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)

        {
            return await GetAsync(condition, includes, false);
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking)

        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Specification<T> specification)
        {
            return await GetAsync(specification, false);
        }

        public async Task<T> GetAsync(Specification<T> specification, bool asNoTracking)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync()
        {
            return await ExistsAsync(null);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition == null)
            {
                return await query.AnyAsync();
            }

            bool isExists = await query.AnyAsync(condition);
            return isExists;
        }       

        public async Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntityEntry<T> trackedEntity = _dbContext.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity == entity);

            if (trackedEntity == null)
            {
                IEntityType entityType = _dbContext.Model.FindEntityType(typeof(T));

                if (entityType == null)
                {
                    throw new InvalidOperationException($"{typeof(T).Name} is not part of EF Core DbContext model");
                }

                string primaryKeyName = entityType.FindPrimaryKey().Properties.Select(p => p.Name).FirstOrDefault();

                if (primaryKeyName != null)
                {
                    Type primaryKeyType = entityType.FindPrimaryKey().Properties.Select(p => p.ClrType).FirstOrDefault();

                    object primaryKeyDefaultValue = primaryKeyType.IsValueType ? Activator.CreateInstance(primaryKeyType) : null;

                    object primaryValue = entity.GetType().GetProperty(primaryKeyName).GetValue(entity, null);

                    if (primaryKeyDefaultValue.Equals(primaryValue))
                    {
                        throw new InvalidOperationException("The primary key value of the entity to be updated is not valid.");
                    }
                }

                _dbContext.Set<T>().Update(entity);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync()
        {
            int count = await _dbContext.Set<T>().CountAsync();
            return count;
        }

        public async Task<int> GetCountAsync(params Expression<Func<T, bool>>[] conditions)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (conditions == null)
                return await query.CountAsync();

            foreach (Expression<Func<T, bool>> expression in conditions)
            {
                query = query.Where(expression);
            }

            return await query.CountAsync();
        }

        public async Task<int> GetintCountAsync()
        {
            int count = await _dbContext.Set<T>().CountAsync();
            return count;
        }

        public async Task<int> GetintCountAsync(params Expression<Func<T, bool>>[] conditions)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (conditions == null)
            {
                return await query.CountAsync();
            }

            foreach (Expression<Func<T, bool>> expression in conditions)
            {
                query = query.Where(expression);
            }

            return await query.CountAsync();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
        }

        public void ResetContextState()
        {
#if NETCOREAPP3_1
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                            .ForEach(e => e.State = EntityState.Detached);
#else
            _dbContext.ChangeTracker.Clear();
#endif
        }

        public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            var x = typeof(T);
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
