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
            throw new NotImplementedException();
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