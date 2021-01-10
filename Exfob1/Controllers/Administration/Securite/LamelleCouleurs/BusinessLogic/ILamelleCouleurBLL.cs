using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ILamelleCouleurBLL
	{
		Task<WebApiListResponse<LamelleCouleurListe>> ObtenireLamelleCouleurListe();
		Task<WebApiSingleResponse<LamelleCouleurReponse>> ObtenireLamelleCouleurParId(int Id);
		Task<WebApiSingleResponse<LamelleCouleurReponse>> CreationLamelleCouleur(LamelleCouleurRequest entity);
		Task<WebApiSingleResponse<LamelleCouleurReponse>> MisejourLamelleCouleur(LamelleCouleurEdit entity);
		Task<WebApiSingleResponse<LamelleCouleurReponse>> SuppressionLamelleCouleur(int id);
	}
}
