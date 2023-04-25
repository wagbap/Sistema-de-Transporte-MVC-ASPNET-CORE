using CrudWag.Data;
using CrudWag.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CrudWag.Repositorio
{
    public class TransporteRepositorio : ITransporteRepositorio
    {
        private readonly BancoDbContext _bancoDbContext;
        public TransporteRepositorio(BancoDbContext bancoDbContext)
        {
            _bancoDbContext = bancoDbContext;
        }

      
        public bool Apagar(int id)
        {
            var transporte = ListaPorId(id);
            if (transporte == null) return false;

            if (!string.IsNullOrEmpty(transporte.ImageURL))
            {
                ExcluirImagemAntiga(transporte.ImageURL);
                transporte.ImageURL = transporte.ImageURL;
            }
            _bancoDbContext.TbTransporte.Remove(transporte);
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


        
        public List<TransporteModel> BuscarTodos()
        {
            return _bancoDbContext.TbTransporte.ToList();
        }


        public TransporteModel Create(TransporteModel transporte)
        {
            _bancoDbContext.TbTransporte.Add(transporte);
            _bancoDbContext.SaveChanges();
            return transporte;
        }

        public TransporteModel ListaPorId(int id)
        {
            return _bancoDbContext.TbTransporte.FirstOrDefault(x => x.Id == id);
        }

        public TransporteModel Atualizar(TransporteModel transporte)
        {
            TransporteModel transporteDB = ListaPorId(transporte.Id);

            if (transporteDB == null) throw new Exception("nao encontrado");

            transporteDB.ImageURL = transporte.ImageURL;
            transporteDB.Modelo = transporte.Modelo;
            transporteDB.Ano = transporte.Ano;
            transporteDB.CapacidadePassageiro = transporte.CapacidadePassageiro;
            transporteDB.TaxaAluguer = transporte.TaxaAluguer;
            transporteDB.IsAvailable = transporte.IsAvailable;
            transporteDB.TransporteTipo = transporte.TransporteTipo;


            _bancoDbContext.TbTransporte.Update(transporteDB);
            _bancoDbContext.SaveChanges();
            return transporteDB;
        }
     
    }
}