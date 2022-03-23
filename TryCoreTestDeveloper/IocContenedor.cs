using TryCoreTestDeveloper.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using TryCoreTestDeveloper.DataAccess.DAO;

namespace TryCoreTestDeveloper
{
    public static class IocContenedor
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IUsrUsuarioService, UsrUsuarioService>();
            services.AddTransient<IUsrUsuarioDAO, UsrUsuarioDAO>();
            return services;
        }
    }
}