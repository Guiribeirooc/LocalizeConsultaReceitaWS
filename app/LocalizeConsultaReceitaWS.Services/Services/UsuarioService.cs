using LocalizeConsultaReceitaWS.Domain.Usuario;
using LocalizeConsultaReceitaWS.Infra.Interfaces;
using LocalizeConsultaReceitaWS.Services.Interfaces;

namespace LocalizeConsultaReceitaWS.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AlterarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool CriarUsuario(Usuario usuario)
        {
            var verificaUsuario = _usuarioRepository.Obter(usuario.Email);
            
            if(verificaUsuario)
                return false;

            _usuarioRepository.Incluir(usuario);

            return true;
        }

        public void DeletarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
