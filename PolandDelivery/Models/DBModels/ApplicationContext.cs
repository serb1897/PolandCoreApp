using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<NewsContent> NewsContents { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Callback> Callbacks { get; set; }
        public DbSet<Mailing> Mailings { get; set; }
        public DbSet<Logger> Loggers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
