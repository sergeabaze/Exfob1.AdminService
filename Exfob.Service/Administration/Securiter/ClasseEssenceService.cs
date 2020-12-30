using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ClasseEssenceService : IClasseEssenceService
	{

		private readonly IClasseEssenceRepository _repository;

		public ClasseEssenceService(IClasseEssenceRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ClasseEssence>> ObtenireClasseEssenceListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ClasseEssence> ObtenireClasseEssenceParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationClasseEssence(ClasseEssence entity)
		{
			await _repository.Creation(entity);
			return entity.ClasseEssenceID;
		}

		public async  Task MisejourClasseEssence(ClasseEssence entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionClasseEssence(int id)
		{
			await _repository.Delete(id);
		}
	}
}
