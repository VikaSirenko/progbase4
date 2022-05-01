namespace course_work
{
    abstract class Command
    {
        abstract public void DoCommand();
        protected DanceTeacher danceTeacher;
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
        public override void DoCommand( )
        {
            danceTeacher.ShowDanceStudio();
        }
    }

    class AddPupilCommand: Command
    {
        public override void DoCommand()
        {
            danceTeacher.AddNewPupil();
        }
    }


    class Invoker
    {
        private Command command;
        public void StoreCommand(Command command)
        {
            this.command = command;
        }

        public void DoCommand()
        {
            command.DoCommand();
        }
    }

}