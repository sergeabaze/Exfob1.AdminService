using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICodePlaquetteBLL
	{
		Task<WebApiListResponse<CodePlaquetteListe>> ObtenireCodePlaquetteListe();
		Task<WebApiSingleResponse<CodePlaquetteReponse>> ObtenireCodePlaquetteParId(int Id);
		Task<WebApiSingleResponse<CodePlaquetteReponse>> CreationCodePlaquette(CodePlaquetteRequest entity);
		Task<WebApiSingleResponse<CodePlaquetteReponse>> MisejourCodePlaquette(CodePlaquetteEdit entity);
		Task<WebApiSingleResponse<CodePlaquetteReponse>> SuppressionCodePlaquette(int id);
	}
}
