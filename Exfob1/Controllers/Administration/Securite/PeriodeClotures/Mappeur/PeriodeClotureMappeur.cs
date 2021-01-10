using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PeriodeClotureMappeur : Profile
	{
		public PeriodeClotureMappeur()
		{
			CreateMap<PeriodeCloture, PeriodeClotureListe>();
			CreateMap<PeriodeCloture, PeriodeClotureReponse>();
			CreateMap<PeriodeClotureEdit, PeriodeCloture>();
			CreateMap<PeriodeClotureRequest, PeriodeCloture>();
		}
	}
}
