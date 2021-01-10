using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class OperateurMappeur : Profile
	{
		public OperateurMappeur()
		{
			CreateMap<Operateur, OperateurListe>();
			CreateMap<Operateur, OperateurReponse>();
			CreateMap<OperateurEdit, Operateur>();
			CreateMap<OperateurRequest, Operateur>();
		}
	}
}
