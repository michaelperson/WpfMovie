using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfMovie.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMovie.EntityFramework.Config
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            //Nom de la table
            builder.ToTable("Film");

            //PK
            builder.HasKey(x => x.FilmId);
            //Auto increment
            builder.Property(x => x.FilmId).ValueGeneratedOnAdd();

            //Le titre doit être unique
            builder.HasIndex(x => x.Titre).IsUnique();

            //La non nullité
            builder.Property(x => x.Titre).IsRequired().HasMaxLength(100).HasDefaultValue("");
            builder.Property(x => x.Annee).IsRequired();
            builder.Property(x => x.Realisateur).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ActeurPrincipal).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Genre).IsRequired().HasMaxLength(100);

            //LA contrainte sur l'année 
            builder.HasCheckConstraint("Chk_AnneeDeSortie", "Annee>1975");

         

        }
    }
}
