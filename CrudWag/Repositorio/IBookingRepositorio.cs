using CrudWag.Models;

namespace CrudWag.Repositorio
{
    public interface IBookingRepositorio
    {
        BookingModel Create(MotoristaModel motorista);

        List<BookingModel> BuscarTodos();
        BookingModel ListaPorId(int id);

        BookingModel Atualizar(BookingModel booking);

        bool Apagar(int id);
    }
}
