using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;

namespace API.Core.Service.Services
{
    public class DialogService : BaseServiceApi<API.Core.Repository.Models.Survey.Dialog, Dialog>, IDialogService
    {
        public DialogService(IRepository dataRepository)
            : base(dataRepository) { }
    }
}
