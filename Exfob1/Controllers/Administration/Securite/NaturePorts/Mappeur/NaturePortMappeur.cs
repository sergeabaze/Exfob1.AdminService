using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NaturePortMappeur : Profile
	{
		public NaturePortMappeur()
		{
			CreateMap<NaturePort, NaturePortListe>();
			CreateMap<NaturePort, NaturePortReponse>();
			CreateMap<NaturePortEdit, NaturePort>();
			CreateMap<NaturePortRequest, NaturePort>();
		}
	}
}
