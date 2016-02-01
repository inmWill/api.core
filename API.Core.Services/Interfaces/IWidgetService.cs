using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Service.Helpers;
using API.Core.Repository.Models.Widgets;

namespace API.Core.Service.Interfaces
{
    public interface IWidgetService: IBaseServiceApi<Widget, Domain.Models.Widgets.Widget>
    {
    }
}
