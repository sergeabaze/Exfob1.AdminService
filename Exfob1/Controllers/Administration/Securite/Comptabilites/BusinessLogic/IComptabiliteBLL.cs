using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IComptabiliteBLL
	{
		Task<WebApiListResponse<ComptabiliteListe>> ObtenireComptabiliteListe();
		Task<WebApiSingleResponse<ComptabiliteReponse>> ObtenireComptabiliteParId(int Id);
		Task<WebApiSingleResponse<ComptabiliteReponse>> CreationComptabilite(ComptabiliteRequest entity);
		Task<WebApiSingleResponse<ComptabiliteReponse>> MisejourComptabilite(ComptabiliteEdit entity);
		Task<WebApiSingleResponse<ComptabiliteReponse>> SuppressionComptabilite(int id);
	}
}
