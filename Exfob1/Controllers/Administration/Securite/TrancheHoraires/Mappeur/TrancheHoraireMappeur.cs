using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TrancheHoraireMappeur : Profile
	{
		public TrancheHoraireMappeur()
		{
			CreateMap<TrancheHoraire, TrancheHoraireListe>();
			CreateMap<TrancheHoraire, TrancheHoraireReponse>();
			CreateMap<TrancheHoraireEdit, TrancheHoraire>();
			CreateMap<TrancheHoraireRequest, TrancheHoraire>();
		}
	}
}
