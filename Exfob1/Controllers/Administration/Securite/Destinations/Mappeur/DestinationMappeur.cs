using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class DestinationMappeur : Profile
	{
		public DestinationMappeur()
		{
			CreateMap<Destination, DestinationListe>();
			CreateMap<Destination, DestinationReponse>();
			CreateMap<DestinationEdit, Destination>();
			CreateMap<DestinationRequest, Destination>();
		}
	}
}
