using LocalizeConsultaReceitaWS.Domain.Login;
using LocalizeConsultaReceitaWS.Infra.Entity;
using LocalizeConsultaReceitaWS.Infra.Interfaces;

namespace LocalizeConsultaReceitaWS.Infra.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoginRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Obter(Login login)
        {
            return _appDbContext.Usuario.Any(x => x.Email == login.Email && x.Senha == login.Password);
        }
    }
}
