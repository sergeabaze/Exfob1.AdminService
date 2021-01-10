using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IGroupeBLL
	{
		Task<WebApiListResponse<GroupeListe>> ObtenireGroupeListe();
		Task<WebApiSingleResponse<GroupeReponse>> ObtenireGroupeParId(int Id);
		Task<WebApiSingleResponse<GroupeReponse>> CreationGroupe(GroupeRequest entity);
		Task<WebApiSingleResponse<GroupeReponse>> MisejourGroupe(GroupeEdit entity);
		Task<WebApiSingleResponse<GroupeReponse>> SuppressionGroupe(int id);
	}
}
