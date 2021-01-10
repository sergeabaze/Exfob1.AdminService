using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPortArriveBLL
	{
		Task<WebApiListResponse<PortArriveListe>> ObtenirePortArriveListe();
		Task<WebApiSingleResponse<PortArriveReponse>> ObtenirePortArriveParId(int Id);
		Task<WebApiSingleResponse<PortArriveReponse>> CreationPortArrive(PortArriveRequest entity);
		Task<WebApiSingleResponse<PortArriveReponse>> MisejourPortArrive(PortArriveEdit entity);
		Task<WebApiSingleResponse<PortArriveReponse>> SuppressionPortArrive(int id);
	}
}
