using Exfob1.Models;
using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic
{
    public interface IUtilisateurBLL
    {
        Task<WebApiListResponse<UtilisateurList>> ObtenireUtilisateurListe(int siteOperationId);
        Task<WebApiSingleResponse<UtilisateurReponse>> ObtenireUtilisateurParId(int Id);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> CreationUtilisateur(UtilisateurCreate entity, int id);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourUtilisateur(UtilisateurEdit entity, int siteoperationid, int id);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> SuppressionUtilisateur(int id);

    }
}
