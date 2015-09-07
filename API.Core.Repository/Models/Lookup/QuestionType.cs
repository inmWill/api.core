using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Repository.Interfaces;

namespace API.Core.Repository.Models.Lookup
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionType : IIdentifier, IObjectWithState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public State State { get; set; }

    }
}
