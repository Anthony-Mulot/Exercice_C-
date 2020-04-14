using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Training.Models;

namespace Training.DAL
{
    public class PersonneInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PersonneContext>
    {
        protected override void Seed(PersonneContext context)
        {
            var voitures = new List<Personne>
            {

            };

            voitures.ForEach(s => context.Personnes.Add(s));
            context.SaveChanges();


            var garages = new List<Pays>
            {

            };
            garages.ForEach(s => context.Pays.Add(s));
            context.SaveChanges();




        }
    }
}