using System.ComponentModel.DataAnnotations;

namespace CrudWag.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite Senha")]
        public string Senha { get; set; }
    }
}
