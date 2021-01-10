using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ContratFournisseurMappeur : Profile
	{
		public ContratFournisseurMappeur()
		{
			CreateMap<ContratFournisseur, ContratFournisseurListe>();
			CreateMap<ContratFournisseur, ContratFournisseurReponse>();
			CreateMap<ContratFournisseurEdit, ContratFournisseur>();
			CreateMap<ContratFournisseurRequest, ContratFournisseur>();
		}
	}
}
