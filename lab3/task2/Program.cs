using System;
using System.Collections.Generic;
using static System.Console;
using System.Collections;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {

            Hashtable flowers = new Hashtable();
            flowers.Add("Chlorophytum", "Normal flower");
            flowers.Add("Succulent", "Non-Moisture-Loving Flower");
            flowers.Add("Aglaonema", "Normal flower");
            flowers.Add("Bamboo", "Moisture-Loving Flower");
            flowers.Add("Dracaena", "Normal flower");
            flowers.Add("Fern", "Moisture-Loving Flower");
            flowers.Add("Cactus", "Non-Moisture-Loving Flower");
            flowers.Add("Aloe", "Moisture-Loving Flower");
            flowers.Add("Hoya", "Non-Moisture-Loving Flower");
            flowers.Add("Orchid", "Moisture-Loving Flower");


            Flowerbed flowerbed = new Flowerbed();
            foreach (string f_name in flowers.Keys)
            {
                String flowerName = f_name;
                Flower f1 = flowerbed.GetFlowerType((String)flowers[flowerName]);
                f1.WaterFlower(flowerName);

            }

        }
    }

    //FlyWeight Factory
    class Flowerbed
    {
        private Dictionary<string, Flower> flowers = new Dictionary<string, Flower>();

        public Flowerbed()
        {
            flowers.Add("Normal flower", new NormalFlower());
            flowers.Add("Moisture-Loving Flower", new MoistureLovingFlower());
            flowers.Add("Non-Moisture-Loving Flower", new NonMoistureLovingFlower());

        }

        public Flower GetFlowerType(string key)
        {
            return (Flower)flowers[key];
        }

    }


    //FlyWeight

    abstract class Flower
    {
        protected int normal_amount_of_water = 1000;
        public abstract void WaterFlower(string flowerName);
    }


    //Concrete FlyWeight
    class NormalFlower : Flower
    {
        public override void WaterFlower(string flowerName)
        {
            WriteLine($"The normal flower:[{flowerName}] was watered with this amount of water: [{this.normal_amount_of_water}]");
        }

    }

    class MoistureLovingFlower : Flower
    {
        public MoistureLovingFlower()
        {
            this.normal_amount_of_water = normal_amount_of_water + (30 * this.normal_amount_of_water / 100);
        }
        public override void WaterFlower(string flowerName)
        {
            WriteLine($"The moisture-loving flower:[{flowerName}] was watered with this amount of water: [{this.normal_amount_of_water}]");
        }
    }

    class NonMoistureLovingFlower : Flower
    {

        public NonMoistureLovingFlower()
        {
            this.normal_amount_of_water = normal_amount_of_water - (50 * this.normal_amount_of_water / 100);
        }

        public override void WaterFlower(string flowerName)
        {
            WriteLine($"The non-moisture-loving flower:[{flowerName}] was watered with this amount of water: [{this.normal_amount_of_water}]");
        }

    }


}
