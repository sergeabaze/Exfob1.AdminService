using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IRotationBLL
	{
		Task<WebApiListResponse<RotationListe>> ObtenireRotationListe();
		Task<WebApiSingleResponse<RotationReponse>> ObtenireRotationParId(int Id);
		Task<WebApiSingleResponse<RotationReponse>> CreationRotation(RotationRequest entity);
		Task<WebApiSingleResponse<RotationReponse>> MisejourRotation(RotationEdit entity);
		Task<WebApiSingleResponse<RotationReponse>> SuppressionRotation(int id);
	}
}
