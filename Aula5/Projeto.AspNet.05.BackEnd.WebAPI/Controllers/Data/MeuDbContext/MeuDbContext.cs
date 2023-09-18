using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.MeuDbContext
{
    public class MeuDbContext : DbContext
    {

        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base (options)
        {

        }

        public DbSet<Estudante> Estudante { get; set; }
    }
}
