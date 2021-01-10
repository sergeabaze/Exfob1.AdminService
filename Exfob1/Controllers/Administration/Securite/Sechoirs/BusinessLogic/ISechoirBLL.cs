using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISechoirBLL
	{
		Task<WebApiListResponse<SechoirListe>> ObtenireSechoirListe();
		Task<WebApiSingleResponse<SechoirReponse>> ObtenireSechoirParId(int Id);
		Task<WebApiSingleResponse<SechoirReponse>> CreationSechoir(SechoirRequest entity);
		Task<WebApiSingleResponse<SechoirReponse>> MisejourSechoir(SechoirEdit entity);
		Task<WebApiSingleResponse<SechoirReponse>> SuppressionSechoir(int id);
	}
}
