using CrudWag.Models;

namespace CrudWag.Repositorio
{
    public interface ITransporteRepositorio
    {
        List<TransporteModel> ListarTodos();

        TransporteModel Create(TransporteModel transporte);
        TransporteModel ListarPorId(int id);
        TransporteModel Atualizar(TransporteModel transporte);
        bool Apagar(int id);

       

    }
}
