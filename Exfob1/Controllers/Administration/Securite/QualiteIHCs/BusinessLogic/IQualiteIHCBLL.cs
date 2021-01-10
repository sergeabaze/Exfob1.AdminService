using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IQualiteIHCBLL
	{
		Task<WebApiListResponse<QualiteIHCListe>> ObtenireQualiteIHCListe();
		Task<WebApiSingleResponse<QualiteIHCReponse>> ObtenireQualiteIHCParId(int Id);
		Task<WebApiSingleResponse<QualiteIHCReponse>> CreationQualiteIHC(QualiteIHCRequest entity);
		Task<WebApiSingleResponse<QualiteIHCReponse>> MisejourQualiteIHC(QualiteIHCEdit entity);
		Task<WebApiSingleResponse<QualiteIHCReponse>> SuppressionQualiteIHC(int id);
	}
}
