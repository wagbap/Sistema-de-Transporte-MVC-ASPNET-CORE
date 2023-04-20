using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudWag.Models
{
    public class BMIData
    {
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
