using System;
namespace ScopeTest
{
    public class MainProgram
    {
        public static void Main()
        {
            Console.WriteLine("Volume de biere disponible");
            float avalaibleBeerVolume = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Nombre de bouteilles disponible");
            int avalaibleBottles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nombre de capsules disponible");
            int avalaibleCapsules = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nombre de bouteilles a remplir");
            int bottleToFill = Convert.ToInt32(Console.ReadLine());

            BeerEncapsulator machine = new BeerEncapsulator();
            machine.SetAvalaibleCapsules(avalaibleCapsules);
            machine.SetAvalaibleBottles(avalaibleBottles);
            machine.SetAvalaibleBeerVolume(avalaibleBeerVolume);
            int numberBottleProduced =  machine.ProduceEncapsulateBeerBottles(bottleToFill);
            Console.WriteLine($"le nombre de bouteille produite est {numberBottleProduced}");
        }
        public class BeerEncapsulator
        {
            private float _avalaibleBeerVolume;
            private int _avalaibleBottles;
            private int _avalaibleCapsules;

            public int ProduceEncapsulateBeerBottles(int bottleToFill)
            {
                int numberOfBottleProduced = 0;
                while (AddBeer())
                {
                    numberOfBottleProduced = numberOfBottleProduced + 1;  
                }
                
                return numberOfBottleProduced;

            }
            bool AddBeer()
            {
                if (_avalaibleBeerVolume < 0.33)
                {
                    return false;
                }
                if (_avalaibleBottles == 0)
                {
                    return false;
                }
                if (_avalaibleCapsules == 0)
                {
                    return false;
                }
                _avalaibleBeerVolume = Convert.ToSingle(_avalaibleBeerVolume -0.33);
                _avalaibleBottles = _avalaibleBottles - 1;
                _avalaibleCapsules = _avalaibleCapsules - 1;
                return true;
                
            }

            public void SetAvalaibleCapsules(int avalaibleCapsules)
            {
                _avalaibleCapsules = avalaibleCapsules;
            }

            public void SetAvalaibleBottles(int avalaibleBottles)
            {
                _avalaibleBottles = avalaibleBottles;
            }

            public void SetAvalaibleBeerVolume(float avalaibleBeerVolume)
            {
                _avalaibleBeerVolume = avalaibleBeerVolume;
            }
        }


    }
}