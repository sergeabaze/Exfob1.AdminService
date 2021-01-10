using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class EssenceService : IEssenceService
	{

		private readonly IEssenceRepository _repository;

		public EssenceService(IEssenceRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Essence>> ObtenireEssenceListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Essence> ObtenireEssenceParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationEssence(Essence entity)
		{
			await _repository.Creation(entity);
			return entity.EssenceID;
		}

		public async  Task MisejourEssence(Essence entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionEssence(int id)
		{
			await _repository.Delete(id);
		}
	}
}
