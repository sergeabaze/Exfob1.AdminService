using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IMaterielBLL
	{
		Task<WebApiListResponse<MaterielListe>> ObtenireMaterielListe();
		Task<WebApiSingleResponse<MaterielReponse>> ObtenireMaterielParId(int Id);
		Task<WebApiSingleResponse<MaterielReponse>> CreationMateriel(MaterielRequest entity);
		Task<WebApiSingleResponse<MaterielReponse>> MisejourMateriel(MaterielEdit entity);
		Task<WebApiSingleResponse<MaterielReponse>> SuppressionMateriel(int id);
	}
}
