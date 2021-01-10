using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeFournisseurBLL
	{
		Task<WebApiListResponse<TypeFournisseurListe>> ObtenireTypeFournisseurListe();
		Task<WebApiSingleResponse<TypeFournisseurReponse>> ObtenireTypeFournisseurParId(int Id);
		Task<WebApiSingleResponse<TypeFournisseurReponse>> CreationTypeFournisseur(TypeFournisseurRequest entity);
		Task<WebApiSingleResponse<TypeFournisseurReponse>> MisejourTypeFournisseur(TypeFournisseurEdit entity);
		Task<WebApiSingleResponse<TypeFournisseurReponse>> SuppressionTypeFournisseur(int id);
	}
}
