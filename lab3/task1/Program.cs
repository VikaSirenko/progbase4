using System;
using System.Collections.Generic;
using static System.Console;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite composite = new Composite("root");
            Composite building1 = new Composite("building#1");
            Composite building2 = new Composite("building#2");
            composite.AddResidentalComponent(building1);
            composite.AddResidentalComponent(building2);

            Composite entrance1 = new Composite("entrance#1");
            Composite entrance2 = new Composite("entrance#2");
            Composite entrance3 = new Composite("entrance#3");

            building1.AddResidentalComponent(entrance1);
            building1.AddResidentalComponent(entrance2);
            building2.AddResidentalComponent(entrance3);

            Flat flat1 = new Flat("flat#1");
            Flat flat2 = new Flat("flat#2");
            Flat flat3 = new Flat("flat#3");
            Flat flat4 = new Flat("flat#4");
            Flat flat5 = new Flat("flat#5");
            Flat flat6 = new Flat("flat#6");

            entrance1.AddResidentalComponent(flat1);
            entrance1.AddResidentalComponent(flat2);
            entrance1.AddResidentalComponent(flat3);
            entrance2.AddResidentalComponent(flat4);
            entrance3.AddResidentalComponent(flat5);
            entrance3.AddResidentalComponent(flat6);

            Pet pet1 = new Pet("Tom", 5, "cat");
            Pet pet2 = new Pet("Snow", 3, "dog");
            Pet pet3 = new Pet("Leo", 7, "cat");
            Pet pet4 = new Pet("Milk", 1, "cat");
            Pet pet5 = new Pet("Kitty", 4, "cat");
            Pet pet6 = new Pet("Mochi", 13, "cat");
            Pet pet7 = new Pet("Tan", 4, "dog");
            Pet pet8 = new Pet("Bam", 1, "dog");
            Pet pet9 = new Pet("Mickey", 8, "dog");
            Pet pet10 = new Pet("Molly", 5, "dog");

            flat1.AddPet(pet1);
            flat2.AddPet(pet7);
            flat2.AddPet(pet8);
            flat3.AddPet(pet2);
            flat4.AddPet(pet6);
            flat4.AddPet(pet10);
            flat5.AddPet(pet3);
            flat5.AddPet(pet4);
            flat5.AddPet(pet5);
            flat6.AddPet(pet9);

            composite.ShowPetsInResidentalComponent(2);
            ReadKey();
            Console.Clear();

            building2.ShowPetsInResidentalComponent(2);
            ReadKey();
            Console.Clear();

            entrance1.ShowPetsInResidentalComponent(2);
            ReadKey();
            Console.Clear();

            flat5.ShowPetsInResidentalComponent(2);
            ReadKey();
            Console.Clear();


            composite.ShowAverageAgeOfPets(2);
            ReadKey();
            Console.Clear();

            entrance3.ShowAverageAgeOfPets(2);
            

        }
    }

    class Pet
    {
        public string name;
        public int age;
        public string animal_species;
        public Pet()
        {
            this.name = default;
            this.age = default;
            this.animal_species = default;
        }

        public Pet(string name, int age, string animal_species)
        {
            this.name = name;
            this.age = age;
            switch (animal_species.Trim())
            {
                case "cat":
                    this.animal_species = "cat";
                    break;
                case "dog":
                    this.animal_species = "dog";
                    break;
                default:
                    throw new Exception("There is no such animal");
            }
        }

        public override string ToString()
        {
            return $"[Species: '{animal_species}' | Name:'{name}' | Age: '{age}' ]";
        }


    }


    abstract class ResidentalComponent
    {
        protected string type;
        protected List<Pet> pets;
        public ResidentalComponent(string type)
        {
            this.type = type;
            this.pets = new List<Pet>();
        }
        public abstract void AddResidentalComponent(ResidentalComponent component);
        public abstract void RemoveResidentalComponent(ResidentalComponent component);
        public abstract void ShowPetsInResidentalComponent(int depth);
        public abstract void ShowAverageAgeOfPets(int depth);
        public abstract List<Pet> GetListOfPets();

        protected void DisplayListOfPets(int depth)
        {
            foreach (Pet pet in pets)
            {
                WriteLine(new String(' ', depth) + pet.ToString());
            }
        }

        protected double GetAverageAgeOfPets()
        {
            int sum = 0;
            foreach (Pet pet in pets)
            {
                sum += pet.age;
            }
            try
            {
                double result = sum / pets.Count;
                return result;

            }
            catch (System.Exception)
            {
                throw new Exception("ERROR :something went wrong");
            }
        }

    }

    class Composite : ResidentalComponent
    {
        private List<ResidentalComponent> residentalComponents = new List<ResidentalComponent>();
        public Composite(string type) : base(type)
        { }

        public override void AddResidentalComponent(ResidentalComponent component)
        {
            residentalComponents.Add(component);
        }
        public override void RemoveResidentalComponent(ResidentalComponent component)
        {
            residentalComponents.Remove(component);
        }

        public override void ShowPetsInResidentalComponent(int depth)
        {
            WriteLine(new String('-', depth) + type + " ");
            this.DisplayListOfPets(depth);

            foreach (ResidentalComponent component in residentalComponents)
            {
                component.ShowPetsInResidentalComponent(depth + 2);
            }

        }

        public override void ShowAverageAgeOfPets(int depth)
        {
            GetListOfPets();
            string averageAge = GetAverageAgeOfPets().ToString();
            WriteLine(new String('-', depth) + type + " " + "| Everage age: " + $"'{averageAge}'");

            foreach (ResidentalComponent component in residentalComponents)
            {
                component.ShowAverageAgeOfPets(depth + 2);
            }
        }

        public override List<Pet> GetListOfPets()
        {
            foreach (ResidentalComponent component in residentalComponents)
            {
                List<Pet> returnedPets = component.GetListOfPets();
                foreach (Pet pet in returnedPets)
                {
                    pets.Add(pet);
                }

            }
            return pets;
        }
    }


    class Flat : ResidentalComponent
    {
        public Flat(string type) : base(type)
        { }

        public void AddPet(Pet pet)
        {
            this.pets.Add(pet);
        }
        public override void AddResidentalComponent(ResidentalComponent component)
        {
            WriteLine("Imposible Operation");
        }

        public override void RemoveResidentalComponent(ResidentalComponent component)
        {
            WriteLine("Imposible Operation");
        }

        public override void ShowAverageAgeOfPets(int depth)
        {
            string averageAge = GetAverageAgeOfPets().ToString();
            WriteLine(new String('-', depth) + type + " " + "| Everage age: " + $"'{averageAge}'");
        }

        public override void ShowPetsInResidentalComponent(int depth)
        {
            WriteLine(new String('-', depth) + type + " ");
            DisplayListOfPets(depth);
        }

        public override List<Pet> GetListOfPets()
        {
            return pets;
        }
    }
}
