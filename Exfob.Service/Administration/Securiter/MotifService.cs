using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class MotifService : IMotifService
	{

		private readonly IMotifRepository _repository;

		public MotifService(IMotifRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Motif>> ObtenireMotifListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Motif> ObtenireMotifParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationMotif(Motif entity)
		{
			await _repository.Creation(entity);
			return entity.MotifID;
		}

		public async  Task MisejourMotif(Motif entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionMotif(int id)
		{
			await _repository.Delete(id);
		}
	}
}
