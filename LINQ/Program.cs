using LINQ.classes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace LINQ
{
    public class Program
    {
        // File path
        private static readonly string _filePath = "../../../json1.json";

        static void Main(string[] args)
        {

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        // Main Menu
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
                RemoveDuplicates();
                return true;

            }
            else if (result == "4")
            {
                ChainAllMethods();
                    return true;
            }
            else if (result == "5")
            {
                return false;
            }

            return true;

        }

        // Return all neighborhoods
        /// <summary>
        /// Will query to the Json file and return all neighborhoods regardles of duplicates or whitespaces. Using a LINQ to query and distinct, 
        /// which is a built in method to find a specific element in a sequence
        /// </summary>
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

        // Return all neighborhoods without whitespace
        /// <summary>
        /// Finding and searching for whitespace inside of neighborhoods, using a lamba expression to find.
        /// </summary>
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
       
        // Remove all duplicate neighborhoods
        /// <summary>
        /// Taking all of the neighborhoods and finding if any of the same type exists
        /// </summary>
        public static void RemoveDuplicates()
        {
            string data = "";
            using (StreamReader r = new StreamReader(_filePath))
            {
                data = r.ReadToEnd();
                //List<RootObject> List = JsonConvert.DeserializeObject<List<RootObject>>(_filePath);

            }

            RootObject items = JsonConvert.DeserializeObject<RootObject>(data);
            // Groupby will go and group things from items>features and find properties>neighborhoods
            //select the first in every grouped sequence of duplicates, form to a list and use distinct to return selected elements from that sequence
            var distinctList = items.features.GroupBy(x => x.properties.neighborhood
            )
                         .Select(g => g.First())
                         .ToList().Distinct();
           
            foreach (var item in distinctList)
            {
                
                    Console.WriteLine($"{item.properties.neighborhood}");
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Using all previous methods to work as one
        /// </summary>
        public static void ChainAllMethods()
        {
            string data = "";
            using (StreamReader r = new StreamReader(_filePath))
            {
                data = r.ReadToEnd();
                //List<RootObject> List = JsonConvert.DeserializeObject<List<RootObject>>(_filePath);

            }

            RootObject items = JsonConvert.DeserializeObject<RootObject>(data);

            var distinctList = items.features.Where(s => !string.IsNullOrWhiteSpace(s.properties.neighborhood)
            )
                         .GroupBy(x => x.properties.neighborhood)
                         .Select(g => g.First())
                         .ToList().Distinct();

            foreach (var item in distinctList)
            {

                Console.WriteLine($"{item.properties.neighborhood}");
            }

            Console.ReadLine();
        }
    }
}
    
