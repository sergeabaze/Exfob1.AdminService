using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class RedevanceEtatiqueService : IRedevanceEtatiqueService
	{

		private readonly IRedevanceEtatiqueRepository _repository;

		public RedevanceEtatiqueService(IRedevanceEtatiqueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<RedevanceEtatique>> ObtenireRedevanceEtatiqueListe()
		{
			return await _repository.GetListe();
		}

		public async Task<RedevanceEtatique> ObtenireRedevanceEtatiqueParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationRedevanceEtatique(RedevanceEtatique entity)
		{
			await _repository.Creation(entity);
			return entity.RedevanceEtatiqueID;
		}

		public async  Task MisejourRedevanceEtatique(RedevanceEtatique entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionRedevanceEtatique(int id)
		{
			await _repository.Delete(id);
		}
	}
}
