using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PileGrumeService : IPileGrumeService
	{

		private readonly IPileGrumeRepository _repository;

		public PileGrumeService(IPileGrumeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<PileGrume>> ObtenirePileGrumeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<PileGrume> ObtenirePileGrumeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPileGrume(PileGrume entity)
		{
			await _repository.Creation(entity);
			return entity.PileGrumeID;
		}

		public async  Task MisejourPileGrume(PileGrume entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPileGrume(int id)
		{
			await _repository.Delete(id);
		}
	}
}
