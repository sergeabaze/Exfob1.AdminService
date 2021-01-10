using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class DestinationService : IDestinationService
	{

		private readonly IDestinationRepository _repository;

		public DestinationService(IDestinationRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Destination>> ObtenireDestinationListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Destination> ObtenireDestinationParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationDestination(Destination entity)
		{
			await _repository.Creation(entity);
			return entity.DestinationID;
		}

		public async  Task MisejourDestination(Destination entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionDestination(int id)
		{
			await _repository.Delete(id);
		}
	}
}
