using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NavireService : INavireService
	{

		private readonly INavireRepository _repository;

		public NavireService(INavireRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Navire>> ObtenireNavireListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Navire> ObtenireNavireParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNavire(Navire entity)
		{
			await _repository.Creation(entity);
			return entity.NavireID;
		}

		public async  Task MisejourNavire(Navire entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNavire(int id)
		{
			await _repository.Delete(id);
		}
	}
}
