using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SousFamilleMappeur : Profile
	{
		public SousFamilleMappeur()
		{
			CreateMap<SousFamille, SousFamilleListe>();
			CreateMap<SousFamille, SousFamilleReponse>();
			CreateMap<SousFamilleEdit, SousFamille>();
			CreateMap<SousFamilleRequest, SousFamille>();
		}
	}
}
