using GamothequeWPF.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF
{
    class Context : DbContext
    {
        private static Context _context = null;
        public async static Task<Context> GetCurrent()
        {
            if (_context == null)
            {
                _context = new Context(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }

            return _context;
        } 

        public Context(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        public string DatabasePath { get; }
        public DbSet<Game> Game { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={Database}", x => x.SuppressForeignKeyEnforcement());
        }
    }
}
