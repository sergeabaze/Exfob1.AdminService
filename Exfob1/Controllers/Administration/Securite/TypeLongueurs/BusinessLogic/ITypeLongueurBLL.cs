using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeLongueurBLL
	{
		Task<WebApiListResponse<TypeLongueurListe>> ObtenireTypeLongueurListe();
		Task<WebApiSingleResponse<TypeLongueurReponse>> ObtenireTypeLongueurParId(int Id);
		Task<WebApiSingleResponse<TypeLongueurReponse>> CreationTypeLongueur(TypeLongueurRequest entity);
		Task<WebApiSingleResponse<TypeLongueurReponse>> MisejourTypeLongueur(TypeLongueurEdit entity);
		Task<WebApiSingleResponse<TypeLongueurReponse>> SuppressionTypeLongueur(int id);
	}
}
