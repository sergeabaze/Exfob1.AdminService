using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISciesBLL
	{
		Task<WebApiListResponse<SciesListe>> ObtenireSciesListe();
		Task<WebApiSingleResponse<SciesReponse>> ObtenireSciesParId(int Id);
		Task<WebApiSingleResponse<SciesReponse>> CreationScies(SciesRequest entity);
		Task<WebApiSingleResponse<SciesReponse>> MisejourScies(SciesEdit entity);
		Task<WebApiSingleResponse<SciesReponse>> SuppressionScies(int id);
	}
}
