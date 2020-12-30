using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class DroitService : IDroitService
	{

		private readonly IDroitRepository _repository;

		public DroitService(IDroitRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Droit>> ObtenireDroitListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Droit> ObtenireDroitParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationDroit(Droit entity)
		{
			await _repository.Creation(entity);
			return entity.DroitID;
		}

		public async  Task MisejourDroit(Droit entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionDroit(int id)
		{
			await _repository.Delete(id);
		}
	}
}
