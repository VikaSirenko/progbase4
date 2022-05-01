using System.Threading;

namespace course_work
{
    class DanceMasterClass
    {
        private DanceMasterClassStrategy danceMasterClassStrategy;
        private Pupil pupil;
        private DanceTeacher danceTeacher;
        public DanceMasterClass(DanceMasterClassStrategy danceMasterClassStrategy, Pupil pupil, DanceTeacher danceTeacher)
        {
            this.danceMasterClassStrategy = danceMasterClassStrategy;
            this.danceTeacher = danceTeacher;
            this.pupil = pupil;
        }

        public void DoMasterClassLesson()
        {
            danceMasterClassStrategy.DoMasterClassDancing(pupil, danceTeacher);
        }
    }


    abstract class DanceMasterClassStrategy
    {
        abstract public void DoMasterClassDancing(Pupil pupil, DanceTeacher danceTeacher);
    }

    class EasyDanceMC : DanceMasterClassStrategy
    {
        private int scoreParam = 10;
        private double moneyParam = 50;
        public override void DoMasterClassDancing(Pupil pupil, DanceTeacher danceTeacher)
        {
            pupil.ChangeScore(scoreParam);
            danceTeacher.ChangeScore(scoreParam);
            danceTeacher.PutMoney(moneyParam);
            Thread.Sleep(1000);
        }
    }

    class NormalDanceMC : DanceMasterClassStrategy
    {
        private int scoreParam = 20;
        private double moneyParam = 75;
        public override void DoMasterClassDancing(Pupil pupil, DanceTeacher danceTeacher)
        {
            pupil.ChangeScore(scoreParam);
            danceTeacher.ChangeScore(scoreParam);
            danceTeacher.PutMoney(moneyParam);
            Thread.Sleep(5000);
        }
    }

    class ProfessionalMC : DanceMasterClassStrategy
    {
        private int scoreParam = 30;
        private double moneyParam = 100;
        public override void DoMasterClassDancing(Pupil pupil, DanceTeacher danceTeacher)
        {
            pupil.ChangeScore(scoreParam);
            danceTeacher.ChangeScore(scoreParam);
            danceTeacher.PutMoney(moneyParam);
            Thread.Sleep(10000);
        }
    }
}