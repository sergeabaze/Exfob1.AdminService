using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TransporteurMappeur : Profile
	{
		public TransporteurMappeur()
		{
			CreateMap<Transporteur, TransporteurListe>();
			CreateMap<Transporteur, TransporteurReponse>();
			CreateMap<TransporteurEdit, Transporteur>();
			CreateMap<TransporteurRequest, Transporteur>();
		}
	}
}
