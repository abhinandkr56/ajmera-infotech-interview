using AjmeraInfotech.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraInfotech.Repository
{
    public class BookContext:DbContext
    {
        private IConfiguration Configuration;
        public BookContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Book> books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
        }
    }
}
