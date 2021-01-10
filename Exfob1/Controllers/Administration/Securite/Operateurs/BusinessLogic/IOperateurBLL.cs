using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IOperateurBLL
	{
		Task<WebApiListResponse<OperateurListe>> ObtenireOperateurListe();
		Task<WebApiSingleResponse<OperateurReponse>> ObtenireOperateurParId(int Id);
		Task<WebApiSingleResponse<OperateurReponse>> CreationOperateur(OperateurRequest entity);
		Task<WebApiSingleResponse<OperateurReponse>> MisejourOperateur(OperateurEdit entity);
		Task<WebApiSingleResponse<OperateurReponse>> SuppressionOperateur(int id);
	}
}
