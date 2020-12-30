using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CategorieEssenceService : ICategorieEssenceService
	{

		private readonly ICategorieEssenceRepository _repository;

		public CategorieEssenceService(ICategorieEssenceRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CategorieEssence>> ObtenireCategorieEssenceListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CategorieEssence> ObtenireCategorieEssenceParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCategorieEssence(CategorieEssence entity)
		{
			await _repository.Creation(entity);
			return entity.CategorieEssenceID;
		}

		public async  Task MisejourCategorieEssence(CategorieEssence entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCategorieEssence(int id)
		{
			await _repository.Delete(id);
		}
	}
}
