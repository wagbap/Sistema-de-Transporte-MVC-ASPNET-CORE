using CrudWag.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace CrudWag.Repositorio
{
    public interface IBookingRepositorio
    {

        List<BookingModel> BuscarTodos();

        bool Add(BookingModel model);
        bool Update(BookingModel model);
        BookingModel GetById(int id);
        bool Delete(int id);

        List<int> GetMotoristaByBookingId(int movieId);
      
    }
}
