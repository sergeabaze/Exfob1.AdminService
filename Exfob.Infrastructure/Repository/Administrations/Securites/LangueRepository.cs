using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Repository.Administrations.Securites
{
    public  class LangueRepository : GenericRepository<Langue>, ILangueRepository
    {
        private GestionBoisContext _dBContext;

        #region Constructor
        public LangueRepository(GestionBoisContext context)
           : base(context)
        {
            _dBContext = context;
        }

        #endregion

        #region Public methods
        public async  Task<Langue> GetById(int Id)
        {
            return await this.GetByIdAsync(Id);
        }

        public async  Task<IEnumerable<Langue>> GetListe()
        {
            return await this.GetAllAsync();
        }
        public async  Task<int> Creation(Langue entity)
        {
            await this.AddAsync(entity, true);

            return entity.LangueID ;
        }

        public async  Task Update(Langue entity)
        {
            if (entity == null) throw new Exception("Error Null Object dtected.");

            await this.UpdateAsync(entity, true);
        }
        public async  Task Delete(int id)
        {
            await this.DeleteAsync(id, true);
        }

        

       
        #endregion
    }
}
