using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Client
{
    public class Rule : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public string MemberName { get; set; }

        public string Operator { get; set; }

        public string TargetValue { get; set; }

        public bool Inclusion { get; set; }

        public State State { get; set; }
    }
}
