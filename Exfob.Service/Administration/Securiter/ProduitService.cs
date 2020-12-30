using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ProduitService : IProduitService
	{

		private readonly IProduitRepository _repository;

		public ProduitService(IProduitRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Produit>> ObtenireProduitListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Produit> ObtenireProduitParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationProduit(Produit entity)
		{
			await _repository.Creation(entity);
			return entity.ProduitID;
		}

		public async  Task MisejourProduit(Produit entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionProduit(int id)
		{
			await _repository.Delete(id);
		}
	}
}
