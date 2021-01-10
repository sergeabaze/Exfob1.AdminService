using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SciesMappeur : Profile
	{
		public SciesMappeur()
		{
			CreateMap<Scie, SciesListe>();
			CreateMap<Scie, SciesReponse>();
			CreateMap<SciesEdit, Scie>();
			CreateMap<SciesRequest, Scie>();
		}
	}
}
