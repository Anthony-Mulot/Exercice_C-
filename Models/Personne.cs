using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class Personne { 
        public int PersonneID { get; set;}

        public string Nom { get; set; }

     
        public int PaysID { get; set; }

        public virtual Pays Pays { get; set; } // 1 seul pays par personne

    }
}