using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ServiceVenteService : IServiceVenteService
	{

		private readonly IServiceVenteRepository _repository;

		public ServiceVenteService(IServiceVenteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ServiceVente>> ObtenireServiceVenteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ServiceVente> ObtenireServiceVenteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationServiceVente(ServiceVente entity)
		{
			await _repository.Creation(entity);
			return entity.ServiceVenteID;
		}

		public async  Task MisejourServiceVente(ServiceVente entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionServiceVente(int id)
		{
			await _repository.Delete(id);
		}
	}
}
