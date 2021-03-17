using System;

namespace Constructeur1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Voulez-vous mettre 1 ou 2 valeurs à votre batiment?");
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {
                    Console.WriteLine("Veuillez choisir le nombre d'étages");
                    int numberOfFloors = Convert.ToInt32(Console.ReadLine());
                    Building batiment = new Building(numberOfFloors);
                    Console.WriteLine($"La taille de mon batiment est de {batiment.GetSize()} metres");
                    Console.WriteLine($"Le nombre d'etage est de {batiment.GetFloorCount()}");
                    Console.WriteLine($"La taille entre les etages est de {batiment.GetFloorMaxSize()} metres");
                }
                else if (value == 2)
                {
                    Console.WriteLine("Veuillez choisir le nombre d'étages");
                    int numberOfFloors = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Veuillez choisir la hauteur de votre batiment");
                    double heigth = Convert.ToDouble(Console.ReadLine());
                    Building batiment = new Building(numberOfFloors, heigth);
                    Console.WriteLine($"La taille de mon batiment est de {batiment.GetSize()} metres");
                    Console.WriteLine($"Le nombre d'etage est de {batiment.GetFloorCount()}");
                    Console.WriteLine($"La taille entre les etages est de {batiment.GetFloorMaxSize()} metres");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer 1 ou 2 valeurs");
                }
            }
        }
    }
    public class Building
    {
        private double _heigth;
        private int _numberOfFloors;

        public Building(int numberOfFloors, double heigth )
        {
            _numberOfFloors = numberOfFloors;
            _heigth = heigth;
        }
        public Building(int numberOfFloors)
        {
            _numberOfFloors = numberOfFloors;
            _heigth = 3 * numberOfFloors;
        }
        public double GetSize()
        {
            return _heigth;
        }
        public int GetFloorCount()
        {
            return _numberOfFloors;
        }
        public double GetFloorMaxSize()
        {
            return _heigth / _numberOfFloors;
        }
    }
}