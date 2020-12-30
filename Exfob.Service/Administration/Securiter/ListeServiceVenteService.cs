using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ListeServiceVenteService : IListeServiceVenteService
	{

		private readonly IListeServiceVenteRepository _repository;

		public ListeServiceVenteService(IListeServiceVenteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ListeServiceVente>> ObtenireListeServiceVenteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ListeServiceVente> ObtenireListeServiceVenteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationListeServiceVente(ListeServiceVente entity)
		{
			await _repository.Creation(entity);
			return entity.ListeServiceVenteID;
		}

		public async  Task MisejourListeServiceVente(ListeServiceVente entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionListeServiceVente(int id)
		{
			await _repository.Delete(id);
		}
	}
}
