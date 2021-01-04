using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class PeriodeClotureRepository : GenericRepository<PeriodeCloture>, IPeriodeClotureRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public PeriodeClotureRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<PeriodeCloture> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<PeriodeCloture>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(PeriodeCloture entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.PeriodeID ;
		}

		public async  Task Update(PeriodeCloture entity)
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
