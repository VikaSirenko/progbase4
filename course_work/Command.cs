namespace course_work
{
    abstract class Command
    {
        abstract public void DoCommand();
        protected  DanceTeacher danceTeacher;
        public DanceTeacher DanceTeacher
        {
            set
            {
                danceTeacher = value;
            }
        }
    }

    class MCcommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.DoMC();
        }
    }

    class BuyCommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.BuyDanceClass();
        }
    }


    class ShowStudioCommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.ShowDanceStudio();
        }
    }

    class AddPupilCommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.AddNewPupil();
        }
    }

    class ReceiveStarVisitorCommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.RecieveStarVisitor();
        }
    }

    class  GetCharacterInfo : Command
    {
        public override void DoCommand()
        {
            System.Console.WriteLine(danceTeacher.ToString());
        } 
    }

    class CreateDanceSdudioCommand :Command
    {
        public override void DoCommand()
        {
            danceTeacher.CreateDanceStudio();
        }
    }

    class ChangeLevelCommand : Command
    {
        public override void DoCommand()
        {
            danceTeacher.ChangeLevel();
        }
    }


    class Invoker
    {
        private Command command;
        public void StoreCommand(Command command)
        {
            command.DoCommand();
        }
    }

}