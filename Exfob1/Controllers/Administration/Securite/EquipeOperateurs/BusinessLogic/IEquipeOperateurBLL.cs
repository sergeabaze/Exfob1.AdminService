using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IEquipeOperateurBLL
	{
		Task<WebApiListResponse<EquipeOperateurListe>> ObtenireEquipeOperateurListe();
		Task<WebApiSingleResponse<EquipeOperateurReponse>> ObtenireEquipeOperateurParId(int Id);
		Task<WebApiSingleResponse<EquipeOperateurReponse>> CreationEquipeOperateur(EquipeOperateurRequest entity);
		Task<WebApiSingleResponse<EquipeOperateurReponse>> MisejourEquipeOperateur(EquipeOperateurEdit entity);
		Task<WebApiSingleResponse<EquipeOperateurReponse>> SuppressionEquipeOperateur(int id);
	}
}
