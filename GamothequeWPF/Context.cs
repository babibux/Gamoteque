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
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
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
        public DbSet<Model.Type> Type { get; set; }
        public DbSet<GameType> GameType { get; set; }
        public DbSet<GameVoiceLanguage> GameVoiceLanguage { get; set; }
        public DbSet<GameTextLanguage> GameTextLanguage { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameType>()
                .HasKey(gt => new { gt.IdGame, gt.IdType });
            modelBuilder.Entity<GameVoiceLanguage>()
                .HasKey(gvl => new { gvl.IdGame, gvl.NameLanguage });
            modelBuilder.Entity<GameTextLanguage>()
                .HasKey(gtl => new { gtl.IdGame, gtl.NameLanguage });
        }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
