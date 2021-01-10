using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class BanqueMappeur : Profile
	{
		public BanqueMappeur()
		{
			CreateMap<Banque, BanqueListe>();
			CreateMap<Banque, BanqueReponse>();
			CreateMap<BanqueEdit, Banque>();
			CreateMap<BanqueRequest, Banque>();
		}
	}
}
