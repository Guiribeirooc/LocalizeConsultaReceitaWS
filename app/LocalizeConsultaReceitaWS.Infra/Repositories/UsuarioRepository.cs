using LocalizeConsultaReceitaWS.Domain.Usuario;
using LocalizeConsultaReceitaWS.Infra.Entity;
using LocalizeConsultaReceitaWS.Infra.Interfaces;

namespace LocalizeConsultaReceitaWS.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Alterar(Usuario usuario)
        {
            _appDbContext.Usuario.Update(usuario);
            _appDbContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            _appDbContext.Remove(id);
            _appDbContext.SaveChanges();
        }

        public void Incluir(Usuario usuario)
        {
            _appDbContext.Add(usuario);
            _appDbContext.SaveChanges();
        }

        public bool Obter(string email)
        {
            return _appDbContext.Usuario.Any(x => x.Email == email);
        }
    }
}
