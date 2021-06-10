using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entity.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Begin a new database transaction.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> to be applied on this transaction. (Default to <see cref="IsolationLevel.Unspecified"/>).</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns a <see cref="IDbContextTransaction"/> instance.</returns>
        Task<IDbContextTransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Unspecified,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets <see cref="IQueryable{T}"/> of the entity.
        /// </summary>
        /// <returns>Returns <see cref="IQueryable{T}"/>.</returns>
        IQueryable<TEntity> GetQueryable();



        /// <summary>
        /// This method returns <see cref="List{T}"/> without any filter. Call only when you want to pull all the data from the source.
        /// </summary>
        /// <returns>Returns <see cref="Task"/> of <see cref="List{T}"/>.</returns>
        Task<List<TEntity>> GetListAsync();

        /// <summary>
        /// This method returns <see cref="List{T}"/> without any filter. Call only when you want to pull all the data from the source.
        /// </summary>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="Task"/> of <see cref="List{T}"/>.</returns>
        Task<List<TEntity>> GetListAsync(bool asNoTracking);

        /// <summary>
        /// This method returns <see cref="List{T}"/> without any filter. Call only when you want to pull all the data from the source.
        /// </summary>
        /// <param name="includes">Navigation properties to be loaded.</param>
        /// <returns>Returns <see cref="Task"/> of <see cref="List{T}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes);

        /// <summary>
        /// This method returns <see cref="List{T}"/> without any filter. Call only when you want to pull all the data from the source.
        /// </summary>
        /// <param name="includes">Navigation properties to be loaded.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="Task"/> of <see cref="List{T}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes, bool asNoTracking);

       
        /// <summary>
        /// This method takes a <see cref="Expression{Func}"/> as parameter and returns <see cref="List{TEntity}"/>.
        /// </summary>
        /// <param name="condition">The condition on which entity list will be returned.</param>
        /// <returns>Returns <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> condition);

        Task<List<TEntity>> GetListAsync(int skip, int take);

        /// <summary>
        /// This method takes a <see cref="Expression{Func}"/> as parameter and returns <see cref="List{TEntity}"/>.
        /// </summary>
        /// <param name="condition">The condition on which entity list will be returned.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> condition, bool asNoTracking);

        /// <summary>
        /// This method takes a <see cref="Expression{Func}"/> as parameter and returns <see cref="List{TEntity}"/>.
        /// </summary>
        /// <param name="condition">The condition on which entity list will be returned.</param>
        /// <param name="includes">Navigation properties to be loaded.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking = false);

        
        /// <summary>
        /// This method takes an object of <see cref="Specification{TEntity}"/> as parameter and returns <see cref="List{TEntity}"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="specification">A <see cref="Specification{TEntity}"/> <see cref="object"/> which contains all the conditions and criteria
        /// on which data will be returned.
        /// </param>
        /// <returns>Returns <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Specification<TEntity> specification);

        /// <summary>
        /// This method takes an object of <see cref="Specification{TEntity}"/> as parameter and returns <see cref="List{TEntity}"/>.
        /// </summary>
        /// <param name="specification">A <see cref="Specification{TEntity}"/> <see cref="object"/> which contains all the conditions and criteria
        /// on which data will be returned.
        /// </param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetListAsync(Specification<TEntity> specification, bool asNoTracking);



        /// <summary>
        /// This method takes <paramref name="id"/> which is the primary key value of the entity and returns the entity
        /// if found otherwise <em>NULL</em>.
        /// </summary>
        /// <param name="id">The primary key value of the entity.</param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// This method takes <paramref name="id"/> which is the primary key value of the entity and returns the entity
        /// if found otherwise <em>NULL</em>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The primary key value of the entity.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetByIdAsync(object id, bool asNoTracking);

        /// <summary>
        /// This method takes <paramref name="id"/> which is the primary key value of the entity and returns the entity
        /// if found otherwise <em>NULL</em>.
        /// </summary>
        /// <param name="id">The primary key value of the entity.</param>
        /// <param name="includes">The navigation properties to be loaded.</param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetByIdAsync(object id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes);

        /// <summary>
        /// This method takes <paramref name="id"/> which is the primary key value of the entity and returns the entity
        /// if found otherwise <em>NULL</em>.
        /// </summary>
        /// <param name="id">The primary key value of the entity.</param>
        /// <param name="includes">The navigation properties to be loaded.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetByIdAsync(object id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes, bool asNoTracking);

        /// <summary>
        /// This method takes <see cref="Expression{Func}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="condition">The conditon on which entity will be returned.</param>
        /// <returns>Returns <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// This method takes <see cref="Expression{Func}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="condition">The conditon on which entity will be returned.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> condition, bool asNoTracking);

        /// <summary>
        /// This method takes <see cref="Expression{Func}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="condition">The conditon on which entity will be returned.</param>
        /// <param name="includes">Navigation properties to be loaded.</param>
        /// <returns>Returns <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes);

        /// <summary>
        /// This method takes <see cref="Expression{Func}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="condition">The conditon on which entity will be returned.</param>
        /// <param name="includes">Navigation properties to be loaded.</param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking);

        /// <summary>
        /// This method takes an <see cref="object"/> of <see cref="Specification{T}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="specification">A <see cref="Specification{TEntity}"/> object which contains all the conditions and criteria
        /// on which data will be returned.
        /// </param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetAsync(Specification<TEntity> specification);

        /// <summary>
        /// This method takes an <see cref="object"/> of <see cref="Specification{T}"/> as parameter and returns <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="specification">A <see cref="Specification{TEntity}"/> object which contains all the conditions and criteria
        /// on which data will be returned.
        /// </param>
        /// <param name="asNoTracking">A <see cref="bool"/> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Defualt value is false i.e trackig is enabled by default.
        /// </param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<TEntity> GetAsync(Specification<TEntity> specification, bool asNoTracking);

        
        /// <summary>
        /// This method checks whether the database table contains any record.
        /// and returns <see cref="Task"/> of <see cref="bool"/>.
        /// </summary>
        /// <returns>Returns <see cref="bool"/>.</returns>
        Task<bool> ExistsAsync();

        /// <summary>
        /// This method takes a predicate based on which existence of the entity will be determined
        /// and returns <see cref="Task"/> of <see cref="bool"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="condition">The condition based on which the existence will checked.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition);

        
        /// <summary>
        /// This method takes <typeparamref name="TEntity"/>, insert it into database and returns <see cref="Task{TResult}"/>.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// This method takes <typeparamref name="TEntity"/>, insert it into the database and returns <see cref="Task"/>.
        /// </summary>
        /// <param name="entities">The entities to be inserted.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);


        /// <summary>
        /// This method takes <typeparamref name="TEntity"/>, send update operation to the database and returns <see cref="void"/>.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task<TEntity>  UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// This method takes <see cref="IEnumerable{TEntity}"/> of entities, send update operation to the database and returns <see cref="void"/>.
        /// </summary>
        /// <param name="entities">The entities to be updated.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        
        /// <summary>
        /// This method takes an entity of type <typeparamref name="TEntity"/>, delete the entity from database and returns <see cref="void"/>.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// This method takes <see cref="IEnumerable{T}"/> of entities, delete those entities from database and returns <see cref="void"/>.
        /// </summary>
        /// <param name="entities">The list of entities to be deleted.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// This method returns all count in <see cref="int"/> type.
        /// </summary>
        /// <returns>Returns <see cref="Task"/> of <see cref="int"/>.</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// This method takes one or more <em>predicates</em> and returns the count in <see cref="int"/> type.
        /// </summary>
        /// <param name="conditions">The condition or conditions based on which count will be done.</param>
        /// <returns>Returns <see cref="Task"/> of <see cref="int"/>.</returns>
        Task<int> GetCountAsync(params Expression<Func<TEntity, bool>>[] conditions);

        /// <summary>
        /// This method returns all count in <see cref="int"/> type.
        /// </summary>
        /// <returns>Retuns <see cref="Task"/> of <see cref="int"/>.</returns>
        Task<int> GetintCountAsync();

        /// <summary>
        /// This method takes one or more <em>predicates</em> and returns the count in <see cref="int"/> type.
        /// </summary>
        /// <param name="conditions">The condition or conditions based on which count will be done.</param>
        /// <returns>Retuns <see cref="Task"/> of <see cref="int"/>.</returns>
        Task<int> GetintCountAsync(params Expression<Func<TEntity, bool>>[] conditions);

        // Context level members

        /// <summary>
        /// Execute raw sql command against the configured database.
        /// </summary>
        /// <param name="sql">The sql string.</param>
        /// <param name="parameters">The paramters in the sql string.</param>
        /// <returns>Returns <see cref="int"/>.</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Execute raw sql command against the configured database asynchronously.
        /// </summary>
        /// <param name="sql">The sql string.</param>
        /// <param name="parameters">The paramters in the sql string.</param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        /// <summary>
        /// Execute raw sql command against the configured database asynchronously.
        /// </summary>
        /// <param name="sql">The sql string.</param>
        /// <param name="parameters">The paramters in the sql string.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reset the DbContext state by removing all the tracked and attached entities.
        /// </summary>
        void ResetContextState();
    }
}
