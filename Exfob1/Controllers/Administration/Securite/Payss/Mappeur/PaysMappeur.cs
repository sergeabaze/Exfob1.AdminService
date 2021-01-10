using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PaysMappeur : Profile
	{
		public PaysMappeur()
		{
			CreateMap<Pays, PaysListe>();
			CreateMap<Pays, PaysReponse>();
			CreateMap<PaysEdit, Pays>();
			CreateMap<PaysRequest, Pays>();
		}
	}
}
