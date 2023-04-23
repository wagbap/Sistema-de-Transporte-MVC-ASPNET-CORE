using CrudWag.Models;

namespace CrudWag.Helpers
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
