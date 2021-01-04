using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PortService : IPortService
	{

		private readonly IPortRepository _repository;

		public PortService(IPortRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Port>> ObtenirePortListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Port> ObtenirePortParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPort(Port entity)
		{
			await _repository.Creation(entity);
			return entity.PortID;
		}

		public async  Task MisejourPort(Port entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPort(int id)
		{
			await _repository.Delete(id);
		}
	}
}
