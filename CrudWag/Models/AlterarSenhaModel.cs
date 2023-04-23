using System.ComponentModel.DataAnnotations;

namespace CrudWag.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Confirmar a Senha Atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova Senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage ="Confirmar a nova Senha")]
        [Compare("NovaSenha", ErrorMessage ="As Senhas não coincidem")]
        public string ConfirmarNovaSenha { get; set;}
    }
}
