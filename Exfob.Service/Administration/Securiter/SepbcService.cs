using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SepbcService : ISepbcService
	{

		private readonly ISepbcRepository _repository;

		public SepbcService(ISepbcRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Sepbc>> ObtenireSepbcListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Sepbc> ObtenireSepbcParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSepbc(Sepbc entity)
		{
			await _repository.Creation(entity);
			return entity.SepbcID;
		}

		public async  Task MisejourSepbc(Sepbc entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSepbc(int id)
		{
			await _repository.Delete(id);
		}
	}
}
