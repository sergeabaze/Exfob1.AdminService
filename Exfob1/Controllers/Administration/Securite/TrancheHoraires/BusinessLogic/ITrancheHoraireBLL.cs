using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITrancheHoraireBLL
	{
		Task<WebApiListResponse<TrancheHoraireListe>> ObtenireTrancheHoraireListe();
		Task<WebApiSingleResponse<TrancheHoraireReponse>> ObtenireTrancheHoraireParId(int Id);
		Task<WebApiSingleResponse<TrancheHoraireReponse>> CreationTrancheHoraire(TrancheHoraireRequest entity);
		Task<WebApiSingleResponse<TrancheHoraireReponse>> MisejourTrancheHoraire(TrancheHoraireEdit entity);
		Task<WebApiSingleResponse<TrancheHoraireReponse>> SuppressionTrancheHoraire(int id);
	}
}
