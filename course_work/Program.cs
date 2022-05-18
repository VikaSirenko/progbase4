using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace course_work
{
    class Program
    {
        static void Main(string[] args)
        {

            PlayGame.StartPlay();

        }
    }


    static class PlayGame
    {
        static private DanceTeacher danceTeacher;
        static private bool isStarVisitor;
        static private Command command;
        static private Invoker invoker = new Invoker();

        static private bool first_pupil;
        static private bool second_pupil;
        static private bool third_pupil;  // random -> if true add new pupil, else countinue 

        public static void StartPlay()
        {
            WriteLine("\nWelcome to the dance studio!!!");
            CreateCharacter();
            WriteLine("\nLet`s play!!!\n");
            bool play = true;
            while (play)
            {
                try
                {
                    CheckDanceTeacherInformation();
                    play=InteractWithGui();

                }
                catch (Exception ex)
                {
                    WriteLine("\nERROR: " + ex.Message);
                }

            }

        }

        private static bool GetRandomValue()
        {
            Random random = new Random();
            int randomNum = random.Next(0, 2);
            if (randomNum == 0)
            {
                return false;
            }
            return true;
        }

        private static void CreateCharacter()
        {
            WriteLine("\nLet's create your character:");
            bool inputData = true;
            while (inputData)
            {
                WriteLine("\nEnter name:");
                string name = ReadLine();
                WriteLine("\nEnter surname:");
                string surname = ReadLine();
                WriteLine("\nEnter age:");
                int age;
                bool is_age = int.TryParse(ReadLine(), out age);
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && is_age && age > 0)
                {
                    WriteLine("\nYou created a dance teacher!");
                    danceTeacher = new DanceTeacher(name, surname, age);
                    inputData = false;
                    command = new CreateDanceSdudioCommand();
                    ProccedCommand();
                }
                else
                {
                    WriteLine("\nInformation about the character is entered incorrectly. Try one more time.");
                }
            }
            WriteLine("-----------------------------------------------------------------------");
        }

        static private void CheckDanceTeacherInformation()
        {

            if (danceTeacher.Score >= 1000)
            {
                command = new ChangeLevelCommand();
                ProccedCommand();
                command = new GetCharacterInfo();
                ProccedCommand();
                first_pupil = false;
                second_pupil = false;
                third_pupil = false;
            }

            if (danceTeacher.Score >= 500 && isStarVisitor == true)
            {
                command = new ReceiveStarVisitorCommand();
                ProccedCommand();
                isStarVisitor = false;
            }

            if (danceTeacher.Score >= 100 && first_pupil == false && GetRandomValue() == true)
            {
                command = new AddPupilCommand();
                ProccedCommand();
                first_pupil = true;
            }

            if (danceTeacher.Score >= 400 && second_pupil == false && GetRandomValue() == true)
            {
                command = new AddPupilCommand();
                ProccedCommand();
                second_pupil = true;
            }
            if (danceTeacher.Score >= 800 && third_pupil == false && GetRandomValue() == true)
            {
                command = new AddPupilCommand();
                ProccedCommand();
                third_pupil = true;
            }


            // if (GetRandomValue() == true)
            // {
            //     command = new AddPupilCommand();
            //     command.DanceTeacher = danceTeacher;
            //     invoker.StoreCommand(command);
            //     invoker.DoCommand();
            // }
        }

        private static void ProccedCommand()
        {
            command.DanceTeacher = danceTeacher;
            invoker.StoreCommand(command);
            //invoker.DoCommand();
        }

        static private bool InteractWithGui()
        {
            WriteLine("\n------------------------------------------------------------------");
            WriteLine("| (M)C | (B)uy | (S)how studio | (G)et character info | (E)xit |");
            WriteLine("------------------------------------------------------------------\n");
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.M)
            {
                command = new MCcommand();

            }
            else if (key == ConsoleKey.B)
            {
                command = new BuyCommand();

            }
            else if (key == ConsoleKey.S)
            {
                command = new ShowStudioCommand();
            }
            else if (key == ConsoleKey.G)
            {
                command = new GetCharacterInfo();
            }
            else if (key == ConsoleKey.E)
            {
                return false;
            }
            else
            {
                WriteLine("\nThere is no such command to execute. Try again.");
                return true;
            }
            ProccedCommand();
            return true;

        }
    }


    abstract class Human
    {
        protected string name;
        protected string surname;
        protected int age;
        protected int score;

        public string Name
        {
            get { return name; }
        }

        public string Surname
        {
            get { return surname; }
        }

        public int Score
        {
            get { return score; }
        }

        // abstract public void GetInfo();

        public void ChangeScore(int scoreParam)
        {
            this.score += scoreParam;
        }
    }


    class Pupil : Human
    {
        private string way_of_dance;
        private string namePath = "./name";
        private string surnamePath = "./surname";

        private string[] wayOfDance = new string[] { "I want to dance folk", "I want to dance hip-hop", "I want to dance ballet" };

        public Pupil()
        {
            this.GetRandomPupil();
        }

        private Pupil GetRandomPupil()
        {
            this.name = FindPupilData(this.namePath);
            this.surname = FindPupilData(this.surnamePath);
            Random random = new Random();
            this.way_of_dance = this.wayOfDance[random.Next(0, 3)];
            this.age = random.Next(6, 22);
            return this;
        }

        public override string ToString()
        {
            return $"\n[Name: {this.name} | Surname: {this.surname} | Way of dance: {this.way_of_dance} | Age: {this.age} | Score: {this.score}]";
        }

        // public override void GetInfo()
        // {
        //     WriteLine($"\nName: {this.name} | Surname: {this.surname} | Way of dance: {this.way_of_dance} | Age: {this.age} | Score: {this.score}");
        // }

        public string CheckGroup(ConsoleKey key)
        {
            if (key == ConsoleKey.F)
            {
                if (this.way_of_dance == "I want to dance folk")
                {
                    return "folk";
                }
                else
                {
                    return "wrong";
                }
            }
            else if (key == ConsoleKey.H)
            {
                if (this.way_of_dance == "I want to dance hip-hop")
                {
                    return "hip-hop";
                }
                else
                {
                    return "wrong";
                }

            }
            else if (key == ConsoleKey.B)
            {
                if (this.way_of_dance == "I want to dance ballet")
                {
                    return "ballet";
                }
                else
                {
                    return "wrong";
                }
            }
            else
            {
                WriteLine("\nYou pressed the wrong button");
                return "wrong";
            }
        }

        public string CheckAge(ConsoleKey key)
        {
            if (key == ConsoleKey.C)
            {
                if (this.age >= 6 && this.age <= 11)
                {
                    return "children";
                }
                else
                {
                    return "wrong";
                }
            }
            else if (key == ConsoleKey.J)
            {
                if (this.age >= 12 && this.age <= 16)
                {
                    return "junior";
                }
                else
                {
                    return "wrong";
                }

            }
            else if (key == ConsoleKey.A)
            {
                if (this.age >= 17 && this.age <= 21)
                {
                    return "adult";
                }
                else
                {
                    return "wrong";
                }
            }
            else
            {
                WriteLine("\nYou pressed the wrong button");
                return "wrong";
            }
        }


        private static string FindPupilData(string path)
        {
            Random random = new Random();
            int count = CountLinesInPath(path);
            //randomly select the file line
            int pupil_data_line = random.Next(1, count + 1);

            //find the generated line in the given file
            StreamReader finder = new StreamReader(path);
            string search_line = "";
            while (pupil_data_line > 0)
            {
                search_line = finder.ReadLine();
                pupil_data_line--;
                for (int i = 0; i < search_line.Length; i++)
                {
                    char item = search_line[i];
                    if (item == '"')
                    {
                        throw new Exception("Error: the text contains quotation marks");

                    }
                    else if (item == ',')
                    {
                        throw new Exception("Error:the text contains a comma");
                    }

                }
            }

            finder.Close();
            return search_line;
        }

        private static int CountLinesInPath(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = "";

            int count = 0;

            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                else
                {
                    count++;
                }
            }

            reader.Close();
            return count;
        }


    }

    class DanceTeacher : Human  //Receiver
    {
        private int level;
        private double money;
        public double Money
        {
            get { return money; }
        }

        private DanceStudioComposite danceStudio;
        private Group folkChildrenGroup;
        private Group folkJuniorGroup;
        private Group folkAdultGroup;
        private Group hipHopChildrenGroup;
        private Group hipHopJuniorGroup;
        private Group hipHopAdultGroup;
        private Group balletChildrenGroup;
        private Group balletJuniorGroup;
        private Group balletAdultGroup;

        private DanceRoomBuilder danceRoomBuilder;
        private Shop shop;

        private DanceMasterClass danceMasterClass;
        private EasyDanceMC easyDanceMC;
        private NormalDanceMC normalDanceMC;
        private ProfessionalMC professionalMC;
        private Visitor visitor;


        public DanceTeacher(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.score = 1000;
        }

        public void CreateDanceStudio()
        {
            string nameOfDanceStudio = "";
            WriteLine("\nGive a name to your Dance Studio");
            nameOfDanceStudio = ReadLine();
            this.danceStudio = new DanceStudioComposite(nameOfDanceStudio);

            DanceStudioComposite folkDirection = new DanceStudioComposite("Folk direction");
            DanceStudioComposite hipHopDirection = new DanceStudioComposite("Hip-hop direction");
            DanceStudioComposite balletDirection = new DanceStudioComposite("Ballet direction");
            danceStudio.AddDanceStudioComponent(folkDirection);
            danceStudio.AddDanceStudioComponent(hipHopDirection);
            danceStudio.AddDanceStudioComponent(balletDirection);

            this.folkChildrenGroup = new Group("Folk children`s group");
            this.folkJuniorGroup = new Group("Folk junior`s group");
            this.folkAdultGroup = new Group("Folk adult`s group");
            folkDirection.AddDanceStudioComponent(folkChildrenGroup);
            folkDirection.AddDanceStudioComponent(folkJuniorGroup);
            folkDirection.AddDanceStudioComponent(folkAdultGroup);

            this.hipHopChildrenGroup = new Group("Hip-hop children`s group");
            this.hipHopJuniorGroup = new Group("Hip-hop junior`s group");
            this.hipHopAdultGroup = new Group("Hip-hop adult`s group");
            hipHopDirection.AddDanceStudioComponent(hipHopChildrenGroup);
            hipHopDirection.AddDanceStudioComponent(hipHopJuniorGroup);
            hipHopDirection.AddDanceStudioComponent(hipHopAdultGroup);

            this.balletChildrenGroup = new Group("Ballet children`s group");
            this.balletJuniorGroup = new Group("Ballet junior`s group");
            this.balletAdultGroup = new Group("Ballet adult`s group");
            balletDirection.AddDanceStudioComponent(balletChildrenGroup);
            balletDirection.AddDanceStudioComponent(balletJuniorGroup);
            balletDirection.AddDanceStudioComponent(balletAdultGroup);

            this.shop = new Shop();
            this.easyDanceMC = new EasyDanceMC();
            this.normalDanceMC = new NormalDanceMC();
            this.professionalMC = new ProfessionalMC();
            visitor = new StarVisitor();
        }

        public void SpendMoney(double price)
        {
            this.money = this.money - price;
        }

        public void PutMoney(double moneyParam)
        {
            this.money += moneyParam;
        }

        public void ChangeLevel()
        {
            this.level += 1;
            this.score = this.score - 1000;
            this.AddNewPupil();
        }

        private void UpdatePupilsScore(int scoreParam)
        {
            List<Pupil> pupils = danceStudio.GetListOfPupils();
            foreach (Pupil pupil in pupils)
            {
                pupil.ChangeScore(scoreParam);  //????????
            }
        }

        // public override void GetInfo()
        // {
        //     WriteLine($"\nName: {this.name} | Surname: {this.surname} | Age: {this.age} | Level: {this.level} | Score: {this.score}");
        // }

        public override string ToString()
        {
            return $"\n[Name: {this.name} | Surname: {this.surname} | Age: {this.age} | Level: {this.level} | Score: {this.score} | Money: {this.Money}]";
        }



        public void DoMC()
        {
            WriteLine("\nLet's hold a master class");
            WriteLine("\nSelect a pupil for the master class:");
            WriteLine("\nEnter a name:");
            string pupil_name = ReadLine();
            WriteLine("\nEnter a surname:");
            string pupil_surname = ReadLine();
            List<Pupil> pupils = danceStudio.GetListOfPupils();
            Pupil pupil = new Pupil();
            foreach (Pupil p in pupils)
            {
                if (p.Name == pupil_surname && p.Surname == pupil_surname)
                {
                    pupil = p;
                }
            }
            WriteLine("\nChoose which master class you want to send the student to\nE- easy dance master class\nM-middle dance master class\nP-professional dance master class\n");
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.E)
            {
                danceMasterClass = new DanceMasterClass(easyDanceMC, pupil, this);
            }
            else if (key == ConsoleKey.N)
            {
                danceMasterClass = new DanceMasterClass(normalDanceMC, pupil, this);
            }
            else if (key == ConsoleKey.P)
            {
                danceMasterClass = new DanceMasterClass(professionalMC, pupil, this);
            }
            else
            {
                WriteLine("\nYou pressed the wrong button");
            }
        }

        public void BuyDanceClass()
        {
            WriteLine("\nLet's buy a dance studio");
            WriteLine("\nWhat dance room do you want to buy?\nS- simple dance room\nG- good dance room\nP- professional dance room\n");
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.S)
            {
                danceRoomBuilder = new SimpleDanceRoom();
            }
            else if (key == ConsoleKey.G)
            {
                danceRoomBuilder = new GoodDanceRoom();
            }
            else if (key == ConsoleKey.P)
            {
                danceRoomBuilder = new ProDanceRoom();
            }
            else
            {
                WriteLine("\nYou pressed the wrong button");
                return; //check if method is end here 
            }

            shop.BuyDanceRoom(danceRoomBuilder, this);
            danceRoomBuilder.DanceRoom.ShowDanceRoom();
            this.UpdatePupilsScore(danceRoomBuilder.DanceRoom.Score);
        }

        public void ShowDanceStudio()
        {
            danceStudio.ShowPupilsInDanceStudioComponent(3);
        }

        public void AddNewPupil()
        {
            WriteLine("\nLet's add a new student to the group");
            Pupil addedPupil = new Pupil();
            WriteLine(addedPupil.ToString());
            WriteLine("\nEnter the direction of the dance that the pupil wants to do\nF- folk\nH- hip-hop\nB- ballet\n");
            string rightGroup = addedPupil.CheckGroup(ReadKey().Key);

            WriteLine("\nEnter a group case that suits the pupil\nC- children\nJ- junior\nA- adult\n");
            string ageGroup = addedPupil.CheckAge(ReadKey().Key);
            if (rightGroup == "folk")
            {
                switch (ageGroup)
                {
                    case "children":
                        folkChildrenGroup.AddPupil(addedPupil);
                        break;
                    case "junior":
                        folkJuniorGroup.AddPupil(addedPupil);
                        break;
                    case "adult":
                        folkAdultGroup.AddPupil(addedPupil);
                        break;
                    default:
                        WriteLine("\nYou have chosen the wrong age group for the pupil");
                        break;

                }
            }
            else if (rightGroup == "hip-hop")
            {
                switch (ageGroup)
                {
                    case "children":
                        hipHopChildrenGroup.AddPupil(addedPupil);
                        break;
                    case "junior":
                        hipHopJuniorGroup.AddPupil(addedPupil);
                        break;
                    case "adult":
                        hipHopAdultGroup.AddPupil(addedPupil);
                        break;
                    default:
                        WriteLine("\nYou have chosen the wrong age group for the pupil");
                        break;
                }
            }
            else if (rightGroup == "ballet")
            {
                switch (ageGroup)
                {
                    case "children":
                        balletChildrenGroup.AddPupil(addedPupil);
                        break;
                    case "junior":
                        balletJuniorGroup.AddPupil(addedPupil);
                        break;
                    case "adult":
                        balletAdultGroup.AddPupil(addedPupil);
                        break;
                    default:
                        WriteLine("\nYou have chosen the wrong age group for the pupil");
                        break;
                }
            }
            else
            {
                WriteLine("\nYou have chosen the wrong direction of dance for the pupil");
                return;
            }
            WriteLine("\nStudent added successfully");

        }

        public void RecieveStarVisitor()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 4);
            if (randomNum == 1)
            {
                easyDanceMC.Accept(visitor);
            }
            else if (randomNum == 2)
            {
                normalDanceMC.Accept(visitor);
            }
            else if (randomNum == 3)
            {
                professionalMC.Accept(visitor);
            }
        }
    }



}
