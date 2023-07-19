using LocalizeConsultaReceitaWS.Domain.Receita;

namespace LocalizeConsultaReceitaWS.Infra.Interfaces
{
    public interface IReceitaRequest
    {
        ResponseReceita ConsultarReceitaWS(string cnpj);
    }
}
