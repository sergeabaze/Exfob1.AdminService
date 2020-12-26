using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Utilisateurs
{
    public  class UtilisateurEditTests
    {
        private ValidationContext CreateContext(UtilisateurEdit model) => new ValidationContext(model, null, null);

        [Theory, UnitTestConventions]
        public void Should_Return_TrueValid_WhenRulesOk(UtilisateurEdit sut)
        {

            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, CreateContext(sut), results));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_ProfilID_Invald(UtilisateurEdit sut)
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
        public void Should_Return_False_When_LangueID_Invald(UtilisateurEdit sut)
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
        public void Should_Return_False_When_Nom_Invald(UtilisateurEdit sut)
        {
            sut.Nom = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurEdit.Nom))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_LoginUtilisateur_Invald(UtilisateurEdit sut)
        {
            sut.LoginUtilisateur = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurEdit.LoginUtilisateur))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Email_Invald(UtilisateurEdit sut)
        {
            sut.Email = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurEdit.Email))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_MiseJourPar_Invald(UtilisateurEdit sut)
        {
            sut.MiseJourPar  = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(UtilisateurEdit.MiseJourPar))));
        }
    }
}
