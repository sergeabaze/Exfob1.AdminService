using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TransitaireMappeur : Profile
	{
		public TransitaireMappeur()
		{
			CreateMap<Transitaire, TransitaireListe>();
			CreateMap<Transitaire, TransitaireReponse>();
			CreateMap<TransitaireEdit, Transitaire>();
			CreateMap<TransitaireRequest, Transitaire>();
		}
	}
}
