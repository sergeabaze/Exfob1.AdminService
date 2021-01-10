using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TarifIHCMappeur : Profile
	{
		public TarifIHCMappeur()
		{
			CreateMap<TarifIHC, TarifIHCListe>();
			CreateMap<TarifIHC, TarifIHCReponse>();
			CreateMap<TarifIHCEdit, TarifIHC>();
			CreateMap<TarifIHCRequest, TarifIHC>();
		}
	}
}
