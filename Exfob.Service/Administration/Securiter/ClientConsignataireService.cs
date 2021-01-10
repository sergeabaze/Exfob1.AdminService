using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ClientConsignataireService : IClientConsignataireService
	{

		private readonly IClientConsignataireRepository _repository;

		public ClientConsignataireService(IClientConsignataireRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ClientConsignataire>> ObtenireClientConsignataireListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ClientConsignataire> ObtenireClientConsignataireParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationClientConsignataire(ClientConsignataire entity)
		{
			await _repository.Creation(entity);
			return entity.ClientConsignataireID;
		}

		public async  Task MisejourClientConsignataire(ClientConsignataire entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionClientConsignataire(int id)
		{
			await _repository.Delete(id);
		}
	}
}
