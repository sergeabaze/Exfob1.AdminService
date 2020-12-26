using Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic;
using Exfob1.Conventions;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Utilisateurs
{
    [Route("api/utilisateurs")]
    [ApiController]


    public class UtilisateurController : ControllerBase
    {

        private readonly IUtilisateurBLL _utilisateurBLL;
        private readonly ILogger<UtilisateurController> _logger;
        public UtilisateurController(IUtilisateurBLL utilisateurBLL, ILogger<UtilisateurController> logger)
        {
            _utilisateurBLL = utilisateurBLL ?? throw new ArgumentNullException(nameof(utilisateurBLL));
            _logger = logger;
        }

        /// <summary>
        /// liste utilisateur par sit operation
        /// </summary>
        /// <param name="siteoperationid">site id</param>
        /// <returns></returns>
        [HttpGet("list/{siteoperationid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<WebApiListResponse<UtilisateurList>>> obtenireListeAsync(int siteoperationid)
        {
            var response = await _utilisateurBLL.ObtenireUtilisateurListe(siteoperationid)
                .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// obtenire par id
        /// </summary>
        /// <param name="id">id utilisateur</param>
        /// <returns>retourne objet</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiSingleResponse<UtilisateurReponse>>> obtenireParIdAsync(int id)
        {
            var response = await _utilisateurBLL.ObtenireUtilisateurParId(id)
                .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de creation
        /// </summary>
        /// <param name="request">objet</param>
        /// <param name="siteoperationid">site id</param>
        /// <returns>objet creer</returns>
        [HttpPost("creation/{siteoperationid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
          nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<UtilisateurRequestReponse>>> CreationAsync(
            int siteoperationid, [FromBody] UtilisateurCreate request)
        {

            if (!ModelState.IsValid)
            {
                var repo = new WebApiListResponse<UtilisateurRequestReponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };
                return repo.ToHttpResponse();
            }
            var response = await _utilisateurBLL.CreationUtilisateur(request, siteoperationid)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de misejour
        /// </summary>
        /// <param name="siteoperationid">site id</param>
        /// <param name="utilisateurid">id</param>
        /// <param name="request">objet</param>
        /// <returns>objet misejour</returns>
        [HttpPut("edition/{siteoperationid}/{utilisateurid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
          nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<UtilisateurRequestReponse>>> MisejourAsync(int siteoperationid, int utilisateurid, [FromBody] UtilisateurEdit request)
        {

            if (!ModelState.IsValid)
            {
                var repo = new WebApiListResponse<UtilisateurRequestReponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };
                return repo.ToHttpResponse();
            }
            var response = await _utilisateurBLL.MisejourUtilisateur(request, siteoperationid, utilisateurid)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de suppression
        /// </summary>
        /// <param name="utilisateurid">id</param>
        /// <returns>status</returns>
        [HttpDelete("suppression/{utilisateurid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
         nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<UtilisateurRequestReponse>>> SuppressionAsync(int utilisateurid)
        {
            var response = await _utilisateurBLL.SuppressionUtilisateur(utilisateurid)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }
    }
}
