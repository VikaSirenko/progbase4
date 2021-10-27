using System;


class Program
{
    static void Main(string[] args)
    {

        //1
        try
        {
            JuniorCard juniorCard = new JuniorCard(null, 12, "1234");
        }
        catch (ProgramExeption ex)
        {
            Console.WriteLine(ex.Message + "  " + ex.exceptionArgs.ErrorTime);
        }
        //You must enter your username


        //2
        try
        {
            PensionCard pensionCard = new PensionCard("Maria", 26);
        }
        catch (ProgramExeption ex)
        {
            Console.WriteLine(ex.Message + "  " + ex.exceptionArgs.ErrorTime);

        }

        //You do not fit the age of the Pension Card, choose another card




        //3 
        try
        {
            JuniorCard juniorCard1 = new JuniorCard("Polina", 17, "1234");
            juniorCard1.PutMoney(50500);
        }
        catch (ProgramExeption ex)
        {
            Console.WriteLine(ex.Message + "  " + ex.exceptionArgs.ErrorTime);
        }
        //It is not possible to put money on the card, because the card has a limit of 20,000



        //4
        JuniorCard juniorCard2 = new JuniorCard("Polina", 17, "1234");
        juniorCard2.RegisterForBankTour();
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
                ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "You must enter your username", LocationOfError = nameof(BankCard), ErrorTime = DateTime.Now };
                throw new ProgramExeption(errArgs.ErrorMessage, errArgs);

            }

        }
    }

    public abstract int Age { get; set; }

    public abstract void WithdrawMoney(User user, WithdrawMoneyEventArgs args);

    public abstract void PutMoney(double amount);

    public double CheckBalance()
    {
        return amount_of_money;
    }


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
                ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "You do not fit the age of the Junior Card, choose another card", LocationOfError = nameof(JuniorCard), ErrorTime = DateTime.Now };
                throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
            }
        }
    }

    public override void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > amount_of_money)
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is impossible to withdraw money", LocationOfError = nameof(JuniorCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
        }
        else if (args.amount_of_money >= 3000)
        {
            Console.WriteLine("You can't withdraw such a large amount");
        }
        else
        {
            this.amount_of_money = amount_of_money - args.amount_of_money;

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
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is not possible to put money on the card, because the card has a limit of 20,000", LocationOfError = nameof(JuniorCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
        }
        else
        {
            this.amount_of_money = amount_of_money + amount;
        }
    }



}


public class PensionCard : BankCard, ISpecialOpportunities
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
                ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "You do not fit the age of the Pension Card, choose another card", LocationOfError = nameof(PensionCard), ErrorTime = DateTime.Now };
                throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
            }
        }
    }

    public void FindOutExchangeRate()
    {
        Console.WriteLine("U.S. dollar (USD) -  26.29 \nEuro (EUR) - 30.38 \n Russian ruble (RUB) - 0.358 \n");
    }

    public void GetInsurance()
    {
        Console.WriteLine("You received regular insurance in the amount of UAH 5,000 (only health insurance)");
    }

    public override void PutMoney(double amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Set value is negative");
        }
        else if (amount_of_money + amount > 100000)
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is not possible to put money on the card, because the card has a limit of 100,000", LocationOfError = nameof(PensionCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);

        }
        else
        {
            this.amount_of_money = amount_of_money + amount;
        }
    }


    public override void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > amount_of_money)
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is impossible to withdraw money", LocationOfError = nameof(PensionCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
        }
        else
        {
            this.amount_of_money = amount_of_money - args.amount_of_money;

        }

    }


}

public class VipCard : BankCard, ISpecialOpportunities, IVipService
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
                ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "You do not fit the age of the Vip Card, choose another card", LocationOfError = nameof(VipCard), ErrorTime = DateTime.Now };
                throw new ProgramExeption(errArgs.ErrorMessage, errArgs);

            }
        }
    }

    public void FindOutExchangeRate()
    {
        Console.WriteLine("U.S. dollar (USD) -  26.29 \nEuro (EUR) - 30.38 \n Russian ruble (RUB) - 0.358 \n");
    }

    void ISpecialOpportunities.GetInsurance()
    {
        Console.WriteLine("You received regular insurance in the amount of UAH 10,000 (only health insurance)");
    }

    public override void PutMoney(double amount)
    {
        if (amount < 0)
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "Set value is negative", LocationOfError = nameof(VipCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
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



    public override void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > amount_of_money)
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is impossible to withdraw money", LocationOfError = nameof(VipCard), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
        }
        else if (args.amount_of_money > 100000)
        {
            Console.WriteLine("We need to make sure that you are withdrawing money, so you will now be called to confirm your identity");
        }
        else
        {
            this.amount_of_money = amount_of_money - args.amount_of_money;

        }

    }

    void IVipService.GetInsurance()
    {
        Console.WriteLine("you received a VIP insurance in the amount of UAH 100,000 (all types of insurance)");
    }

    public void GetInternationalServiceSupport()
    {
        Console.WriteLine("You have contacted the international VIP card support service. How can we help?");
        Console.ReadKey();
        Console.WriteLine("Wait for your request to be processed. You will be contacted. Thank you for using the VIP card.");
    }

    public void AccessToFastLine()
    {
        Console.WriteLine("Fast Line - accelerated services of all formalities when sending passengers on international flights at Boryspil airport, as well as - on arrival in Kiev.");
    }
}


public class PresidentService : VipCard
{
    private static int idCode = 1567832;
    private PresidentService()
    {
        Console.WriteLine("President service. This is private constructor");
    }

    private static bool DoIdentification(int id_code)
    {
        if (id_code == idCode)
        {
            return true;
        }
        Console.WriteLine("You entered an incorrect id");
        return false;
    }

    public static PresidentService CreatePresidentCard(int id_code)
    {
        if (DoIdentification(id_code) == true)
        {
            PresidentService presidentCard = new PresidentService();
            return presidentCard;
        }
        return null;
    }
}



public interface ISpecialOpportunities
{
    void FindOutExchangeRate();
    void GetInsurance();
}

public interface IVipService
{
    void GetInsurance();
    void GetInternationalServiceSupport();
    void AccessToFastLine();

}

public class User
{
    public string name;
    public int age;
    public event WithdrawMoneyHandle WithdrawMoneyEvent;

    public event Action<User, WithdrawMoneyEventArgs> WithdrawMoneyEvent2;

    public event Func<double> CheckBalanceEvent;
    public User(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void DetermineAmountToWithdrawn()
    {
        double amount;
        WithdrawMoneyEventArgs args;
        try
        {
            Console.Write("Enter the amount you want to withdraw ");
            amount = double.Parse(Console.ReadLine());
            args = new WithdrawMoneyEventArgs(amount);
        }
        catch
        {
            args = new WithdrawMoneyEventArgs();
        }

        Console.WriteLine("The user [{0}] wants to withdraw money ...\n", this.name);
        if (WithdrawMoneyEvent != null)
            WithdrawMoneyEvent((User)this, args);
    }

}


public class WithdrawMoneyEventArgs : EventArgs
{
    public double amount_of_money;

    public WithdrawMoneyEventArgs(double amount_of_money)
    {
        this.amount_of_money = amount_of_money;

    }

    public WithdrawMoneyEventArgs() : this(0) { }
}

public delegate void WithdrawMoneyHandle(User user, WithdrawMoneyEventArgs args);

public delegate double CheckBalanceHandle(User user);

class Bank
{
    private BankCard card;
    private double amount_of_money;

    public Bank(User user)
    {
        this.DetermineTypeOfCard();
        this.amount_of_money = card.CheckBalance();

        user.WithdrawMoneyEvent += new WithdrawMoneyHandle(this.card.WithdrawMoney);



        //anonymous method
        user.WithdrawMoneyEvent += delegate (User user, WithdrawMoneyEventArgs args)
         {
             this.WithdrawMoney(user, args);

         };



        // lambda expression
        user.WithdrawMoneyEvent += (User user, WithdrawMoneyEventArgs args) => this.WithdrawMoney(user, args);


        //Action 
        user.WithdrawMoneyEvent2 += new Action<User, WithdrawMoneyEventArgs>(card.WithdrawMoney);


        //Func
        user.CheckBalanceEvent += card.CheckBalance;

    }

    private void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > card.CheckBalance())
        {
            ProgramExeptionArgs errArgs = new ProgramExeptionArgs { ErrorMessage = "It is impossible to withdraw money", LocationOfError = nameof(Bank), ErrorTime = DateTime.Now };
            throw new ProgramExeption(errArgs.ErrorMessage, errArgs);
        }
        else
        {
            this.amount_of_money = card.CheckBalance() - args.amount_of_money;

        }

    }

    private void DetermineTypeOfCard()
    {
        Console.WriteLine("What type of card do you have?");
        string cardType = Console.ReadLine();
        switch (cardType)
        {
            case "vip":
                this.card = new VipCard();
                break;
            case "junior":
                this.card = new JuniorCard();
                break;
            case "pension":
                this.card = new PensionCard();
                break;
            default:
                ProgramExeptionArgs args = new ProgramExeptionArgs { ErrorMessage = "Such a card does not exist", LocationOfError = nameof(DetermineTypeOfCard), ErrorTime = DateTime.Now };
                throw new ProgramExeption(args.ErrorMessage, args);

        }

    }



}

class ProgramExeption : Exception
{
    public ProgramExeptionArgs exceptionArgs;
    public ProgramExeption(string message, ProgramExeptionArgs args) : base(message)
    {
        this.exceptionArgs = args;
    }

}

class ProgramExeptionArgs
{
    private string errorMessage;
    private string locationOfError;
    private DateTime errorTime;

    public string ErrorMessage
    {
        get
        {
            return this.errorMessage;
        }
        set
        {
            this.errorMessage = value;
        }
    }

    public string LocationOfError
    {
        get
        {
            return this.locationOfError;
        }
        set
        {
            this.locationOfError = value;
        }
    }

    public DateTime ErrorTime
    {
        get
        {
            return this.errorTime;
        }
        set
        {
            this.errorTime = value;
        }
    }

}



static class JuniorCardExtension
{
    public static void RegisterForBankTour(this JuniorCard juniorCard)
    {
        Console.WriteLine("[{0}] --- you have registered for a tour of the bank. We look forward to seeing you!", juniorCard.Name);
    }
}