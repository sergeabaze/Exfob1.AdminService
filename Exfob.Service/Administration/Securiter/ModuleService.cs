using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ModuleService : IModuleService
	{

		private readonly IModuleRepository _repository;

		public ModuleService(IModuleRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Module>> ObtenireModuleListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Module> ObtenireModuleParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationModule(Module entity)
		{
			await _repository.Creation(entity);
			return entity.ModuleID;
		}

		public async  Task MisejourModule(Module entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionModule(int id)
		{
			await _repository.Delete(id);
		}
	}
}
