using API.Core.Domain.InputModels;
using API.Core.Repository.Models.Import;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    /// <summary>
    /// Client Business Services
    /// Base crud provided by BaseServiceApi
    /// Extend this interface to add new features
    /// </summary>
    public interface IClientImportRecordService : IBaseServiceApi<ClientImportRecord, API.Core.Domain.Models.Import.ClientImportRecord>
    {
        API.Core.Domain.Models.Import.ClientImportRecord GetClientImportRecordByRegistrationModel(AppUserRegistrationModel registrationModel);
    }
}
