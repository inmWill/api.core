using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Service.Helpers;
using API.Core.Repository.Models.Widget;

namespace API.Core.Service.Interfaces
{
    public interface IWidgetService: IBaseServiceApi<Widget, Domain.Models.Widget.Widget>
    {
    }
}
