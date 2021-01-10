using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NatureMouvementMappeur : Profile
	{
		public NatureMouvementMappeur()
		{
			CreateMap<NatureMouvement, NatureMouvementListe>();
			CreateMap<NatureMouvement, NatureMouvementReponse>();
			CreateMap<NatureMouvementEdit, NatureMouvement>();
			CreateMap<NatureMouvementRequest, NatureMouvement>();
		}
	}
}
