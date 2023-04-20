using CrudWag.Data.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudWag.Models
{
    public class MotoristaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string? MotoristaImagem { get; set; }  // stores movie image name with extension (eg, image0001.jpg)
        [NotMapped]
        [Required(ErrorMessage = "Selecione uma imagem")]
        public IFormFile ImageFile { get; set; }

        public string DOB { get; set; }

        public string data_adesao { get; set; }
        public SexoEnum sexo { get; set; }
    }
}
