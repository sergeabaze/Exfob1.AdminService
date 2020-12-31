using AutoFixture.Xunit2;
using Exfob1.Controllers.Administration.Securite.Langues;
using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Langues
{
    public class LangueControllerTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] ILangueBLL businesslogic, LangueListe langue, LangueController sut)
            {
                //Arrang
                var langueListe = new List<LangueListe> { langue };
                var result = new WebApiListResponse<LangueListe>
                {
                     IsError = false,
                      CodeMessage = StatusCodes.Status200OK,
                       Model = langueListe
                };
                var _businesslogicMock = Mock.Get(businesslogic);


                _businesslogicMock.Setup(bll => bll.ObtenireLangueListe())
                    .ReturnsAsync(result);

                //Act
                var httpRequest = await sut.obtenireListeAsync(CancellationToken.None);

                //Assert
                var okResult = Assert.IsType<OkObjectResult>(httpRequest.Result);
                okResult.StatusCode.Should().Be(result.CodeMessage);

                _businesslogicMock.Verify(bll => bll.ObtenireLangueListe(), Times.Once);
            }
        }
    }
}
