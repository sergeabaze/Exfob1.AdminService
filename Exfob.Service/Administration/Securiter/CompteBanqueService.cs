using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CompteBanqueService : ICompteBanqueService
	{

		private readonly ICompteBanqueRepository _repository;

		public CompteBanqueService(ICompteBanqueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CompteBanque>> ObtenireCompteBanqueListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CompteBanque> ObtenireCompteBanqueParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCompteBanque(CompteBanque entity)
		{
			await _repository.Creation(entity);
			return entity.CompteBanqueID;
		}

		public async  Task MisejourCompteBanque(CompteBanque entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCompteBanque(int id)
		{
			await _repository.Delete(id);
		}
	}
}
