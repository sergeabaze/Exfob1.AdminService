using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPortBLL
	{
		Task<WebApiListResponse<PortListe>> ObtenirePortListe();
		Task<WebApiSingleResponse<PortReponse>> ObtenirePortParId(int Id);
		Task<WebApiSingleResponse<PortReponse>> CreationPort(PortRequest entity);
		Task<WebApiSingleResponse<PortReponse>> MisejourPort(PortEdit entity);
		Task<WebApiSingleResponse<PortReponse>> SuppressionPort(int id);
	}
}
