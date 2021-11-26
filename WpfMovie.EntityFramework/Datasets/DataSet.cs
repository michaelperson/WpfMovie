using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfMovie.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMovie.EntityFramework.Datasets
{
    public class DataSet : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasData(
                new Film
                {
                    FilmId = 1,
                    Titre = "Star Wars : Un nouvel espoir",
                    Annee = 1977,
                    ActeurPrincipal = "Mark Hammil",
                    Genre = "Science-Fiction",
                    Realisateur = "Georges Lucas"
                },
                new Film
                {
                    FilmId = 2,
                    Titre = "Star Wars : L'empire contre-attaque",
                    Annee = 1980,
                    ActeurPrincipal = "Mark Hammil",
                    Genre = "Science-Fiction",
                    Realisateur = "Georges Lucas"
                },
                new Film
                {
                    FilmId = 3,
                    Titre = "Star Wars : Le retour du Jedi",
                    Annee = 1983,
                    ActeurPrincipal = "Mark Hammil",
                    Genre = "Science-Fiction",
                    Realisateur = "Georges Lucas"
                },
                new Film
                {
                    FilmId = 4,
                    Titre = "Hooligans",
                    Annee = 2005,
                    ActeurPrincipal = "Charlie Hunnam",
                    Genre = "Société",
                    Realisateur = "Lexi Alexander"
                },
                new Film
                {
                    FilmId = 5,
                    Titre = "LOTR - La communauté de l'anneau",
                    Annee = 2001,
                    ActeurPrincipal = "Elijah Wood",
                    Genre = "Heroic-Fantasy",
                    Realisateur = "Peter Jackson"
                },
                new Film
                {
                    FilmId = 6,
                    Titre = "LOTR - Les deux tours",
                    Annee = 2002,
                    ActeurPrincipal = "Elijah Wood",
                    Genre = "Heroic-Fantasy",
                    Realisateur = "Peter Jackson"
                },
                new Film
                {
                    FilmId = 7,
                    Titre = "LOTR - Le retour du roi",
                    Annee = 2003,
                    ActeurPrincipal = "Elijah Wood",
                    Genre = "Heroic-Fantasy",
                    Realisateur = "Peter Jackson"
                }
                );
        }
    }
}
