using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IMotifBLL
	{
		Task<WebApiListResponse<MotifListe>> ObtenireMotifListe();
		Task<WebApiSingleResponse<MotifReponse>> ObtenireMotifParId(int Id);
		Task<WebApiSingleResponse<MotifReponse>> CreationMotif(MotifRequest entity);
		Task<WebApiSingleResponse<MotifReponse>> MisejourMotif(MotifEdit entity);
		Task<WebApiSingleResponse<MotifReponse>> SuppressionMotif(int id);
	}
}
