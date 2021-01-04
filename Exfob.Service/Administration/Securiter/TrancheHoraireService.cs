using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TrancheHoraireService : ITrancheHoraireService
	{

		private readonly ITrancheHoraireRepository _repository;

		public TrancheHoraireService(ITrancheHoraireRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TrancheHoraire>> ObtenireTrancheHoraireListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TrancheHoraire> ObtenireTrancheHoraireParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTrancheHoraire(TrancheHoraire entity)
		{
			await _repository.Creation(entity);
			return entity.TrancheHoraireID;
		}

		public async  Task MisejourTrancheHoraire(TrancheHoraire entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTrancheHoraire(int id)
		{
			await _repository.Delete(id);
		}
	}
}
