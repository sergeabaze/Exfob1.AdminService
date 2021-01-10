using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SepbcMappeur : Profile
	{
		public SepbcMappeur()
		{
			CreateMap<Sepbc, SepbcListe>();
			CreateMap<Sepbc, SepbcReponse>();
			CreateMap<SepbcEdit, Sepbc>();
			CreateMap<SepbcRequest, Sepbc>();
		}
	}
}
