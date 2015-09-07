using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Lookup;

namespace API.Core.Domain.Models.Event
{
    public class ClientEvent : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public EventType Type { get; set; }

    }
}
