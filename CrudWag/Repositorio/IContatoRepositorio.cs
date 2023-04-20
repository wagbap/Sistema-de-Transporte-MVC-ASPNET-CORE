using CrudWag.Models;

namespace CrudWag.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Create(ContatoModel contato);

        List<ContatoModel> BuscarTodos();
        ContatoModel ListaPorId(int id);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
