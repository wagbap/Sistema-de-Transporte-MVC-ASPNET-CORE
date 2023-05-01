using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CrudWag.Data.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudWag.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data Início Obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Modelo Obrigatorio")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Preço Total Obrigatorio")]
        public float PrecoTotal { get; set; }

        [Required(ErrorMessage = "Prova que tens carta de condução")]
        public string ProvaCartaConducao { get; set; }

        // relação entre tabelas
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        public int? TransporteId { get; set; }
        public TransporteModel? Transporte { get; set; }



        // relacionamento entre tabelas
        [NotMapped]
        public List<int>? MotoristaId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? MotoristaList { get; set; }

        [NotMapped]
        public string? MotoristaNames { get; set; }

        public virtual List<MotoristaModel>? Motorista { get; set; }

        [NotMapped]
        public MultiSelectList? MultiGenreList { get; set; }
    }
}
