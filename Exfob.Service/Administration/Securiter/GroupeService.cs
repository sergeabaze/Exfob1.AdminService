using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class GroupeService : IGroupeService
	{

		private readonly IGroupeRepository _repository;

		public GroupeService(IGroupeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Groupe>> ObtenireGroupeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Groupe> ObtenireGroupeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationGroupe(Groupe entity)
		{
			await _repository.Creation(entity);
			return entity.GroupeID;
		}

		public async  Task MisejourGroupe(Groupe entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionGroupe(int id)
		{
			await _repository.Delete(id);
		}
	}
}
