using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SiegeService : ISiegeService
	{

		private readonly ISiegeRepository _repository;

		public SiegeService(ISiegeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Siege>> ObtenireSiegeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Siege> ObtenireSiegeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSiege(Siege entity)
		{
			await _repository.Creation(entity);
			return entity.SiegeID;
		}

		public async  Task MisejourSiege(Siege entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSiege(int id)
		{
			await _repository.Delete(id);
		}
	}
}
