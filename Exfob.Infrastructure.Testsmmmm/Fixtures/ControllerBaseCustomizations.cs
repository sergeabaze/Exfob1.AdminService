using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using System;

namespace Exfob.Infrastructure.Tests.Fixtures
{
    public class ControllerBaseCustomizations : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new FilteringSpecimenBuilder(
                 new Postprocessor(
                     new MethodInvoker(new ModestConstructorQuery()),
                     new ControllerBaseFiller()),
                 new ControllerBaseSpecification()));
        }

        private class ControllerBaseFiller : ISpecimenCommand
        {
            public void Execute(object specimen, ISpecimenContext context)
            {
                if (specimen == null) throw new ArgumentNullException(nameof(specimen));
                if (context == null) throw new ArgumentNullException(nameof(context));

                if (specimen is ControllerBase controller)
                {
                    controller.ControllerContext = new ControllerContext
                    {
                        HttpContext = (HttpContext)context.Resolve(typeof(HttpContext))
                    };

                    var problemDetailsFactory = new Mock<ProblemDetailsFactory>();
                    problemDetailsFactory.Setup(f => f.CreateValidationProblemDetails(controller.HttpContext,
                            controller.ModelState,
                            It.IsAny<int?>(),
                            It.IsAny<string>(),
                            It.IsAny<string>(),
                            It.IsAny<string>(),
                            It.IsAny<string>()))
                        .Returns<HttpContext, ModelStateDictionary, int?, string, string, string, string>(
                            (httpContext, modelState, statusCode, title, type, detail, instance) =>
                                new ValidationProblemDetails(modelState)
                                {
                                    Detail = detail,
                                    Instance = instance,
                                    Status = statusCode ?? (modelState != null ? 400 : 500),
                                    Title = title,
                                    Type = type
                                });

                    controller.ProblemDetailsFactory = problemDetailsFactory.Object;
                }
                else
                {
                    throw new ArgumentException($"The specimen must be an instance of ControllerBase", nameof(specimen));
                }
            }
        }

        private class ControllerBaseSpecification : IRequestSpecification
        {
            public bool IsSatisfiedBy(object request) => request is Type type && typeof(ControllerBase).IsAssignableFrom(type);
        }
    }
}
