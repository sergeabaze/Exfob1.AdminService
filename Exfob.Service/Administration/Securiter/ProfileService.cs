using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Service.Administration.Securiter
{
    public  class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
       
        public ProfileService(IProfileRepository  repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
           
        }

        public async  Task<IEnumerable<Profil>> ObtenireProfileListe()
        {
            return await _repository.GetListe();
        }

        public async  Task<Profil> ObtenireProfileParId(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async  Task<int> CreationProfile(Profil entity)
        {
            await _repository.Creation(entity);
            return entity.ProfilID;
        }

        public async  Task MisejourProfile(Profil entity)
        {
            await _repository.Update(entity);
        }
       

        public async  Task SuppressionProfile(int id)
        {
            await _repository.Delete(id);
        }

        /*
        public async  Task<WebApiListResponse<ProfileListe>> ObtenireProfileListe()
        {
            var result = new WebApiListResponse<ProfileListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _repository.GetListe();
                result.Model = _traducteur.FromEntityToModel(query);

            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async  Task<WebApiSingleResponse<ProfileResponse>> ObtenireProfileParId(int Id)
        {
           
        }

        public async  Task<WebApiSingleResponse<ProfileResponse>> CreationProfile(ProfileRequest entity)
        {
           
        }

        public async  Task<WebApiSingleResponse<ProfileResponse>> MisejourProfile(ProfileEdit entity)
        {
           
        }

        public async  Task<WebApiSingleResponse<ProfileResponse>> SuppressionProfile(int id)
        {
            
        }
        */
    }
}
