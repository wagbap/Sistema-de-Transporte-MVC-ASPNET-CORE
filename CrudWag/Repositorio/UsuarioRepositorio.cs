using Microsoft.EntityFrameworkCore;
using CrudWag.Data;
using CrudWag.Models;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrudWag.Repositorio
{
  

    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoDbContext _bancoDbContext;

        public UsuarioRepositorio(BancoDbContext bancoDbContext)
        {
            _bancoDbContext = bancoDbContext;
        }

       
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
        
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoDbContext.TbUsuarios.Add(usuario);
            _bancoDbContext.SaveChanges();
            return usuario;


        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDb = ListarPorId(alterarSenhaModel.Id);
            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização da senha");
            if (!usuarioDb.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new System.Exception("Senha Atual nao confirmada");
            if (usuarioDb.SenhaValida(alterarSenhaModel.NovaSenha)) throw new System.Exception("Senha nova nao pode ser iguala senha antiga");

            usuarioDb.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDb.DataAtualizacao = DateTime.Now;
            _bancoDbContext.TbUsuarios.Update(usuarioDb);
            _bancoDbContext.SaveChanges();
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            var usuario = ListarPorId(id);
            if (usuario == null) return false;

            if (!string.IsNullOrEmpty(usuario.ImageURL))
            {
                ExcluirImagemAntiga(usuario.ImageURL);
                usuario.ImageURL = usuario.ImageURL;
            }
            _bancoDbContext.TbUsuarios.Remove(usuario);
            _bancoDbContext.SaveChanges();
            return true;
        }

        public void ExcluirImagemAntiga(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + imageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }


        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioBd = ListarPorId(usuario.Id);

            if (usuarioBd == null)  throw new Exception("Usuario não encontrado");

            if (!string.IsNullOrEmpty(usuario.ImageURL) && usuario.ImageURL != usuarioBd.ImageURL)
            {
                ExcluirImagemAntiga(usuarioBd.ImageURL);
                usuarioBd.ImageURL = usuario.ImageURL;
            }

            usuarioBd.Nome = usuario.Nome;
            usuarioBd.ImageURL = usuario.ImageURL;
            usuarioBd.Login = usuario.Login;
            usuarioBd.Email = usuario.Email;
            usuarioBd.Perfil = usuario.Perfil;
            usuario.DataAtualizacao = DateTime.Now;

            _bancoDbContext.TbUsuarios.Update(usuarioBd);
            _bancoDbContext.SaveChanges();
            return usuarioBd;
        }

        public UsuarioModel BuscarPorEmailLogin(string email, string login)
        {
            return _bancoDbContext.TbUsuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoDbContext.TbUsuarios.FirstOrDefault(x => x.Login == login);
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoDbContext.TbUsuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> ListarTodos()
        {
            return _bancoDbContext.TbUsuarios
                   .ToList();
        }
    }
}
