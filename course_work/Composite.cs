using System;
using static System.Console;
using System.Collections.Generic;


namespace course_work
{
    abstract class DanceStudioComponent
    {
        protected string type;
        protected List<Pupil> pupils;

        public DanceStudioComponent(string type)
        {
            this.type = type;
            this.pupils = new List<Pupil>();
        }

        public abstract void AddDanceStudioComponent(DanceStudioComponent danceComponent);
        public abstract void ShowPupilsInDanceStudioComponent(int depth);
        public abstract List<Pupil> GetListOfPupils();

        protected void DisplayListOfPupils(int depth)
        {
            foreach (Pupil pupil in pupils)
            {
                WriteLine((new String(' ', depth) + pupil.ToString()));
            }

        }
    }

    class DanceStudioComposite : DanceStudioComponent
    {
        private List<DanceStudioComponent> danceStudioComponents = new List<DanceStudioComponent>();
        public DanceStudioComposite(string type) : base(type)
        { }

        public override void AddDanceStudioComponent(DanceStudioComponent component)
        {
            danceStudioComponents.Add(component);
        }
        public override void ShowPupilsInDanceStudioComponent(int depth)
        {
            WriteLine(new String('-', depth) + type + " ");
            this.DisplayListOfPupils(depth);

            foreach (DanceStudioComponent component in danceStudioComponents)
            {
                component.ShowPupilsInDanceStudioComponent(depth + 2);
            }
        }

        public override List<Pupil> GetListOfPupils()
        {
            foreach (DanceStudioComponent component in danceStudioComponents)
            {
                List<Pupil> returnedPupils = component.GetListOfPupils();
                foreach (Pupil pupil in returnedPupils)
                {
                    pupils.Add(pupil);
                }

            }
            return pupils;

        }
    }

    class Group : DanceStudioComponent
    {
        public Group(string type) : base(type)
        { }

        public void AddPupil(Pupil pupil)
        {
            this.pupils.Add(pupil);
        }
        public override void AddDanceStudioComponent(DanceStudioComponent component)
        {
            WriteLine("Imposible Operation");                                          
        }

        public override void ShowPupilsInDanceStudioComponent(int depth)
        {
            WriteLine(new String('-', depth) + type + " ");
            DisplayListOfPupils(depth);
        }

        public override List<Pupil> GetListOfPupils()
        {
            return pupils;
        }
    }
}