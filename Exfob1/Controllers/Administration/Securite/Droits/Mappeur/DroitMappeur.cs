using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class DroitMappeur : Profile
	{
		public DroitMappeur()
		{
			CreateMap<Droit, DroitListe>();
			CreateMap<Droit, DroitReponse>();
			CreateMap<DroitEdit, Droit>();
			CreateMap<DroitRequest, Droit>();
		}
	}
}
