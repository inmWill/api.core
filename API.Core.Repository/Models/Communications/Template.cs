using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Communications
{
    /// <summary>
    /// Communication template for use in Email or SMS message
    /// </summary>
    public class Template : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
        public State State { get; set; }
    }
}
