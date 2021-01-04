using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class OperateurService : IOperateurService
	{

		private readonly IOperateurRepository _repository;

		public OperateurService(IOperateurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Operateur>> ObtenireOperateurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Operateur> ObtenireOperateurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationOperateur(Operateur entity)
		{
			await _repository.Creation(entity);
			return entity.OperateurID;
		}

		public async  Task MisejourOperateur(Operateur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionOperateur(int id)
		{
			await _repository.Delete(id);
		}
	}
}
