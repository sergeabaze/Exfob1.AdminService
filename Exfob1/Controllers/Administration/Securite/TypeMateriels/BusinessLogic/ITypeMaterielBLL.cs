using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeMaterielBLL
	{
		Task<WebApiListResponse<TypeMaterielListe>> ObtenireTypeMaterielListe();
		Task<WebApiSingleResponse<TypeMaterielReponse>> ObtenireTypeMaterielParId(int Id);
		Task<WebApiSingleResponse<TypeMaterielReponse>> CreationTypeMateriel(TypeMaterielRequest entity);
		Task<WebApiSingleResponse<TypeMaterielReponse>> MisejourTypeMateriel(TypeMaterielEdit entity);
		Task<WebApiSingleResponse<TypeMaterielReponse>> SuppressionTypeMateriel(int id);
	}
}
