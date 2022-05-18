using static System.Console;

namespace course_work
{

    abstract class Visitor
    {
        abstract public void VisitEasyDanceMC(EasyDanceMC mc);
        abstract public void VisitNormalDanceMC(NormalDanceMC mc);
        abstract public void VisitProfessionalMC(ProfessionalMC mc);
    }

    class StarVisitor : Visitor
    {
        override public void VisitEasyDanceMC(EasyDanceMC mc)
        {
            WriteLine("\nThe star guest raised the score for passing the easy master class by 3 units.");
            WriteLine($"\nEasy master class: | Score: {mc.Score} | Money : {mc.Money} |" );
            
        }

        public override void VisitNormalDanceMC(NormalDanceMC mc)
        {
            WriteLine("\nThe star guest raised the score for passing the normal master class by 4 units.");
            WriteLine($"\nNormal master class: | Score: {mc.Score} | Money : {mc.Money} |" );
        }

        public override void VisitProfessionalMC(ProfessionalMC mc)
        {
            WriteLine("\nThe star guest raised the score for passing the professional master class by 5 units.");
            WriteLine($"\nProfessional master class: | Score: {mc.Score} | Money : {mc.Money} |" );
        }

    }


    interface IMasterClass
    {
        void Accept(Visitor visitor);
    }

}