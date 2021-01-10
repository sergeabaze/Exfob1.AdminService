using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class ServiceVenteRepository : GenericRepository<ServiceVente>, IServiceVenteRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public ServiceVenteRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<ServiceVente> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<ServiceVente>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(ServiceVente entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.ServiceVenteID ;
		}

		public async  Task Update(ServiceVente entity)
		{
		if (entity == null) throw new Exception("Erreur. Objet nul détecté");
		await this.UpdateAsync(entity, true);
		}
		public async  Task Delete(int id)
		{
			await this.DeleteAsync(id, true);
		}

		#endregion
	}
}
