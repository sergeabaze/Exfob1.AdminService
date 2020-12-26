using Exfob1.Models;
using Exfob1.Models.Adminstrations.Profiles.Request;
using Exfob1.Models.Adminstrations.Profiles.ResPonse;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic
{
    public interface IProfileBLL
    {
        Task<WebApiListResponse<ProfileListe>> ObtenireProfileListe();
        Task<WebApiSingleResponse<ProfileResponse>> ObtenireProfileParId(int Id);
        Task<WebApiSingleResponse<ProfileResponse>> CreationProfile(ProfileRequest entity);
        Task<WebApiSingleResponse<ProfileResponse>> MisejourProfile(ProfileEdit entity);
        Task<WebApiSingleResponse<ProfileResponse>> SuppressionProfile(int id);
    }
}
