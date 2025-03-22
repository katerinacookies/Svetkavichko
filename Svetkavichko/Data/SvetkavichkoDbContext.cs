using Microsoft.EntityFrameworkCore;
using Svetkavichko.Models;
using Svetkavichko.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svetkavichko.Data
{
    public class SvetkavichkoDbContext : DbContext
    {
        private readonly string _dbPath;
        public SvetkavichkoDbContext()
        {
            _dbPath = PathDb.GetPath("Svetkavichko.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(string.IsNullOrWhiteSpace(_dbPath))
            {
                throw new ArgumentException("Пътят на базата данни не е зададен");
            }
            string connDb = $"Filename={_dbPath}";
            options.UseSqlite(connDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Chore> Chores { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Motivation> Motivations { get; set; }
    }
}
