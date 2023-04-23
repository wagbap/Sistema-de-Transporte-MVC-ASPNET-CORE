using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudWag.Data.Enum;
using CrudWag.Helpers;

namespace CrudWag.Models
{
    public class UsuarioModel
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
        [Required(ErrorMessage = "Selecione uma imagem para o usuário")]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Digite a Senha do Usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // relacionamento entre tabelas
        public virtual List<ContatoModel>? Contatos { get; set; }
      
        // verificaçãoo da senha de login
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        // metodo para gerar hash da senha
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }


    }
}
