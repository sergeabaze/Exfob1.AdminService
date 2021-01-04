using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PortArriveService : IPortArriveService
	{

		private readonly IPortArriveRepository _repository;

		public PortArriveService(IPortArriveRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<PortArrive>> ObtenirePortArriveListe()
		{
			return await _repository.GetListe();
		}

		public async Task<PortArrive> ObtenirePortArriveParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPortArrive(PortArrive entity)
		{
			await _repository.Creation(entity);
			return entity.PortArriveID;
		}

		public async  Task MisejourPortArrive(PortArrive entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPortArrive(int id)
		{
			await _repository.Delete(id);
		}
	}
}
