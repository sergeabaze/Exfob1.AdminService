using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CodePlaquetteMappeur : Profile
	{
		public CodePlaquetteMappeur()
		{
			CreateMap<CodePlaquette, CodePlaquetteListe>();
			CreateMap<CodePlaquette, CodePlaquetteReponse>();
			CreateMap<CodePlaquetteEdit, CodePlaquette>();
			CreateMap<CodePlaquetteRequest, CodePlaquette>();
		}
	}
}
