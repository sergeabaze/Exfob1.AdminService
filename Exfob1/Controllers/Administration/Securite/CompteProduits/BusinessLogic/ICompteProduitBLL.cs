using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICompteProduitBLL
	{
		Task<WebApiListResponse<CompteProduitListe>> ObtenireCompteProduitListe();
		Task<WebApiSingleResponse<CompteProduitReponse>> ObtenireCompteProduitParId(int Id);
		Task<WebApiSingleResponse<CompteProduitReponse>> CreationCompteProduit(CompteProduitRequest entity);
		Task<WebApiSingleResponse<CompteProduitReponse>> MisejourCompteProduit(CompteProduitEdit entity);
		Task<WebApiSingleResponse<CompteProduitReponse>> SuppressionCompteProduit(int id);
	}
}
