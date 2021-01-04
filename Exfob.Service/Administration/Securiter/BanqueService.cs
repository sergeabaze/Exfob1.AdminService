using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class BanqueService : IBanqueService
	{

		private readonly IBanqueRepository _repository;

		public BanqueService(IBanqueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Banque>> ObtenireBanqueListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Banque> ObtenireBanqueParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationBanque(Banque entity)
		{
			await _repository.Creation(entity);
			return entity.BanqueID;
		}

		public async  Task MisejourBanque(Banque entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionBanque(int id)
		{
			await _repository.Delete(id);
		}
	}
}
