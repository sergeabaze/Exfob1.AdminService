using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class DroitAutoriseService : IDroitAutoriseService
	{

		private readonly IDroitAutoriseRepository _repository;

		public DroitAutoriseService(IDroitAutoriseRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<DroitAutorise>> ObtenireDroitAutoriseListe()
		{
			return await _repository.GetListe();
		}

		public async Task<DroitAutorise> ObtenireDroitAutoriseParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationDroitAutorise(DroitAutorise entity)
		{
			await _repository.Creation(entity);
			return entity.DroitAutoriseID;
		}

		public async  Task MisejourDroitAutorise(DroitAutorise entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionDroitAutorise(int id)
		{
			await _repository.Delete(id);
		}
	}
}
