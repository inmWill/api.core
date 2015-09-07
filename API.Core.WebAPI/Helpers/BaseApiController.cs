using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;
using API.Core.Repository.Interfaces;

namespace API.Core.Rest.WebAPI.Helpers
{
    public class BaseApiController<T> : ApiController where T : class, IIdentifier
    {
        protected IRepository Repository { get; set; }
        protected string[] Includes { get; set; }

        public BaseApiController(IRepository repository)
        {
            Repository = repository;
        }

        // GET api/<controller>
        public virtual IEnumerable<T> Get()
        {
            return Repository.All<T>(Includes);
        }

        // GET api/<controller>/5
        public virtual T Get(int id)
        {
            return Repository.Find<T>(t => t.Id == id, Includes);
        }

        // POST api/<controller>
        public virtual void Post([FromBody]T value)
        {
            try
            {
                Repository.Update<T>(value);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>
        public virtual void Put([FromBody]T value)
        {
            Repository.Create<T>(value);
        }

        // DELETE api/<controller>/5
        public virtual void Delete(int id)
        {
            Repository.Delete<T>(t => t.Id == id);
        }

        public virtual void Delete([FromBody]T value)
        {
            Delete(value.Id);
        }

        protected IEnumerable GetModelErrors()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }
    }
}