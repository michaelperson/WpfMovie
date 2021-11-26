using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMovie.EntityFramework.Entities
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Titre { get; set; }
        public int Annee { get; set; }
        public string Realisateur { get; set; }
        public string ActeurPrincipal { get; set; }

        public string Genre { get; set; }

    }
}
