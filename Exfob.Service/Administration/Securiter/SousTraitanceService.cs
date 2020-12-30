using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SousTraitanceService : ISousTraitanceService
	{

		private readonly ISousTraitanceRepository _repository;

		public SousTraitanceService(ISousTraitanceRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SousTraitance>> ObtenireSousTraitanceListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SousTraitance> ObtenireSousTraitanceParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSousTraitance(SousTraitance entity)
		{
			await _repository.Creation(entity);
			return entity.SousTraitanceID;
		}

		public async  Task MisejourSousTraitance(SousTraitance entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSousTraitance(int id)
		{
			await _repository.Delete(id);
		}
	}
}
