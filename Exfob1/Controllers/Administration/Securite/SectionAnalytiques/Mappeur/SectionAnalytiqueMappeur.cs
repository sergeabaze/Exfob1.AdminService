using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SectionAnalytiqueMappeur : Profile
	{
		public SectionAnalytiqueMappeur()
		{
			CreateMap<SectionAnalytique, SectionAnalytiqueListe>();
			CreateMap<SectionAnalytique, SectionAnalytiqueReponse>();
			CreateMap<SectionAnalytiqueEdit, SectionAnalytique>();
			CreateMap<SectionAnalytiqueRequest, SectionAnalytique>();
		}
	}
}
