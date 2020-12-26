using AutoFixture.Xunit2;
using Exfob1.Controllers.Administration.Securite.Langues;
using Exfob1.Controllers.Administration.Securite.Utilisateurs;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Utilisateurs
{
    public   class UtilisateurControllerTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] IUtilisateurBLL businesslogic, 
                UtilisateurList user, int siteOperationId,
                UtilisateurController sut)
            {
                //Arrang
                var userListe = new List<UtilisateurList> { user  };
                var result = new WebApiListResponse<UtilisateurList>
                {
                    IsError = false,
                    CodeMessage = StatusCodes.Status200OK,
                    Model = userListe
                };
                var _businesslogicMock = Mock.Get(businesslogic);


                _businesslogicMock.Setup(bll => bll.ObtenireUtilisateurListe(It.IsAny<int>()))
                    .ReturnsAsync(result);

                //Act
                var httpRequest = await sut.obtenireListeAsync(siteOperationId);

                //Assert
                var okResult = Assert.IsType<OkObjectResult>(httpRequest.Result);
                okResult.StatusCode.Should().Be(result.CodeMessage);

                _businesslogicMock.Verify(bll => bll.ObtenireUtilisateurListe(It.IsAny<int>()), Times.Once);
            }
        }
    }
}
