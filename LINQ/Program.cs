using LINQ.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQ
{
    public class Program
    {
        // File path
        private static readonly string _filePath = @"C:\Code\Lab08-LINQ\Lab08-LINQ\LINQ\json1.json";

        static void Main(string[] args)
        {

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome To New York City");
            Console.WriteLine("Please select from the menu how you wish to start:");
            Console.WriteLine("1) View all neighborhoods");
            Console.WriteLine("2) View all neighborhoods with no whitespace");
            Console.WriteLine("3) Remove the Duplicates");
            Console.WriteLine("4) Rewrite the queries from above, and consolidate all into one single query.");
            Console.WriteLine("5) Exit");

            string result = Console.ReadLine();


            if (result == "1")
            {
                ReturnAll();
                return true;
            }
            else if (result == "2")
            {
                ReturnAllNoNullValue();
                return true;
            }
            else if (result == "3")
            {



            }
            else if (result == "4")
            {

            }
            else if (result == "5")
            {
                return false;
            }

            return true;

        }

        public static void ReturnAll()
        {
            string data = "";
            using (StreamReader r = new StreamReader(_filePath))
            {
                data = r.ReadToEnd();
            }

            RootObject items = JsonConvert.DeserializeObject<RootObject>(data);
            Console.WriteLine($"{items.features[1].properties.neighborhood}");


            var results = from hood in items.features
                          select hood.properties.neighborhood;

            foreach (var item in results)
            {
                Console.WriteLine($"{item}");
            }
            Console.ReadLine();
        }

        public static void ReturnAllNoNullValue()
        {
            string data = "";
            using (StreamReader r = new StreamReader(_filePath))
            {
                data = r.ReadToEnd();
                //List<RootObject> List = JsonConvert.DeserializeObject<List<RootObject>>(_filePath);
                         
            }

            RootObject items = JsonConvert.DeserializeObject<RootObject>(data);
            var Word = items.features.Where(s => !string.IsNullOrWhiteSpace(s.properties.neighborhood)).Distinct().ToList();
            foreach (var item in Word)
            {
                Console.WriteLine($"{item.properties.neighborhood}");
            }
            //RootObject items = JsonConvert.DeserializeObject<RootObject>(data);
            Console.ReadLine();
         

        }
    }
}
    
