using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Widgets;
using API.Core.Service.Interfaces;
using API.Core.Service.Services;
using API.Core.Service.Helpers;

namespace API.Core.Service.Services
{
    public class WidgetService: BaseServiceApi<Widget, Domain.Models.Widgets.Widget>, IWidgetService
    {
        public WidgetService(IRepository dataRepository): base(dataRepository)
        {           
        }
    }
}
