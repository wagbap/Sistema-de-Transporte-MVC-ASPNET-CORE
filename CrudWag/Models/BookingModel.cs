using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CrudWag.Data.Enum;


namespace CrudWag.Models
{
    public class TransporteModel
    {
        [Key]
        public int Id { get; set; }
        public string? ImageURL { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Modelo Obrigatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ano do fabrico do Transporte Obrigatorio")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Inserir Ano Capacidade de Passageiro")]
        public string CapacidadePassageiro { get; set; }

        [Required(ErrorMessage = "Inserir a taxa do aluguel")]
        public float TaxaAluguer { get; set; }

        [Required(ErrorMessage = "Seleciona a disponibilidade")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Seleciona o tipo de Transporte")]
        public TransporteTipoEnum TransporteTipo { get; set; }
    }
}
