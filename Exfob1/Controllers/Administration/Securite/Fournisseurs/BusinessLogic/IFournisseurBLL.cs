using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IFournisseurBLL
	{
		Task<WebApiListResponse<FournisseurListe>> ObtenireFournisseurListe();
		Task<WebApiSingleResponse<FournisseurReponse>> ObtenireFournisseurParId(int Id);
		Task<WebApiSingleResponse<FournisseurReponse>> CreationFournisseur(FournisseurRequest entity);
		Task<WebApiSingleResponse<FournisseurReponse>> MisejourFournisseur(FournisseurEdit entity);
		Task<WebApiSingleResponse<FournisseurReponse>> SuppressionFournisseur(int id);
	}
}
