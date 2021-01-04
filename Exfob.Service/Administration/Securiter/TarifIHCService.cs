using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TarifIHCService : ITarifIHCService
	{

		private readonly ITarifIHCRepository _repository;

		public TarifIHCService(ITarifIHCRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TarifIHC>> ObtenireTarifIHCListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TarifIHC> ObtenireTarifIHCParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTarifIHC(TarifIHC entity)
		{
			await _repository.Creation(entity);
			return entity.TarifIHCID;
		}

		public async  Task MisejourTarifIHC(TarifIHC entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTarifIHC(int id)
		{
			await _repository.Delete(id);
		}
	}
}
