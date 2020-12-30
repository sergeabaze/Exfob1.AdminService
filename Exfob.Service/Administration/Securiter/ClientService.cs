using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ClientService : IClientService
	{

		private readonly IClientRepository _repository;

		public ClientService(IClientRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Client>> ObtenireClientListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Client> ObtenireClientParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationClient(Client entity)
		{
			await _repository.Creation(entity);
			return entity.ClientID;
		}

		public async  Task MisejourClient(Client entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionClient(int id)
		{
			await _repository.Delete(id);
		}
	}
}
