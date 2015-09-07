using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class Dialog : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string DialogText { get; set; }
        public State State { get; set; }
    }
}
