using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CompteProduitService : ICompteProduitService
	{

		private readonly ICompteProduitRepository _repository;

		public CompteProduitService(ICompteProduitRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CompteProduit>> ObtenireCompteProduitListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CompteProduit> ObtenireCompteProduitParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCompteProduit(CompteProduit entity)
		{
			await _repository.Creation(entity);
			return entity.CompteProduitID;
		}

		public async  Task MisejourCompteProduit(CompteProduit entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCompteProduit(int id)
		{
			await _repository.Delete(id);
		}
	}
}
