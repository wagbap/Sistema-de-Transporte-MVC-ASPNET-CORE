using CrudWag.Data;
using CrudWag.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CrudWag.Repositorio
{
    public class MotoristaRepositorio : IMotoristaRepositorio
    {
        private readonly BancoDbContext _bancoDbContext;
        public MotoristaRepositorio(BancoDbContext bancoDbContext)
        {
            _bancoDbContext = bancoDbContext;
        }

      
        public bool Apagar(int id)
        {
            var motorista = ListaPorId(id);
            if (motorista == null) return false;

            if (!string.IsNullOrEmpty(motorista.MotoristaImagem))
            {
                ExcluirImagemAntiga(motorista.MotoristaImagem);
                motorista.MotoristaImagem = motorista.MotoristaImagem;
            }
            _bancoDbContext.TbMotorista.Remove(motorista);
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
        public MotoristaModel Atualizar(MotoristaModel motorista)
        {
            MotoristaModel motoristaDB = ListaPorId(motorista.Id);

            if (motoristaDB == null) throw new Exception("nao encontrado");

            motoristaDB.MotoristaImagem = motorista.MotoristaImagem;
            motoristaDB.Nome = motorista.Nome;
            motoristaDB.Email = motorista.Email;
            motoristaDB.Telefone = motorista.Telefone;
            motoristaDB.Endereco = motorista.Endereco;
            motoristaDB.DOB = motorista.DOB;
            motoristaDB.sexo = motorista.sexo;
            motoristaDB.data_adesao = motorista.data_adesao;

            _bancoDbContext.TbMotorista.Update(motoristaDB);
            _bancoDbContext.SaveChanges();
            return motoristaDB;

        }

        public List<MotoristaModel> BuscarTodos()
        {
            return _bancoDbContext.TbMotorista.ToList();
        }

        public MotoristaModel Create(MotoristaModel motorista)
        {
            _bancoDbContext.TbMotorista.Add(motorista);
            _bancoDbContext.SaveChanges();
            return motorista;
        }

        public MotoristaModel ListaPorId(int id)
        {
            return _bancoDbContext.TbMotorista.FirstOrDefault(x => x.Id == id);
        }
    }
}