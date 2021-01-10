using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IProduitBLL
	{
		Task<WebApiListResponse<ProduitListe>> ObtenireProduitListe();
		Task<WebApiSingleResponse<ProduitReponse>> ObtenireProduitParId(int Id);
		Task<WebApiSingleResponse<ProduitReponse>> CreationProduit(ProduitRequest entity);
		Task<WebApiSingleResponse<ProduitReponse>> MisejourProduit(ProduitEdit entity);
		Task<WebApiSingleResponse<ProduitReponse>> SuppressionProduit(int id);
	}
}
