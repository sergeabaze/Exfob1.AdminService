using Exfob.Core.Interfaces.Administrations;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using Exfob1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration
{
    [Route("api/lookups")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        private readonly ILookUpRepository _repository;
        private readonly ILogger<LookUpController> _logger;
        public LookUpController(ILookUpRepository repository, ILogger<LookUpController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        /// <summary>
        /// liste acconiers
        /// </summary>
        /// <param name="siteoperationid"></param>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("acconierlists/{siteoperationid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<Acconier>>> AcconierListeAsync(int siteoperationid)
        {
            var response = new WebApiListResponse<Acconier>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

             response.Model = await _repository.GetAconierListe(siteoperationid)
                .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste SouTraitance
        /// </summary>
        /// <param name="siteoperationid"></param>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("soustraitancelists/{siteoperationid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<SouTraitanceForListe>>> SouTraitanceListeAsync(int siteoperationid)
        {
            var response = new WebApiListResponse<SouTraitanceForListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetSousTraitanceListe(siteoperationid)
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste droits
        /// </summary>
        /// <param name="profileid"></param>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("droitsutilisateurlists/{profileid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<DroitsForListe>>> DroitListeAsync(int profileid)
        {
            var response = new WebApiListResponse<DroitsForListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetDroitListe(profileid)
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste site authorizes
        /// </summary>
        /// <param name="utilisateurid"></param>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("siteauthorizelists/{utilisateurid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<SiteAutoriseForListe>>> SiteAutoriseListeAsync(int utilisateurid)
        {
            var response = new WebApiListResponse<SiteAutoriseForListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetSiteAutoriseListe(utilisateurid)
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste profiles
        /// </summary>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("profilelists")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<Profil>>> GetProfileListeAsync()
        {
            var response = new WebApiListResponse<Profil>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetProfileListe()
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste langues
        /// </summary>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("languelists")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<Langue>>> GetLangueListeAsync()
        {
            var response = new WebApiListResponse<Langue>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetLangueListe()
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste site operations
        /// </summary>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("siteoperationlists")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<SiteOperationForListe>>> GetSiteOperationListeAsync()
        {
            var response = new WebApiListResponse<SiteOperationForListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            response.Model = await _repository.GetSiteOperationListe()
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }
            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste site type materiels
        /// </summary>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("typemateriellists")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<TypeMateriel>>> GetTypeMaterielListeAsync()
        {
            var response = new WebApiListResponse<TypeMateriel>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
                
            };

            response.Model = await _repository.GetTypeMaterielListe()
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }

            return response.ToHttpResponse();
        }

        /// <summary>
        /// liste societes
        /// </summary>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("societelists")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<SocieteForListe>>> SocieteForListeListeAsync()
        {
            var response = new WebApiListResponse<SocieteForListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,

            };

            response.Model = await _repository.GetSocieteListe()
               .ConfigureAwait(false);
            if (!response.Model.Any())
            {
                response.CodeMessage = StatusCodes.Status404NotFound;
                response.IsError = true;
                response.ErrorMessage = ResourceMessage.ErrurNotFound;

            }

            return response.ToHttpResponse();
        }

    }
}
