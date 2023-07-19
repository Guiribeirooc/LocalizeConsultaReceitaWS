using LocalizeConsultaReceitaWS.Domain.Pedido;
using LocalizeConsultaReceitaWS.Infra.Entity;
using LocalizeConsultaReceitaWS.Infra.Interfaces;

namespace LocalizeConsultaReceitaWS.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        public PedidoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Incluir(Pedido pedido)
        {
            _appDbContext.Pedido.Add(pedido);
            _appDbContext.SaveChanges();
        }
        public List<Pedido> Obter()
        {
            return _appDbContext.Pedido.Select(x => x).ToList();
        }

        public bool Obter(string cnpj)
        {
            return _appDbContext.Pedido.Any(x => x.CNPJ == cnpj);
        }
    }
}
