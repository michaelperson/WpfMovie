using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WpfMovie.EntityFramework.Config;
using WpfMovie.EntityFramework.Datasets;
using WpfMovie.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL
{
    public class DataContext : DbContext
    {
        private readonly string _cnstr;
        public DataContext(string cnstr)
        {
            this._cnstr = cnstr;
        }
        #region DbSet
            public DbSet<Film> Films { get; set; }
        #endregion


         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Console.WriteLine(message));

            optionsBuilder.UseSqlServer(_cnstr);// @"Server=(localdb)\MSSQLLocalDB;Database=MoviesEf;User Id=EFUser;Password=Test1234=;"
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmConfig());            
            modelBuilder.ApplyConfiguration(new DataSet());
        }
    }
}
