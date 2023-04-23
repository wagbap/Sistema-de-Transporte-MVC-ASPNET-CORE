using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudWag.Data.Enum;

namespace CrudWag.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuario")]
        public string Nome { get; set; }
        
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "Digite o Login do Usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Usuario")]
        [EmailAddress(ErrorMessage = "O E-mail informado nao e valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o Perfil do Usuario")]
        public PerfilEnum Perfil { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
