using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ModePaiementService : IModePaiementService
	{

		private readonly IModePaiementRepository _repository;

		public ModePaiementService(IModePaiementRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ModePaiement>> ObtenireModePaiementListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ModePaiement> ObtenireModePaiementParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationModePaiement(ModePaiement entity)
		{
			await _repository.Creation(entity);
			return entity.ModePaiementID;
		}

		public async  Task MisejourModePaiement(ModePaiement entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionModePaiement(int id)
		{
			await _repository.Delete(id);
		}
	}
}
