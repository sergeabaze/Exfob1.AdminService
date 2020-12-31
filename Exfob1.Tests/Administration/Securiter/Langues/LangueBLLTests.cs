using AutoFixture.Xunit2;
using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob.Models.Fakes;
using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Models.Adminstrations;
using Exfob1.Models.Adminstrations.Langues.Response;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Langues
{
    public   class LangueBLLTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] ILangueService service,
                [Frozen] IMapper mapper,
                 LangueListe model,
                LangueBLL sut)
            {
                //Arrang
                int attendu = 200;
                GestionBoisDataTestesFakes fakes = new GestionBoisDataTestesFakes();
                var entityListe = new List<Langue> { fakes.GetLangue() };
                var modelListe = new List<LangueListe> { model };

                var _serviceMock = Mock.Get(service);
                var mockMapper = Mock.Get(mapper);


                _serviceMock.Setup(svce => svce.ObtenireLangueListe())
                    .ReturnsAsync(entityListe);

                mockMapper.Setup(x => x.Map<IEnumerable<LangueListe>>(entityListe))
                    .Returns(modelListe.AsEnumerable());

                //Act
                var result = await sut.ObtenireLangueListe();

                //Assert
                Assert.NotNull(result);
                Assert.Equal(attendu, result.CodeMessage);
                _serviceMock.Verify(bll => bll.ObtenireLangueListe(), Times.Once);
            }


            [Theory, UnitTestConventions]
            public async Task ObtenireParIdOnOkResult([Frozen] ILangueService service,
                [Frozen] IMapper mapper, int id,
                Models.Adminstrations.Langues.Response.LangueReponse model,
                LangueBLL sut)
            {
                //Arrang
                int attendu = 200;
                GestionBoisDataTestesFakes fakes = new GestionBoisDataTestesFakes();
                var entity = fakes.GetLangue() ;

                var _serviceMock = Mock.Get(service);
                var mockMapper = Mock.Get(mapper);


                _serviceMock.Setup(svce => svce.ObtenireLangueParId(It.IsAny<int>()))
                    .ReturnsAsync(entity);

                mockMapper.Setup(x => x.Map<Models.Adminstrations.Langues.Response.LangueReponse>(entity))
                    .Returns(model);

                //Act
                var result = await sut.ObtenireLangueParId(id);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(attendu, result.CodeMessage);
                _serviceMock.Verify(bll => bll.ObtenireLangueParId(It.IsAny<int>()), Times.Once);
            }

            [Theory, UnitTestConventions]
            public async Task ObtenireParIdOnNotFound([Frozen] ILangueService service,
               [Frozen] IMapper mapper, int id,
               Models.Adminstrations.LangueReponse model,
               LangueBLL sut)
            {
                //Arrang
                int attendu = 404;
                GestionBoisDataTestesFakes fakes = new GestionBoisDataTestesFakes();
                var entity = fakes.GetLangue();

                var _serviceMock = Mock.Get(service);
                var mockMapper = Mock.Get(mapper);


                _serviceMock.Setup(svce => svce.ObtenireLangueParId(It.IsAny<int>()))
                    .ReturnsAsync((Langue)null);

                mockMapper.Setup(x => x.Map<Models.Adminstrations.LangueReponse>(entity))
                    .Returns(model);

                //Act
                var result = await sut.ObtenireLangueParId(id);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(attendu, result.CodeMessage);
                _serviceMock.Verify(bll => bll.ObtenireLangueParId(It.IsAny<int>()), Times.Once);
            }
        }
    }
}
