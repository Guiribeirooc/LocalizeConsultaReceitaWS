using LocalizeConsultaReceitaWS.Domain.Usuario;

namespace LocalizeConsultaReceitaWS.Services.Interfaces
{
    public interface IUsuarioService
    {
        bool CriarUsuario(Usuario usuario);
        void AlterarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
    }
}
