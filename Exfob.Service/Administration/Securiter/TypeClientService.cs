using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TypeClientService : ITypeClientService
	{

		private readonly ITypeClientRepository _repository;

		public TypeClientService(ITypeClientRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TypeClient>> ObtenireTypeClientListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TypeClient> ObtenireTypeClientParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTypeClient(TypeClient entity)
		{
			await _repository.Creation(entity);
			return entity.TypeClientID;
		}

		public async  Task MisejourTypeClient(TypeClient entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTypeClient(int id)
		{
			await _repository.Delete(id);
		}
	}
}
