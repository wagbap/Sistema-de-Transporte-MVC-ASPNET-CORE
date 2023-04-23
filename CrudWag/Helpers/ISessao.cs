using CrudWag.Models;

namespace CrudWag.Helpers
{
    public interface ISessao
    {
        void CriarSessao(UsuarioModel usuarioModel);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
