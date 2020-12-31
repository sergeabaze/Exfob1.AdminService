using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic
{
    public interface ILangueBLL
    {
        Task<WebApiListResponse<LangueListe>> ObtenireLangueListe();
        Task<WebApiSingleResponse<LangueReponse>> ObtenireLangueParId(int Id);
        Task<WebApiSingleResponse<LangueReponse>> CreationLangue(LangueRequest entity);
        Task<WebApiSingleResponse<LangueReponse>> MisejourLangue(LangueEdit entity);
        Task<WebApiSingleResponse<LangueReponse>> SuppressionLangue(int id);
    }
}
