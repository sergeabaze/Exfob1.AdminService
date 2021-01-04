using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class EquipeOperateurService : IEquipeOperateurService
	{

		private readonly IEquipeOperateurRepository _repository;

		public EquipeOperateurService(IEquipeOperateurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<EquipeOperateur>> ObtenireEquipeOperateurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<EquipeOperateur> ObtenireEquipeOperateurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationEquipeOperateur(EquipeOperateur entity)
		{
			await _repository.Creation(entity);
			return entity.EquipeID;
		}

		public async  Task MisejourEquipeOperateur(EquipeOperateur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionEquipeOperateur(int id)
		{
			await _repository.Delete(id);
		}
	}
}
