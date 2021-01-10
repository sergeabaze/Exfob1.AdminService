using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISocieteBLL
	{
		Task<WebApiListResponse<SocieteListe>> ObtenireSocieteListe();
		Task<WebApiSingleResponse<SocieteReponse>> ObtenireSocieteParId(int Id);
		Task<WebApiSingleResponse<SocieteReponse>> CreationSociete(SocieteRequest entity);
		Task<WebApiSingleResponse<SocieteReponse>> MisejourSociete(SocieteEdit entity);
		Task<WebApiSingleResponse<SocieteReponse>> SuppressionSociete(int id);
	}
}
