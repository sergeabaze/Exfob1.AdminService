using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class QualiteBoisMappeur : Profile
	{
		public QualiteBoisMappeur()
		{
			CreateMap<QualiteBois, QualiteBoisListe>();
			CreateMap<QualiteBois, QualiteBoisReponse>();
			CreateMap<QualiteBoisEdit, QualiteBois>();
			CreateMap<QualiteBoisRequest, QualiteBois>();
		}
	}
}
