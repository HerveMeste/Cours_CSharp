using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkLinQ
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new AnimalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Species felins = new Species
                {
                    Name = "Felins"
                };
                Species reptiles = new Species
                {
                    Name = "Reptiles"
                };
                Animal whiteCougar = new Animal
                {
                    Name = "white cougar",
                    DateOfBirth = Convert.ToDateTime("11/11/2019"),
                    Number = 3,
                    Species = felins, 

                };
                Animal whiteTiger = new Animal
                {
                    Name = "white tiger",
                    DateOfBirth = Convert.ToDateTime("01/10/2019"),
                    Number = 100,
                    Species = felins,
                };
                Animal albinosturtles = new Animal
                {
                    Name = "Albinos turtle",
                    DateOfBirth = Convert.ToDateTime("10/05/1980"),
                    Number = 15,
                    Species = reptiles,
                };
                context.AddRange(felins, reptiles, whiteCougar, whiteTiger, albinosturtles);
                context.SaveChanges();
                
            }

            using (var context = new AnimalContext())
            {
                IQueryable<Species> species = from data in context.Species
                                              select data;
                IQueryable<Species> speciesFelin = from data in context.Species
                                                   where data.Name == "Felins"
                                                   select data;
                IQueryable<Animal> felins = from animal in context.Animals
                             where animal.Species == speciesFelin
                             select animal;

                IQueryable < Animal > animals = from data in context.Animals
                                                select data;

                var resultJoined = from specie in species
                                   join animal in animals on specie.SpeciesId equals animal.Species.SpeciesId
                                   select new { NomEspece = specie.Name, NameAnimal = animal.Name, NumberAnimal = animal.Number};
                var resultJoinedGroup = from animal in resultJoined
                                        group animal by animal.NomEspece into gr
                                        select new
                                        {
                                            NomEspece = gr.Key,
                                            TotalAnimaux = gr.Count()

                                        };
                foreach(var lol in resultJoined)
                {
                    Console.WriteLine(lol.NameAnimal);
                }
                var resultSpecies = resultJoinedGroup.ToList();
                var resultAnimaux = resultJoined.ToList();

                   MessageBox.Show
                    ("Il reste " + resultSpecies[0].TotalAnimaux + " especes de " + resultSpecies[0].NomEspece +" dont " + resultAnimaux[0].NumberAnimal + " "+ resultAnimaux[0].NameAnimal  + " et "
                    + resultAnimaux[1].NumberAnimal + " " + resultAnimaux[1].NameAnimal + " et " + resultSpecies[1].TotalAnimaux + "espece de " + resultSpecies[1].NomEspece + " dont " +  
                     resultAnimaux[2].NumberAnimal + " "+ resultAnimaux[2].NameAnimal,
                    "Resultat", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
            }

        }

    }
}
    public class Species
    {
        public Guid SpeciesId { get; set; }
        public String Name { get; set; }
        
    }
    public class Animal
    {
        public Guid AnimalId { get; set; }
        public String Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
        public int Number { get; set; }
}
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=EntityQuestLinQ;Integrated Security=True");
        }
    }



