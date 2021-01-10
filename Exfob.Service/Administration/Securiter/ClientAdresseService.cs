using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ClientAdresseService : IClientAdresseService
	{

		private readonly IClientAdresseRepository _repository;

		public ClientAdresseService(IClientAdresseRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ClientAdresse>> ObtenireClientAdresseListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ClientAdresse> ObtenireClientAdresseParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationClientAdresse(ClientAdresse entity)
		{
			await _repository.Creation(entity);
			return entity.ClientAdresseID;
		}

		public async  Task MisejourClientAdresse(ClientAdresse entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionClientAdresse(int id)
		{
			await _repository.Delete(id);
		}
	}
}
