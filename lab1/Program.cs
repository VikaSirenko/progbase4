using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            PresidentService presidentCard = PresidentService.DoIdentification(1567832);
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i <= 10; i++)
            {
                JuniorCard juniorCard = new JuniorCard();
                Console.WriteLine();
            }

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.ReadKey();
            Console.Clear();



            using (PensionCard pensionCard = new PensionCard("Sara", 65))
            {
                GC.SuppressFinalize(pensionCard);
                pensionCard.PutMoney(50);
                Console.WriteLine($"Current amount of money {pensionCard.CheckBalance()}");
            }

            Console.ReadKey();
            Console.Clear();


            VipCard vipCard= new VipCard("Petro", 14);

            Console.ReadKey();
            Console.Clear();


        }
    }

    public abstract class BankCard
    {
        protected string user_name;
        protected int user_age;
        protected double amount_of_money;


        public BankCard(string user_name, int user_age)
        {
            this.Name = user_name;
            this.Age = user_age;
            this.amount_of_money = default;
            Console.WriteLine("BankCard constructor with param");
        }

        public BankCard()
        {
            this.Name = "Client";
            this.Age = 18;
            this.amount_of_money = default;
            Console.WriteLine("BankCard constructor without param");

        }

        public string Name
        {
            get
            {
                return user_name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    user_name = value;
                }
                else
                {
                    Console.WriteLine("You must enter your username");

                }

            }
        }

        public abstract int Age { get; set; }

        public double CheckBalance()
        {
            return amount_of_money;
        }

        public abstract void WithdrawMoney(double amount);

        public abstract void PutMoney(double amount);


    }


    public class JuniorCard : BankCard
    {
        private string parent_number;

        public JuniorCard()
        {
            this.Name = "Junior client";
            this.Age = 16;
            this.amount_of_money = default;
            this.parent_number = default;
            Console.WriteLine("JuniorCard constructor without param");

        }

        public JuniorCard(string user_name, int user_age, string parent_number) : base(user_name, user_age)
        {
            this.parent_number = parent_number;
            Console.WriteLine("JuniorCard constructor with param");
        }

        public string ParentNumber
        {
            get
            {
                return parent_number;
            }
        }

        public override int Age
        {
            get
            {
                return user_age;
            }
            set
            {
                if (value >= 16 && value <= 18)
                {
                    user_age = value;
                }
                else
                {
                    Console.WriteLine("You do not fit the age of the Junior Card, choose another card");
                }
            }
        }

        public override void WithdrawMoney(double amount)
        {
            if (amount < 0 || amount > amount_of_money)
            {
                Console.WriteLine("It is impossible to withdraw money");
            }
            else if (amount >= 3000)
            {
                Console.WriteLine("You can't withdraw such a large amount");
            }
            else
            {
                this.amount_of_money = amount_of_money - amount;

            }


        }

        public override void PutMoney(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Set value is negative");
            }
            else if (amount_of_money + amount > 20000)
            {
                Console.WriteLine("It is not possible to put money on the card, because the card has a limit of 20,000");

            }
            else
            {
                this.amount_of_money = amount_of_money + amount;
            }
        }



        ~JuniorCard()
        {
            Console.WriteLine("Junior card destructor done!");
        }



    }


    public class PensionCard : BankCard, IDisposable
    {

        public PensionCard()
        {
            this.Name = "Pension client";
            this.Age = 60;
            this.amount_of_money = default;
            Console.WriteLine("PensionCard constructor without param");

        }

        public PensionCard(string user_name, int user_age) : base(user_name, user_age)
        {
            Console.WriteLine("PensionCard constructor with param");
        }


        public override int Age
        {
            get
            {
                return user_age;
            }
            set
            {
                if (value >= 60 && value <= 99)
                {
                    user_age = value;
                }
                else
                {
                    Console.WriteLine("You do not fit the age of the Pension Card, choose another card");
                }
            }
        }

        public override void PutMoney(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Set value is negative");
            }
            else if (amount_of_money + amount > 100000)
            {
                Console.WriteLine("It is not possible to put money on the card, because the card has a limit of 100,000");

            }
            else
            {
                this.amount_of_money = amount_of_money + amount;
            }
        }



        public override void WithdrawMoney(double amount)
        {
            if (amount < 0 || amount > amount_of_money)
            {
                Console.WriteLine("It is impossible to withdraw money");
            }
            else
            {
                this.amount_of_money = amount_of_money - amount;

            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("Pension card dispose done!");
        }

        ~PensionCard()
        {
            Console.WriteLine("Pension card destructor done!");

        }

    }

    public class VipCard : BankCard
    {
        private double special_bonuses;

        static VipCard()
        {
            Console.WriteLine("Congratulations, you are the first VIP user.(static constructor)");
        }

        public VipCard()
        {
            this.Name = "Vip client";
            this.Age = 18;
            this.amount_of_money = default;
            this.special_bonuses = default;
            Console.WriteLine("VipCard constructor without param");
        }


        public VipCard(string user_name, int user_age) : base(user_name, user_age)
        {
            this.special_bonuses = default;
            Console.WriteLine("VipCard constructor with param");
        }

        public double Bonuses
        {
            get
            {
                return special_bonuses;
            }
        }


        public override int Age
        {
            get
            {
                return user_age;
            }
            set
            {
                if (value >= 18 && value <= 99)
                {
                    user_age = value;
                }
                else
                {
                    Console.WriteLine("You do not fit the age of the Vip Card, choose another card");
                }
            }
        }

        public override void PutMoney(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Set value is negative");
            }
            else
            {
                this.amount_of_money = amount_of_money + amount;
                if (amount >= 50000)
                {
                    special_bonuses += 5;
                }
            }
        }



        public override void WithdrawMoney(double amount)
        {
            if (amount < 0 || amount > amount_of_money)
            {
                Console.WriteLine("It is impossible to withdraw money");
            }
            else if (amount > 100000)
            {
                Console.WriteLine("We need to make sure that you are withdrawing money, so you will now be called to confirm your identity");
            }
            else
            {
                this.amount_of_money = amount_of_money - amount;

            }

        }

    }


    public class PresidentService : VipCard
    {
        private static int idCode = 1567832;
        private PresidentService()
        {
            Console.WriteLine("President service. This is private constructor");
        }

        public static PresidentService DoIdentification(int id_code)
        {
            if (id_code == idCode)
            {
                PresidentService presidentCard = new PresidentService();
                return presidentCard;
            }
            Console.WriteLine("You entered an incorrect id");
            return null;
        }



    }
}
