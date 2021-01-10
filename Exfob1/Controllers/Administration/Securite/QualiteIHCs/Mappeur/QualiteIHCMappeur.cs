using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class QualiteIHCMappeur : Profile
	{
		public QualiteIHCMappeur()
		{
			CreateMap<QualiteIHC, QualiteIHCListe>();
			CreateMap<QualiteIHC, QualiteIHCReponse>();
			CreateMap<QualiteIHCEdit, QualiteIHC>();
			CreateMap<QualiteIHCRequest, QualiteIHC>();
		}
	}
}
