using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Enums;

namespace API.Core.Domain.Models.Widget
{
   public class Widget: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public State State { get; set; }
    }
}
