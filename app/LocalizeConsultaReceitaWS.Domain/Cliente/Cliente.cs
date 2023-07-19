using System.ComponentModel.DataAnnotations;

namespace LocalizeConsultaReceitaWS.Domain.Cliente
{
    public class Cliente
    {
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 Caracteres.")]
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        public string CNPJ { get; set; }
    }
}
