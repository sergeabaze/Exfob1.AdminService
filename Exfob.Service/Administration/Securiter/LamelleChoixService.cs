using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class LamelleChoixService : ILamelleChoixService
	{

		private readonly ILamelleChoixRepository _repository;

		public LamelleChoixService(ILamelleChoixRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<LamelleChoix>> ObtenireLamelleChoixListe()
		{
			return await _repository.GetListe();
		}

		public async Task<LamelleChoix> ObtenireLamelleChoixParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationLamelleChoix(LamelleChoix entity)
		{
			await _repository.Creation(entity);
			return entity.LamelleChoixID;
		}

		public async  Task MisejourLamelleChoix(LamelleChoix entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionLamelleChoix(int id)
		{
			await _repository.Delete(id);
		}
	}
}
