using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PeriodeClotureService : IPeriodeClotureService
	{

		private readonly IPeriodeClotureRepository _repository;

		public PeriodeClotureService(IPeriodeClotureRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<PeriodeCloture>> ObtenirePeriodeClotureListe()
		{
			return await _repository.GetListe();
		}

		public async Task<PeriodeCloture> ObtenirePeriodeClotureParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPeriodeCloture(PeriodeCloture entity)
		{
			await _repository.Creation(entity);
			return entity.PeriodeID;
		}

		public async  Task MisejourPeriodeCloture(PeriodeCloture entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPeriodeCloture(int id)
		{
			await _repository.Delete(id);
		}
	}
}
