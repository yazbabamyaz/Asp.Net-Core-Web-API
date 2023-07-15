using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        //bağlantı dizesini alcaz bunu da kalıtım yoluyla base e yollayacaz.:dbcontext
        //2.adım appsetting ayarı
        //3.adım program.cs servis kaydı
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
