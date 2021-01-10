using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class LamelleCouleurMappeur : Profile
	{
		public LamelleCouleurMappeur()
		{
			CreateMap<LamelleCouleur, LamelleCouleurListe>();
			CreateMap<LamelleCouleur, LamelleCouleurReponse>();
			CreateMap<LamelleCouleurEdit, LamelleCouleur>();
			CreateMap<LamelleCouleurRequest, LamelleCouleur>();
		}
	}
}
