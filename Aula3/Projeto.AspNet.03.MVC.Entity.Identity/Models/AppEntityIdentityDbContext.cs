using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Projeto.AspNet._03.MVC.Entity.Identity.Models
{
    public class AppEntityIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppEntityIdentityDbContext(DbContextOptions<AppEntityIdentityDbContext> options) : base(options)
        {
        }
    }
}
