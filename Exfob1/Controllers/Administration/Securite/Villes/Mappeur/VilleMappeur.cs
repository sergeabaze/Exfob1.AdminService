using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class VilleMappeur : Profile
	{
		public VilleMappeur()
		{
			CreateMap<Ville, VilleListe>();
			CreateMap<Ville, VilleReponse>();
			CreateMap<VilleEdit, Ville>();
			CreateMap<VilleRequest, Ville>();
		}
	}
}
