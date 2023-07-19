using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizeConsultaReceitaWS.Domain.Pedido
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Resultado { get; set; }
    }
}
