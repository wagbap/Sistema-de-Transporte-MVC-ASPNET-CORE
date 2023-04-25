using CrudWag.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWag.Data
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> TbContatos { get; set; }

        public DbSet<MotoristaModel> TbMotorista { get; set; }

        public DbSet<UsuarioModel> TbUsuarios { get; set; }

    }
}
