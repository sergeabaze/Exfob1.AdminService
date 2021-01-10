using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CompteProduitMappeur : Profile
	{
		public CompteProduitMappeur()
		{
			CreateMap<CompteProduit, CompteProduitListe>();
			CreateMap<CompteProduit, CompteProduitReponse>();
			CreateMap<CompteProduitEdit, CompteProduit>();
			CreateMap<CompteProduitRequest, CompteProduit>();
		}
	}
}
