using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INatureConteneurBLL
	{
		Task<WebApiListResponse<NatureConteneurListe>> ObtenireNatureConteneurListe();
		Task<WebApiSingleResponse<NatureConteneurReponse>> ObtenireNatureConteneurParId(int Id);
		Task<WebApiSingleResponse<NatureConteneurReponse>> CreationNatureConteneur(NatureConteneurRequest entity);
		Task<WebApiSingleResponse<NatureConteneurReponse>> MisejourNatureConteneur(NatureConteneurEdit entity);
		Task<WebApiSingleResponse<NatureConteneurReponse>> SuppressionNatureConteneur(int id);
	}
}
