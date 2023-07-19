using LocalizeConsultaReceitaWS.Domain.Cliente;

namespace LocalizeConsultaReceitaWS.Services.Interfaces
{
    public interface IReceitaService 
    {
        bool ConsultarReceita(Cliente cliente);
    }
}
