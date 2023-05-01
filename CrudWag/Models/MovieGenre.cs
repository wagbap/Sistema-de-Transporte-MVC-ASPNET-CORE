using System.ComponentModel.DataAnnotations;
using CrudWag.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWag.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }
}

