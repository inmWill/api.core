using System;

namespace API.Core.Domain.Models.Base
{
    public abstract class BaseEntity
    {
        public int? ModifiedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string IpAddress { get; set; }
    }
}

