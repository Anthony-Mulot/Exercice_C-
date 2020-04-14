using Training.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Training.DAL
{
    public class PersonneContext : DbContext //Hérite de DbContext .
    {

        public PersonneContext() : base("VoitureContext") // C'est un nouvel connexion avec personne context
        {
        }
        

        public DbSet<Personne> Personnes { get; set; } //Mettre dans la bdd le modèle Personne

        public DbSet<Pays> Pays { get; set; } // Mettre dans la bdd le modele Pays


        protected override void OnModelCreating(DbModelBuilder modelBuilder) //La table sera modelé en foction du modele
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Evite de mettre les noms de table au pluriels
        }
    }
}
 