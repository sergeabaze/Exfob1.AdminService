using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPeriodeClotureBLL
	{
		Task<WebApiListResponse<PeriodeClotureListe>> ObtenirePeriodeClotureListe();
		Task<WebApiSingleResponse<PeriodeClotureReponse>> ObtenirePeriodeClotureParId(int Id);
		Task<WebApiSingleResponse<PeriodeClotureReponse>> CreationPeriodeCloture(PeriodeClotureRequest entity);
		Task<WebApiSingleResponse<PeriodeClotureReponse>> MisejourPeriodeCloture(PeriodeClotureEdit entity);
		Task<WebApiSingleResponse<PeriodeClotureReponse>> SuppressionPeriodeCloture(int id);
	}
}
