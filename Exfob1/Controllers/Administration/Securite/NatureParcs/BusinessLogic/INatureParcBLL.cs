using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INatureParcBLL
	{
		Task<WebApiListResponse<NatureParcListe>> ObtenireNatureParcListe();
		Task<WebApiSingleResponse<NatureParcReponse>> ObtenireNatureParcParId(int Id);
		Task<WebApiSingleResponse<NatureParcReponse>> CreationNatureParc(NatureParcRequest entity);
		Task<WebApiSingleResponse<NatureParcReponse>> MisejourNatureParc(NatureParcEdit entity);
		Task<WebApiSingleResponse<NatureParcReponse>> SuppressionNatureParc(int id);
	}
}
