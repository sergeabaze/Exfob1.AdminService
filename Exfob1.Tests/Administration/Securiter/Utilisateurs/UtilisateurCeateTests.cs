using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Utilisateurs
{
    public  class UtilisateurCeateTests
    {
        private ValidationContext CreateContext(UtilisateurRequestCreate model) => new ValidationContext(model, null, null);

        [Theory, UnitTestConventions]
        public void Should_Return_TrueValid_WhenRulesOk(UtilisateurRequestCreate sut)
        {

            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, CreateContext(sut), results));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_ProfilID_Invald(UtilisateurRequestCreate sut)
        {
            sut.ProfilID = 0;
            bool expected = false;
            bool actual;
            var context = new ValidationContext(sut, null, null);
            try
            {
                Validator.ValidateObject(sut, context, true);
                actual = true;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                actual = false;
            }
            Assert.Equal(expected, actual);
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_LangueID_Invald(UtilisateurRequestCreate sut)
        {
            sut.LangueID = 0;
            bool expected = false;
            bool actual;
            var context = new ValidationContext(sut, null, null);
            try
            {
                Validator.ValidateObject(sut, context, true);
                actual = true;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                actual = false;
            }
            Assert.Equal(expected, actual);
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Nom_Invald(UtilisateurRequestCreate sut)
        {
            sut.Nom = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurRequestCreate.Nom))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_LoginUtilisateur_Invald(UtilisateurRequestCreate sut)
        {
            sut.LoginUtilisateur = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurRequestCreate.LoginUtilisateur))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Email_Invald(UtilisateurRequestCreate sut)
        {
            sut.Email = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurRequestCreate.Email))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_MiseJourPar_Invald(UtilisateurRequestCreate sut)
        {
            sut.CreerPar = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurRequestCreate.CreerPar))));
        }
    }
}
