using System;
using System.Security.Cryptography.X509Certificates;

namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
                Console.WriteLine("Choisit un animal : humain, singe, elephant, tortue, lezard.");
                string animal = Console.ReadLine();
                if(animal == "humain")
                {
                    Console.WriteLine("choisis un nom à ton humain");
                    string nom = Console.ReadLine();
                    Human humain = new Human(nom);
                    Console.WriteLine(nom + " " +"est un humain");
                    humain.Eat();
                    humain.Move();
                    humain.Work();
                    

                }
                if (animal == "singe")
                {
                    Console.WriteLine("choisis un nom à ton singe");
                    string nom = Console.ReadLine();
                    Monkey monkey = new Monkey(nom);
                    Console.WriteLine(nom + " " + "est un singe");
                    monkey.Move();
                    monkey.Eat();
                }
                if (animal == "elephant")
                {
                    Console.WriteLine("choisis un nom à ton elephant");
                    string nom = Console.ReadLine();
                    Elephant elephant = new Elephant(nom);
                    Console.WriteLine(nom + " " + "est un elephant");
                    elephant.Move();
                    elephant.Eat();
                    elephant.Fly();
                }
                if (animal == "tortue")
                {
                    Console.WriteLine("choisis un nom à ta tortue");
                    string nom = Console.ReadLine();
                    Tortue tortue = new Tortue(nom);
                    Console.WriteLine(nom + " " + "est une tortue");
                    tortue.Move();
                    tortue.Eat();
                    tortue.DoArtMartial();
                }
                if (animal == "lezard")
                {
                    Console.WriteLine("choisis un nom à ton lezard");
                    string nom = Console.ReadLine();
                    Lezard lezard = new Lezard(nom);
                    Console.WriteLine(nom + " " + "est un lezard");
                    lezard.Move();
                    lezard.Eat();
                }
            }




        }

    }
    public abstract class Animals // Classe mere
    {
        protected string _name;
        protected bool _hairy;
        protected int _legsCount;

        public Animals(string name,  int legsCount, bool hairy)
        {
            _name = name;
            _legsCount = legsCount;
            _hairy = hairy;
            
        }
        public virtual void Eat() // la methode virtual permet a la classe fille de modifier la methode.
        {
            Console.WriteLine(_name + " eats");
        }
        public virtual void Move()
        {
            Console.WriteLine(_name + " move");
        }


    }
    public class Monkey : Animals
    {
        public Monkey(string name) : base(name, 4, true)
        {
           
        }
        public override void Move() // override permet la modification de la methode de la classe mère.
        {
            Console.WriteLine(_name + " " + "marche avec 2 jambes et 2 bras");
        }
        public override void Eat()
        {
            Console.WriteLine(_name + " " + "aime beaucoup les bananes");
        }
        
    }
    public class Human : Animals
    {
        public Human(string name) : base(name, 2, false)
        {

        }
        public void Work()
        {
            Console.WriteLine(_name + " " + "dois bosser son code !");
        }
        public override void Eat()
        {
            Console.WriteLine(_name + " " + "adore manger ");
        }
        public override void Move()
        {
            Console.WriteLine(_name + " " + "peux me deplacer a pied, mais comme il est fainéant il prends la voiture");
        }
    }
    public class Elephant : Animals
    {       
        public Elephant(string name) : base(name, 4, false)
        {

        }
        public override void Eat()
        {
            Console.WriteLine(_name + " " + "mange des plantes");
        }
        public override void Move()
        {
            Console.WriteLine(_name + " " + "marche avec 4 jambes");
        }
        public void Fly()
        {
            Console.WriteLine(_name + " " + "aimerais bien volé mais c'est dans les films");
        }

    }
   public class Tortue : Animals
    {
        public Tortue(string name) : base(name, 4, false) { }
        public override void Eat()
        {
            Console.WriteLine(_name + " " + "mange des pizzas... ");
        }
        public override void Move()
        {
            Console.WriteLine(_name + " " + "marche a 4 pattes mais certaines à 2.");
        }
        public void DoArtMartial()
        {
            Console.WriteLine(_name + " " + "ne s'est pas faire d'art martiaux");
        }
    }
    public class Lezard : Animals
    {
        public Lezard(string name) : base(name, 4, false) { }
        public override void Eat()
        {
            Console.WriteLine(_name + " " + " mange des insectes");
        }
        public override void Move()
        {
            Console.WriteLine(_name + " " + "marche avec 4 pattes et peut grimper sur les murs !");
        }
    }    
}

