using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISousFamilleBLL
	{
		Task<WebApiListResponse<SousFamilleListe>> ObtenireSousFamilleListe();
		Task<WebApiSingleResponse<SousFamilleReponse>> ObtenireSousFamilleParId(int Id);
		Task<WebApiSingleResponse<SousFamilleReponse>> CreationSousFamille(SousFamilleRequest entity);
		Task<WebApiSingleResponse<SousFamilleReponse>> MisejourSousFamille(SousFamilleEdit entity);
		Task<WebApiSingleResponse<SousFamilleReponse>> SuppressionSousFamille(int id);
	}
}
