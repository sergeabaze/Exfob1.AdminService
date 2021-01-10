using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IContratFournisseurBLL
	{
		Task<WebApiListResponse<ContratFournisseurListe>> ObtenireContratFournisseurListe();
		Task<WebApiSingleResponse<ContratFournisseurReponse>> ObtenireContratFournisseurParId(int Id);
		Task<WebApiSingleResponse<ContratFournisseurReponse>> CreationContratFournisseur(ContratFournisseurRequest entity);
		Task<WebApiSingleResponse<ContratFournisseurReponse>> MisejourContratFournisseur(ContratFournisseurEdit entity);
		Task<WebApiSingleResponse<ContratFournisseurReponse>> SuppressionContratFournisseur(int id);
	}
}
