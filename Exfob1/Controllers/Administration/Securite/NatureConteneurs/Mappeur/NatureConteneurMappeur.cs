using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NatureConteneurMappeur : Profile
	{
		public NatureConteneurMappeur()
		{
			CreateMap<NatureConteneur, NatureConteneurListe>();
			CreateMap<NatureConteneur, NatureConteneurReponse>();
			CreateMap<NatureConteneurEdit, NatureConteneur>();
			CreateMap<NatureConteneurRequest, NatureConteneur>();
		}
	}
}
