using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_14MUIHomework.Data
{
    public class MaaserDb : DbContext
    {
        private readonly string _connectionString;

        public MaaserDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Maaser> Maaser { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Source> Sources { get; set; }
    }
}
