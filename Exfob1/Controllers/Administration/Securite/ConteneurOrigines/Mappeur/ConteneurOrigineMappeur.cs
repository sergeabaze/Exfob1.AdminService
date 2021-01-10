using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ConteneurOrigineMappeur : Profile
	{
		public ConteneurOrigineMappeur()
		{
			CreateMap<ConteneurOrigine, ConteneurOrigineListe>();
			CreateMap<ConteneurOrigine, ConteneurOrigineReponse>();
			CreateMap<ConteneurOrigineEdit, ConteneurOrigine>();
			CreateMap<ConteneurOrigineRequest, ConteneurOrigine>();
		}
	}
}
