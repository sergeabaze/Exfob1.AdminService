using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IFamilleBLL
	{
		Task<WebApiListResponse<FamilleListe>> ObtenireFamilleListe();
		Task<WebApiSingleResponse<FamilleReponse>> ObtenireFamilleParId(int Id);
		Task<WebApiSingleResponse<FamilleReponse>> CreationFamille(FamilleRequest entity);
		Task<WebApiSingleResponse<FamilleReponse>> MisejourFamille(FamilleEdit entity);
		Task<WebApiSingleResponse<FamilleReponse>> SuppressionFamille(int id);
	}
}
