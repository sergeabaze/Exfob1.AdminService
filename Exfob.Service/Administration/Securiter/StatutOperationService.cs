using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class StatutOperationService : IStatutOperationService
	{

		private readonly IStatutOperationRepository _repository;

		public StatutOperationService(IStatutOperationRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<StatutOperation>> ObtenireStatutOperationListe()
		{
			return await _repository.GetListe();
		}

		public async Task<StatutOperation> ObtenireStatutOperationParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationStatutOperation(StatutOperation entity)
		{
			await _repository.Creation(entity);
			return entity.StatutOperationID;
		}

		public async  Task MisejourStatutOperation(StatutOperation entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionStatutOperation(int id)
		{
			await _repository.Delete(id);
		}
	}
}
