using System;
using static System.Console;
using System.Collections.Generic;


namespace task2_changed_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> flowers = new Dictionary<string, string>();
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


            int normal_amount_of_water = 1000;
            DeviceForNormalFlower deviceNormalF = new DeviceForNormalFlower();
            DeviceForMoistureLovingFlower deviceMoistureLovingF = new DeviceForMoistureLovingFlower();
            DeviceForNonMoistureLovingFlower deviceNonMoistureLovingF = new DeviceForNonMoistureLovingFlower();
            WateringFacade wateringFacade = new WateringFacade(deviceNormalF, deviceMoistureLovingF, deviceNonMoistureLovingF);
            foreach (KeyValuePair<string, string> keyValue in flowers)
            {
                string flowerName = keyValue.Key;
                string flowerType = keyValue.Value;
                wateringFacade.WaterFlower(flowerName, flowerType, normal_amount_of_water);
            }

        }
    }


    class DeviceForNormalFlower
    {
        public void WaterFlower(string flowerName, int normal_amount_of_water)
        {
            WriteLine($"The normal flower:[{flowerName}] was watered with this amount of water: [{normal_amount_of_water}]");
        }

    }

    class DeviceForMoistureLovingFlower
    {
        public void WaterFlower(string flowerName, int normal_amount_of_water)
        {
            normal_amount_of_water = normal_amount_of_water + (30 * normal_amount_of_water / 100);
            WriteLine($"The moisture-loving flower:[{flowerName}] was watered with this amount of water: [{normal_amount_of_water}]");
        }
    }

    class DeviceForNonMoistureLovingFlower
    {
        public void WaterFlower(string flowerName, int normal_amount_of_water)
        {
            normal_amount_of_water = normal_amount_of_water - (50 * normal_amount_of_water / 100);
            WriteLine($"The non-moisture-loving flower:[{flowerName}] was watered with this amount of water: [{normal_amount_of_water}]");
        }

    }

    class WateringFacade
    {
        private DeviceForNormalFlower deviceNormalF;
        private DeviceForMoistureLovingFlower deviceMoistureLovingF;
        private DeviceForNonMoistureLovingFlower deviceNonMoistureLovingF;


        public WateringFacade(DeviceForNormalFlower deviceNormalF, DeviceForMoistureLovingFlower deviceMoistureLovingF, DeviceForNonMoistureLovingFlower deviceNonMoistureLovingF)
        {
            this.deviceNormalF = deviceNormalF;
            this.deviceMoistureLovingF = deviceMoistureLovingF;
            this.deviceNonMoistureLovingF = deviceNonMoistureLovingF;
        }

        public void WaterFlower(string flowerName, string flowerType, int normal_amount_of_water)
        {
            switch (flowerType)
            {
                case "Normal flower":
                    this.deviceNormalF.WaterFlower(flowerName, normal_amount_of_water);
                    break;
                case "Moisture-Loving Flower":
                    this.deviceMoistureLovingF.WaterFlower(flowerName, normal_amount_of_water);
                    break;
                case "Non-Moisture-Loving Flower":
                    this.deviceNonMoistureLovingF.WaterFlower(flowerName, normal_amount_of_water);
                    break;
                default:
                    WriteLine("There is no such type of flower");
                    break;
            }

        }
    }



}
