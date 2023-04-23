using Newtonsoft.Json;
using CrudWag.Models;

namespace CrudWag.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpcontext;
        public Sessao(IHttpContextAccessor httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public UsuarioModel BuscarSessao()
        {
            string sessaoUsuario = _httpcontext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpcontext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _httpcontext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
