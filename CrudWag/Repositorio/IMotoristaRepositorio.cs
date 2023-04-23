using CrudWag.Models;

namespace CrudWag.Repositorio
{
    public interface IMotoristaRepositorio
    {
        MotoristaModel Create(MotoristaModel motorista);

        List<MotoristaModel> BuscarTodos();
        MotoristaModel ListaPorId(int id);

        MotoristaModel Atualizar(MotoristaModel motorista);

        bool Apagar(int id);
    }
}
