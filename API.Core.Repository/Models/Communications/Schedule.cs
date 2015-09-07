using System;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Communications
{
    public class Schedule : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
        public DateTime SendDate { get; set; }
        public int Frequency { get; set; }
        public bool Recurring { get; set; }
        public State State { get; set; }
    }
}
