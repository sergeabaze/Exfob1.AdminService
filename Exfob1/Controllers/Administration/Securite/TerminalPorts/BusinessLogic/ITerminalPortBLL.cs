using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITerminalPortBLL
	{
		Task<WebApiListResponse<TerminalPortListe>> ObtenireTerminalPortListe();
		Task<WebApiSingleResponse<TerminalPortReponse>> ObtenireTerminalPortParId(int Id);
		Task<WebApiSingleResponse<TerminalPortReponse>> CreationTerminalPort(TerminalPortRequest entity);
		Task<WebApiSingleResponse<TerminalPortReponse>> MisejourTerminalPort(TerminalPortEdit entity);
		Task<WebApiSingleResponse<TerminalPortReponse>> SuppressionTerminalPort(int id);
	}
}
