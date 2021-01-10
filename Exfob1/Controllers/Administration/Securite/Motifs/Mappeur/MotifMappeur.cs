using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class MotifMappeur : Profile
	{
		public MotifMappeur()
		{
			CreateMap<Motif, MotifListe>();
			CreateMap<Motif, MotifReponse>();
			CreateMap<MotifEdit, Motif>();
			CreateMap<MotifRequest, Motif>();
		}
	}
}
