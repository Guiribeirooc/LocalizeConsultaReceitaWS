using LocalizeConsultaReceitaWS.Domain.Pedido;

namespace LocalizeConsultaReceitaWS.Infra.Interfaces
{
    public interface IPedidoRepository
    {
        void Incluir(Pedido pedido);
        List<Pedido> Obter();
        bool Obter(string cnpj);
    }
}
