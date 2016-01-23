using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Repository.Interfaces;
using AutoMapper;
using NLog;

namespace API.Core.Service.Helpers
{
    /// <summary>
    /// Base class for CRUD operations for services
    /// Requires IRepository
    /// Converts between EF and Domain objects
    /// </summary>
    /// <typeparam name="T">Repository Model</typeparam>
    /// <typeparam name="TDest">Domain Model</typeparam>
    /// Includes is used to define relationship mappings
    public class BaseServiceApi<T, TDest> : IBaseServiceApi<T, TDest>
        where T : class, IIdentifier
        where TDest : class
    {
        protected readonly IRepository DataRepository;
        protected string[] Includes { get; set; }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public BaseServiceApi(IRepository dataRepository)
        {
            if (dataRepository == null)
            {
                throw new ArgumentNullException("dataRepository");
            }
            DataRepository = dataRepository;
        }

        public virtual IEnumerable<TDest> Get()
        {
            try
            {
                var entities = DataRepository.All<T>(Includes);
                return Mapper.Map<IEnumerable<TDest>>(entities);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Retrieving Entities: {0}", ex.InnerException);
                throw;
            }

        }

        public TDest Get(int id)
        {
            try
            {
                var entity = DataRepository.Find<T>(t => t.Id == id, Includes);
                return Mapper.Map<TDest>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Retrieving Entity: {0}", ex.InnerException);
                throw;
            }
        }

        public virtual TDest Post(TDest value)
        {
            try
            {
                var postValue = Mapper.Map<T>(value);
                var entity = DataRepository.Create<T>(postValue);
                return Mapper.Map<TDest>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Creating Entity: {0}", ex.InnerException);
                throw;
            }
        }

        public virtual int Put(TDest value)
        {
            try
            {
                var putValue = Mapper.Map<T>(value); 
                return DataRepository.Update<T>(putValue);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Updating Entity: {0}", ex.InnerException);
                throw;
            }
        }

        public virtual int Delete(int id)
        {
            try
            {
                return DataRepository.Delete<T>(t => t.Id == id);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Deleteting Entity: {0}", ex.InnerException);
                throw;
            }
        }

        public virtual int Delete(TDest value)
        {
            try
            {
                var deleteValue = Mapper.Map<T>(value);
                return Delete(deleteValue.Id);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Deleteting Entity: {0}", ex.InnerException);
                throw;
            }
        }

        public virtual IEnumerable<TDest> Filter(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entities = DataRepository.Filter<T>(predicate, Includes);
                return Mapper.Map<IEnumerable<TDest>>(entities);
            }
            catch (Exception ex)
            {
                Logger.Error("BaseServiceApi - Error Retrieving Entities: {0}", ex.InnerException);
                throw;
            }

        }

    }
}
