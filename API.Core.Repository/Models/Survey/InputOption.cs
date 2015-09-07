using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class InputOption : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
        public string value { get; set; }

        public State State { get; set; }
    }
}
