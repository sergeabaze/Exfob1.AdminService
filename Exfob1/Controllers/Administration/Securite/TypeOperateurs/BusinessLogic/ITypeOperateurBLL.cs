using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeOperateurBLL
	{
		Task<WebApiListResponse<TypeOperateurListe>> ObtenireTypeOperateurListe();
		Task<WebApiSingleResponse<TypeOperateurReponse>> ObtenireTypeOperateurParId(int Id);
		Task<WebApiSingleResponse<TypeOperateurReponse>> CreationTypeOperateur(TypeOperateurRequest entity);
		Task<WebApiSingleResponse<TypeOperateurReponse>> MisejourTypeOperateur(TypeOperateurEdit entity);
		Task<WebApiSingleResponse<TypeOperateurReponse>> SuppressionTypeOperateur(int id);
	}
}
