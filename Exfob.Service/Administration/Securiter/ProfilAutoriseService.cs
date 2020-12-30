using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ProfilAutoriseService : IProfilAutoriseService
	{

		private readonly IProfilAutoriseRepository _repository;

		public ProfilAutoriseService(IProfilAutoriseRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ProfilAutorise>> ObtenireProfilAutoriseListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ProfilAutorise> ObtenireProfilAutoriseParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationProfilAutorise(ProfilAutorise entity)
		{
			await _repository.Creation(entity);
			return entity.ProfilAutoriseID;
		}

		public async  Task MisejourProfilAutorise(ProfilAutorise entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionProfilAutorise(int id)
		{
			await _repository.Delete(id);
		}
	}
}
