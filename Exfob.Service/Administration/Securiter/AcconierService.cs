using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class AcconierService : IAcconierService
	{

		private readonly IAcconierRepository _repository;

		public AcconierService(IAcconierRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Acconier>> ObtenireAcconierListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Acconier> ObtenireAcconierParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationAcconier(Acconier entity)
		{
			await _repository.Creation(entity);
			return entity.AcconierID;
		}

		public async  Task MisejourAcconier(Acconier entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionAcconier(int id)
		{
			await _repository.Delete(id);
		}
	}
}
