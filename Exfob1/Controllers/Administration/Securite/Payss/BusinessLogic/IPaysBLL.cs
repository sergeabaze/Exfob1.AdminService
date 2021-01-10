using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPaysBLL
	{
		Task<WebApiListResponse<PaysListe>> ObtenirePaysListe();
		Task<WebApiSingleResponse<PaysReponse>> ObtenirePaysParId(int Id);
		Task<WebApiSingleResponse<PaysReponse>> CreationPays(PaysRequest entity);
		Task<WebApiSingleResponse<PaysReponse>> MisejourPays(PaysEdit entity);
		Task<WebApiSingleResponse<PaysReponse>> SuppressionPays(int id);
	}
}
