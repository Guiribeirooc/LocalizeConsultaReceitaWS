using LocalizeConsultaReceitaWS.Domain.Cliente;
using LocalizeConsultaReceitaWS.Domain.Pedido;
using LocalizeConsultaReceitaWS.Infra.Interfaces;
using LocalizeConsultaReceitaWS.Services.Interfaces;

namespace LocalizeConsultaReceitaWS.Services.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRequest _receitaRequest;
        private readonly IPedidoRepository _pedidoRepository;

        public ReceitaService(IReceitaRequest receitaRequest, IPedidoRepository pedidoRepository)
        {
            _receitaRequest = receitaRequest;
            _pedidoRepository = pedidoRepository;
        }

        public bool ConsultarReceita(Cliente cliente)
        {
            var verificarCNPJ = _pedidoRepository.Obter(cliente.CNPJ);

            if (verificarCNPJ)
                return false;

            var request = _receitaRequest.ConsultarReceitaWS(cliente.CNPJ);
            var pedido = new Pedido()
            {
                CNPJ = cliente.CNPJ,
                Resultado = request.Retorno
            };
            _pedidoRepository.Incluir(pedido);

            return true;
        }
    }
}
