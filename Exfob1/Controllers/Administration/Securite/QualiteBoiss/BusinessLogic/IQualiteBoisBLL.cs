using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IQualiteBoisBLL
	{
		Task<WebApiListResponse<QualiteBoisListe>> ObtenireQualiteBoisListe();
		Task<WebApiSingleResponse<QualiteBoisReponse>> ObtenireQualiteBoisParId(int Id);
		Task<WebApiSingleResponse<QualiteBoisReponse>> CreationQualiteBois(QualiteBoisRequest entity);
		Task<WebApiSingleResponse<QualiteBoisReponse>> MisejourQualiteBois(QualiteBoisEdit entity);
		Task<WebApiSingleResponse<QualiteBoisReponse>> SuppressionQualiteBois(int id);
	}
}
