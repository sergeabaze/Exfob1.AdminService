using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PileGrumeMappeur : Profile
	{
		public PileGrumeMappeur()
		{
			CreateMap<PileGrume, PileGrumeListe>();
			CreateMap<PileGrume, PileGrumeReponse>();
			CreateMap<PileGrumeEdit, PileGrume>();
			CreateMap<PileGrumeRequest, PileGrume>();
		}
	}
}
