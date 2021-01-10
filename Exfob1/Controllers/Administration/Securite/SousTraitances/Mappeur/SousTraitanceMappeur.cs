using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SousTraitanceMappeur : Profile
	{
		public SousTraitanceMappeur()
		{
			CreateMap<SousTraitance, SousTraitanceListe>();
			CreateMap<SousTraitance, SousTraitanceReponse>();
			CreateMap<SousTraitanceEdit, SousTraitance>();
			CreateMap<SousTraitanceRequest, SousTraitance>();
		}
	}
}
