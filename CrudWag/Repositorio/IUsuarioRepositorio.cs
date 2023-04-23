using CrudWag.Models;

namespace CrudWag.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> ListarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel ListarPorId(int id);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
        UsuarioModel BuscarPorLogin(string login);

        UsuarioModel BuscarPorEmailLogin(string email, string login);

        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
    }
}
