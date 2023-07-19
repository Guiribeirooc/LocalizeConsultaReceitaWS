using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace LocalizeConsultaReceitaWS.Domain.Login
{
    public class Login
    {
        [Required (ErrorMessage = "The email address is required.")]
        [Email(ErrorMessage = "The email address is not valid.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passoword is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
