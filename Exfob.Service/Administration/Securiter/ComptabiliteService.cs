using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ComptabiliteService : IComptabiliteService
	{

		private readonly IComptabiliteRepository _repository;

		public ComptabiliteService(IComptabiliteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Comptabilite>> ObtenireComptabiliteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Comptabilite> ObtenireComptabiliteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationComptabilite(Comptabilite entity)
		{
			await _repository.Creation(entity);
			return entity.ComptabiliteID;
		}

		public async  Task MisejourComptabilite(Comptabilite entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionComptabilite(int id)
		{
			await _repository.Delete(id);
		}
	}
}
