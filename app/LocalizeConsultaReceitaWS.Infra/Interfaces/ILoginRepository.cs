using LocalizeConsultaReceitaWS.Domain.Login;

namespace LocalizeConsultaReceitaWS.Infra.Interfaces
{
    public interface ILoginRepository
    {
        public bool Obter(Login login);
    }
}
