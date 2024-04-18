using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp3.data.entity;

namespace WpfApp3.config
{
    public class MainContext : DbContext
    {
        private static MainContext instance;

        public static MainContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainContext();
                }
                return instance;
            }
        }

        public MainContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Products.AddRange(
                new Product()
                {
                    Name = "asdasd"
                },
                new Product()
                {
                    Name = "waafawf"
                },
                new Product()
                {
                    Name = "waafawf"
                },
                new Product()
                {
                    Name = "waafawf"
                },
                new Product()
                {
                    Name = "waafawf"
                },
                new Product()
                {
                    Name = "waafawf"
                },
                new Product()
                {
                    Name = "waafawf"
                }
                );
            SaveChanges();
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=aboba;User ID=sa;Password=yourStrong(!)Password;");
        }

    }
}
