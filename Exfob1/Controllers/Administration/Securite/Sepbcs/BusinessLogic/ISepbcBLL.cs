using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISepbcBLL
	{
		Task<WebApiListResponse<SepbcListe>> ObtenireSepbcListe();
		Task<WebApiSingleResponse<SepbcReponse>> ObtenireSepbcParId(int Id);
		Task<WebApiSingleResponse<SepbcReponse>> CreationSepbc(SepbcRequest entity);
		Task<WebApiSingleResponse<SepbcReponse>> MisejourSepbc(SepbcEdit entity);
		Task<WebApiSingleResponse<SepbcReponse>> SuppressionSepbc(int id);
	}
}
