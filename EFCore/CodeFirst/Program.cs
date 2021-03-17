using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EntityFramework_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AccountContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var person = new Person
                {
                    PersonName = "Richard"
                };
                person.account = new List<SavingAccount>
                {
                    new SavingAccount {Amount =2000000, IdentificationNumber = 1, Rates = 1.05, RatePeriod = "months", CreationDate = Convert.ToDateTime("10/11/2017") },
                    new SavingAccount {Amount =250000, IdentificationNumber = 2, Rates = 1.15, RatePeriod = "years", CreationDate = Convert.ToDateTime("10/11/2017")}, 
                    new SavingAccount {Amount =10000000, IdentificationNumber = 3, Rates = 1.02, RatePeriod= "years", CreationDate = Convert.ToDateTime("10/11/2017")},
                };
                SavingCalculator calcul = new SavingCalculator();
                double total = 0;
                foreach (SavingAccount account in person.account)
                {
                    var period = DateAndTime.DateDiff(DateInterval.Month, account.CreationDate, DateTime.Today);
                    double result = 0;
                    result = calcul.CalculateTotalSaved(account.Amount, account.Rates, period, account.RatePeriod);
                    Console.WriteLine(Math.Round(result, 2));
                    total = total + result;
                }

                    Console.WriteLine(Math.Round(total,2));
                    context.Add(person);
                    context.SaveChanges();

                    MessageBox.Show("Total Account : " + Convert.ToString(Math.Round(total, 2)),"result" ,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            


        }
    }
    public class SavingAccount
    {
        public Guid SavingAccountID { get; set; }
        public int IdentificationNumber { get; set; }
        public  double Amount { get; set; }
        public double Rates { get; set; }
        public DateTime CreationDate { get; set; }
        public string RatePeriod { get; set; }


    }
    public class Person
    {
        public Guid PersonID { get; set; }
        public string PersonName { get; set; }
        public ICollection<SavingAccount> account { get; set; }

    }


    public class SavingCalculator
    {
        
/*        public Guid SavingCalculatorID { get; set; }
        public SavingAccount savingAccountID {get; set; }*/

        public Double CalculateTotalSaved(double amount, double savingRate, double period, string rateperiod)
        {
            
            if( rateperiod == "years")
            {
                period = period / 12;
            }
          
            Double result = amount * Math.Pow(savingRate, period);
            return result;
        }
        

    }
    public class AccountContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SavingAccount> SavingAccounts { get; set; }
        /*public virtual DbSet<SavingCalculator> SavingCalculators { get; set; }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LOCALHOST\SQLEXPRESS;Database=EntityQuest;Integrated Security=True");
        }
    }

}
