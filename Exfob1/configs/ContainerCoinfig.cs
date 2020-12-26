using AutoMapper;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Infrastructure.Repository.Administrations.Securites;
using Exfob.Service.Administration.Securiter;
using Exfob.Service.Traducteurs.Administration.Securiter;
using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.Langues.Mappeur;
using Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.ProfilesMappeur;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.Utilisateurs.Mappeur;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Exfob1.configs
{
    public static class ContainerCoinfig
    {
        public static void ServiceMapping(this IServiceCollection services)
        {
            services.AddTransient<IUtilisateurTraducteur, UtilisateurTraducteur>();
            services.AddAutoMapper(typeof(LangueMappeur));
            services.AddAutoMapper(typeof(ProfileMappeur));
            services.AddAutoMapper(typeof(UtilisateurMappeur));


            services.AddTransient<ILangueRepository, LangueRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IUtilisateurRepository>(provider => {
                return new UtilisateurRepository(provider.GetRequiredService<SqlConnection>());
            });

            services.AddTransient<ILangueService, LangueService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUtilisateurService, UtilisateurService>();

            services.AddTransient<IProfileBLL, ProfileBLL>();
            services.AddTransient<ILangueBLL, LangueBLL>();
            services.AddTransient<IUtilisateurBLL, UtilisateurBLL>();
        }
    }
}
