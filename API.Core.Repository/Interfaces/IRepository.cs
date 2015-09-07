using System;
using System.Linq;
using System.Linq.Expressions;

namespace API.Core.Repository.Interfaces
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets all objects from database
        /// TODO: Convert fully to ASYNC
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All<T>(string[] includes = null) where T : class;

        /// <summary>
        /// Selects a Single Item by specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class;

        /// <summary>
        /// Finds an object by specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T Find<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class;

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specifies the filter</param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class;

        /// <summary>
        /// Gets objects from database with filting and paging.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">Specifies a filter</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">page index.</param>
        /// <param name="size">the page size</param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> PagedFilter<T>(Expression<Func<T, bool>> filter, Expression<Func<T, int>> order, int index = 0, int size = 50, string[] includes = null) where T : class;

        /// <summary>
        /// Checks to see if the object(s) exist in the database.
        /// </summary>
        /// <param name="predicate">Specifies the filter</param>
        /// <returns></returns>
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Creates a new object in the database.
        /// </summary>
        /// <param name="t">Specifies the object to create.</param>
        /// <returns></returns>
        T Create<T>(T t) where T : class;

        /// <summary>
        /// Deletes the object from the database.
        /// </summary>
        /// <param name="t">Specifies an existing object to delete.</param>
        int Delete<T>(T t) where T : class;

        /// <summary>
        /// Deletes objects from database by specified filter predicate. This could be dangerous >>
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Update object in database.
        /// </summary>
        /// <param name="t">Specifies the object to save.</param>
        /// <returns></returns>
        int Update<T>(T t) where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Executes the procedure.
        /// </summary>
        /// <param name="procedureCommand">The procedure command.</param>
        /// <param name="sqlParams">The SQL params.</param>
        void ExecuteProcedure(string procedureCommand, params object[] sqlParams);
    }
}