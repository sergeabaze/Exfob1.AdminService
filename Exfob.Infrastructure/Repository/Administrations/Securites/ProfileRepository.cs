using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Repository.Administrations.Securites
{
    public  class ProfileRepository: GenericRepository<Profil>, IProfileRepository
    {
        private GestionBoisContext _dBContext;

        #region Constructor
        public ProfileRepository(GestionBoisContext context)
           : base(context)
        {
            _dBContext = context;
        }
        #endregion


        #region Public methods
        public async Task<IEnumerable<Profil>> GetListe()
        {
            return await this.GetAllAsync();
        }

        public async  Task<Profil> GetById(int Id)
        {
            return await  this.GetByIdAsync(Id);
        }

        public async  Task<int> Creation(Profil entity)
        {
            await this.AddAsync(entity, true);

            return entity.ProfilID ;
        }

        public async  Task Update(Profil entity)
        {
            if (entity == null ) throw new Exception("Error Null Object dtected.");

            await this.UpdateAsync(entity, true);
        }

        public async  Task Delete(int id)
        {
            await this.DeleteAsync(id, true);
        }
        #endregion



    }
}
