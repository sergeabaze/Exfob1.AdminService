using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ModePaiementMappeur : Profile
	{
		public ModePaiementMappeur()
		{
			CreateMap<ModePaiement, ModePaiementListe>();
			CreateMap<ModePaiement, ModePaiementReponse>();
			CreateMap<ModePaiementEdit, ModePaiement>();
			CreateMap<ModePaiementRequest, ModePaiement>();
		}
	}
}
