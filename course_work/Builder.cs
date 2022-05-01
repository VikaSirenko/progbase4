using static System.Console;
using System.Collections.Generic;


namespace course_work
{
    class Shop
    {
        public void BuyDanceRoom(DanceRoomBuilder danceRoomBuilder, DanceTeacher danceTeacher)
        {
            bool checkedPrice = danceRoomBuilder.CheckPrice(danceTeacher);
            if (checkedPrice)
            {
                danceRoomBuilder.SetAreaOfDanceRoom();
                danceRoomBuilder.AddMirrors();
                danceRoomBuilder.AddSpeakers();
                danceRoomBuilder.AddAdditionalEquipment();
                danceTeacher.SpendMoney(danceRoomBuilder.DanceRoom.Price);
            }
            else
            {
                WriteLine("Not enough money to buy this dance room. This room costs:" + danceRoomBuilder.DanceRoom.Price);
            }
        }
    }

    class DanceRoom
    {
        private string type;
        private int score;
        private double price;
        public double Price
        {
            get { return price; }
        }

        public int Score 
        {
            get {return score;}
        }

        private Dictionary<string, string> parts = new Dictionary<string, string>();
        public DanceRoom(string type, int score, double price)
        {
            this.type = type;
            this.score = score;
            this.price = price;
        }

        public string this[string key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void ShowDanceRoom()
        {
            WriteLine("\n----------------------------------");
            WriteLine("Dance room: '{0}'  |  Price: '{1}'  | Score: '{2}' ", this.type, this.price, this.score);
            WriteLine("Components: '{0}', '{1}', '{2}', '{3}', '{4}' ", parts["roomArea"], parts["numOfMirrors"], parts["speakers"], parts["additionalEquipment"]);
        }
    }


    abstract class DanceRoomBuilder
    {
        protected DanceRoom danceRoom;
        public DanceRoom DanceRoom
        {
            get { return danceRoom; }
        }

        public bool CheckPrice(DanceTeacher danceTeacher)
        {
            if (danceTeacher.Money >= this.danceRoom.Price)
            {
                return true;
            }
            return false;
        }

        public abstract void SetAreaOfDanceRoom();
        public abstract void AddMirrors();
        public abstract void AddSpeakers();
        public abstract void AddAdditionalEquipment();

    }

    class SimpleDanceRoom : DanceRoomBuilder
    {

        public SimpleDanceRoom()
        {
            danceRoom = new DanceRoom("Simpe Dance room", 50, 500);
        }

        public override void AddAdditionalEquipment()
        {
            danceRoom["additionalEquipment"] = "None";
        }

        public override void AddMirrors()
        {
            danceRoom["numOfMirrors"] = "5";
        }

        public override void AddSpeakers()
        {
            danceRoom["speakers"] = "two simple speakers";
        }

        public override void SetAreaOfDanceRoom()
        {
            danceRoom["roomArea"] = "50 square meters";
        }
    }

    class GoodDanceRoom : DanceRoomBuilder
    {
        public GoodDanceRoom()
        {
            danceRoom = new DanceRoom("Good dance room", 100, 1500);
        }
        public override void AddAdditionalEquipment()
        {
            danceRoom["additionalEquipment"] = "sports equipment for charging";
        }

        public override void AddMirrors()
        {
            danceRoom["numOfMirrors"] = "10";
        }

        public override void AddSpeakers()
        {
            danceRoom["speakers"] = "four good speakers";
        }

        public override void SetAreaOfDanceRoom()
        {
            danceRoom["roomArea"] = "100 square meters";
        }
    }


    class ProDanceRoom : DanceRoomBuilder
    {
        public ProDanceRoom()
        {
            danceRoom = new DanceRoom("Professional dance room", 150, 3000);
        }
        public override void AddAdditionalEquipment()
        {
            danceRoom["additionalEquipment"] = "a veriety of professional sports equipment";
        }

        public override void AddMirrors()
        {
            danceRoom["numOfMirrors"] = "15";
        }

        public override void AddSpeakers()
        {
            danceRoom["speakers"] = "eight professional speakers";
        }

        public override void SetAreaOfDanceRoom()
        {
            danceRoom["roomArea"] = "150 square meters";
        }
    }
}