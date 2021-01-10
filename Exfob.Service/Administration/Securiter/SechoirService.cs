using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SechoirService : ISechoirService
	{

		private readonly ISechoirRepository _repository;

		public SechoirService(ISechoirRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Sechoir>> ObtenireSechoirListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Sechoir> ObtenireSechoirParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSechoir(Sechoir entity)
		{
			await _repository.Creation(entity);
			return entity.SechoirID;
		}

		public async  Task MisejourSechoir(Sechoir entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSechoir(int id)
		{
			await _repository.Delete(id);
		}
	}
}
