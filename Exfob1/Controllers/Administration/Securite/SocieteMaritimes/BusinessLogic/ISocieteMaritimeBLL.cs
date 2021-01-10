using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISocieteMaritimeBLL
	{
		Task<WebApiListResponse<SocieteMaritimeListe>> ObtenireSocieteMaritimeListe();
		Task<WebApiSingleResponse<SocieteMaritimeReponse>> ObtenireSocieteMaritimeParId(int Id);
		Task<WebApiSingleResponse<SocieteMaritimeReponse>> CreationSocieteMaritime(SocieteMaritimeRequest entity);
		Task<WebApiSingleResponse<SocieteMaritimeReponse>> MisejourSocieteMaritime(SocieteMaritimeEdit entity);
		Task<WebApiSingleResponse<SocieteMaritimeReponse>> SuppressionSocieteMaritime(int id);
	}
}
