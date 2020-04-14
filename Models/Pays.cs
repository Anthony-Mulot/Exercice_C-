using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class Pays
    {
        public int PaysID { get; set; }
        public string Nom_de_Pays { get; set; }

        public virtual ICollection<Personne> Personnes { get; set; } //ICollection aide le framwork a communiquer entre les tables (Un Garage peut apparaitre pour plusieurs Voiture)

    }
}