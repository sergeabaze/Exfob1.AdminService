using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ModuleMappeur : Profile
	{
		public ModuleMappeur()
		{
			CreateMap<Module, ModuleListe>();
			CreateMap<Module, ModuleReponse>();
			CreateMap<ModuleEdit, Module>();
			CreateMap<ModuleRequest, Module>();
		}
	}
}
