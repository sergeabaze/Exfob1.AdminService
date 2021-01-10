using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class MaterielMappeur : Profile
	{
		public MaterielMappeur()
		{
			CreateMap<Materiel, MaterielListe>();
			CreateMap<Materiel, MaterielReponse>();
			CreateMap<MaterielEdit, Materiel>();
			CreateMap<MaterielRequest, Materiel>();
		}
	}
}
