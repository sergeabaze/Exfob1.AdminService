using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NatureParcMappeur : Profile
	{
		public NatureParcMappeur()
		{
			CreateMap<NatureParc, NatureParcListe>();
			CreateMap<NatureParc, NatureParcReponse>();
			CreateMap<NatureParcEdit, NatureParc>();
			CreateMap<NatureParcRequest, NatureParc>();
		}
	}
}
