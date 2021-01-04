using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ClientContactService : IClientContactService
	{

		private readonly IClientContactRepository _repository;

		public ClientContactService(IClientContactRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ClientContact>> ObtenireClientContactListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ClientContact> ObtenireClientContactParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationClientContact(ClientContact entity)
		{
			await _repository.Creation(entity);
			return entity.ClientContactID;
		}

		public async  Task MisejourClientContact(ClientContact entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionClientContact(int id)
		{
			await _repository.Delete(id);
		}
	}
}
