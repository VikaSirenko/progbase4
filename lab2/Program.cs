using System;


class Program
{
    static void Main(string[] args)
    {



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
                Console.WriteLine("You do not fit the age of the Junior Card, choose another card");
            }
        }
    }

    public override void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > amount_of_money)
        {
            Console.WriteLine("It is impossible to withdraw money");
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
            Console.WriteLine("It is not possible to put money on the card, because the card has a limit of 20,000");

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
                Console.WriteLine("You do not fit the age of the Pension Card, choose another card");
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
            Console.WriteLine("It is not possible to put money on the card, because the card has a limit of 100,000");

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
            Console.WriteLine("It is impossible to withdraw money");
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
                Console.WriteLine("You do not fit the age of the Vip Card, choose another card");
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



    public override void WithdrawMoney(User user, WithdrawMoneyEventArgs args)
    {
        if (args.amount_of_money < 0 || args.amount_of_money > amount_of_money)
        {
            Console.WriteLine("It is impossible to withdraw money");
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

class Bank
{
    BankCard[] cards;
    public Bank(User user)
    {
        cards = new BankCard[3];
        cards[0] = new JuniorCard();
        cards[1] = new PensionCard();
        cards[2] = new VipCard();

        foreach (BankCard card in cards)
        {
            user.WithdrawMoneyEvent += new WithdrawMoneyHandle(card.WithdrawMoney);
        }

    }
}