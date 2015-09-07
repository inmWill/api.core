using System;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Client
{
    /// <summary>
    /// Health Plan Information
    /// </summary>
    public class Plan : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public bool Active { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime EndDate { get; set; }

        public PlanType Type { get; set; }
        public State State { get; set; }
    }
}
