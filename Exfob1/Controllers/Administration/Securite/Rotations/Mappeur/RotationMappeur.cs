using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class RotationMappeur : Profile
	{
		public RotationMappeur()
		{
			CreateMap<Rotation, RotationListe>();
			CreateMap<Rotation, RotationReponse>();
			CreateMap<RotationEdit, Rotation>();
			CreateMap<RotationRequest, Rotation>();
		}
	}
}
