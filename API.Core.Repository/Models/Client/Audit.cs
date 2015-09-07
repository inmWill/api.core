using System;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Client
{
    public class Audit : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public AuditType AuditType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public State State { get; set; }
    }
}
