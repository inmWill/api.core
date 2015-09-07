using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Client
{
    /// <summary>
    /// DB table to track surcharge components for the client
    /// Includes collection of surcharge rules
    /// </summary>
    public class Surcharge : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int Frequency { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<Rule> Rules { get; set; }
        public State State { get; set; }
    }
}
