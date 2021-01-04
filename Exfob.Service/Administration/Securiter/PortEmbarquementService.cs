using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PortEmbarquementService : IPortEmbarquementService
	{

		private readonly IPortEmbarquementRepository _repository;

		public PortEmbarquementService(IPortEmbarquementRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<PortEmbarquement>> ObtenirePortEmbarquementListe()
		{
			return await _repository.GetListe();
		}

		public async Task<PortEmbarquement> ObtenirePortEmbarquementParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPortEmbarquement(PortEmbarquement entity)
		{
			await _repository.Creation(entity);
			return entity.PortEmbraquementID;
		}

		public async  Task MisejourPortEmbarquement(PortEmbarquement entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPortEmbarquement(int id)
		{
			await _repository.Delete(id);
		}
	}
}
