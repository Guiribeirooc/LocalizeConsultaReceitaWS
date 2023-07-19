using LocalizeConsultaReceitaWS.Infra.Entity;
using LocalizeConsultaReceitaWS.Infra.Interfaces;
using LocalizeConsultaReceitaWS.Infra.Repositories;
using LocalizeConsultaReceitaWS.Infra.Requests;
using LocalizeConsultaReceitaWS.Services.Interfaces;
using LocalizeConsultaReceitaWS.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace LocalizeConsultaReceitaWS.UI.Extensoes
{
    public static class ServicosExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<IReceitaRequest, ReceitaRequest>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
