using AutoFixture.Xunit2;
using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob.Models.Fakes;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Utilisateurs
{
    public  class UtilisateurBLLTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] IUtilisateurService service,
               [Frozen] IMapper mapper,
                UtilisateurList model, int siteOpeAtionId,
               UtilisateurBLL sut)
            {
                //Arrang
                GestionBoisDataTestesFakes fakes = new GestionBoisDataTestesFakes();
                var entityListe = new List<Utilisateur> { fakes.GetUtilisateur() };
                var modelListe = new List<UtilisateurList> { model };

                var _serviceMock = Mock.Get(service);
                var mockMapper = Mock.Get(mapper);


                _serviceMock.Setup(svce => svce.ObtenireUtilisateurListe(It.IsAny<int>()))
                    .ReturnsAsync(entityListe);

                mockMapper.Setup(x => x.Map<IEnumerable<UtilisateurList>>(entityListe))
                    .Returns(modelListe.AsEnumerable());

                //Act
                var result = await sut.ObtenireUtilisateurListe(siteOpeAtionId);

                //Assert
                Assert.NotNull(result);
                _serviceMock.Verify(bll => bll.ObtenireUtilisateurListe(It.IsAny<int>()), Times.Once);
            }

        }
    }
}
