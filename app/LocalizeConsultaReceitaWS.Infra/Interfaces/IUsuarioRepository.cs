using LocalizeConsultaReceitaWS.Domain.Usuario;

namespace LocalizeConsultaReceitaWS.Infra.Interfaces
{
    public interface IUsuarioRepository
    {
        public bool Obter(string email);
        public void Incluir(Usuario usuario);
        public void Alterar(Usuario usuario);
        public void Deletar(int id);
    }
}
