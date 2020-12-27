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
        Task<WebApiSingleResponse<UtilisateurForEditReponse>> ObtenireUtilisateurEditParId(int Id, int siteOperationid);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> CreationUtilisateur(UtilisateurRequestCreate entity, int id);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourUtilisateur(UtilisateurRequestEdit entity, int siteoperationid, int id);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourMotPasse(UtilisateurPassWordRequest request, int utilisateurid);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourActivationCompte(UtilisateurActivationRequest request, int utilisateurid);
        Task<WebApiSingleResponse<UtilisateurRequestReponse>> SuppressionUtilisateur(int id);
        Task<WebApiSingleResponse<UtilisateurLoginReponse>> ObtenireUtilisateurLogin(UtilisateurLoginEdit request);

    }
}
