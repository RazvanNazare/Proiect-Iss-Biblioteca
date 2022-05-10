using iss.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<LibraryModel> Libraries { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
    }
}
