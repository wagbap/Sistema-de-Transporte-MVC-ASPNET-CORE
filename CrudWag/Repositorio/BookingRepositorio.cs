using CrudWag.Data;
using CrudWag.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWag.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoDbContext _bancoDbContext;
        public ContatoRepositorio(BancoDbContext bancoDbContext)
        {
            _bancoDbContext = bancoDbContext;
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListaPorId(contato.Id);

            if (contatoDB == null) throw new Exception("nao encontrado");

            contatoDB.ImgUrl = contato.ImgUrl;
            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Phone = contato.Phone;
            contatoDB.Job = contato.Job;
            contatoDB.Observation = contato.Observation;

            _bancoDbContext.TbContatos.Update(contatoDB);
            _bancoDbContext.SaveChanges();
            return contatoDB;

        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoDbContext.TbContatos.ToList();
        }

        public ContatoModel Create(ContatoModel contato)
        {
            _bancoDbContext.TbContatos.Add(contato);
            _bancoDbContext.SaveChanges();
            return contato;
        }

        public ContatoModel ListaPorId(int id)
        {
            return _bancoDbContext.TbContatos.FirstOrDefault(x => x.Id == id);
        }
    }
}