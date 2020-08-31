using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Filter();
            Ordering();
            Aggregate();
            Partitioning();
            Custom();
        }
        static void Filter()
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            IEnumerable<string> LFruits = from fruit in fruits
            where fruit[0] == 'L'
            select fruit;
            Console.WriteLine("L fruits:");
            foreach (string aFruit in LFruits)
            {
                Console.WriteLine(aFruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0).OrderBy(n => n);
            Console.WriteLine();
            Console.WriteLine("Multiples of 4 or 6: ");
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }
        }
        static void Ordering()
        {
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };
            List<string> descend = names.OrderByDescending(n => n).ToList();
            Console.WriteLine();
            Console.WriteLine("Names in descending order:");
            descend.ForEach(name => Console.WriteLine($"{name}"));

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            List<int> ascend = numbers.OrderBy(n => n).ToList();
            Console.WriteLine();
            Console.WriteLine("Numbers in ascending order:");
            ascend.ForEach(num => Console.WriteLine($"{num}"));
        }
        static void Aggregate()
        {
            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            Console.WriteLine();
            Console.WriteLine($"This list has {numbers.Count} numbers");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };
            double total = purchases.Sum();
            Console.WriteLine();
            Console.WriteLine($"{total.ToString("C")}");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };
            double expensive = prices.Max();
            Console.WriteLine();
            Console.WriteLine($"{expensive.ToString("C")}");
        }
        static void Partitioning()
        {
            List<int> wheresSquaredo = new List<int>()
            {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> imperfectSquares = wheresSquaredo.TakeWhile(num => Math.Sqrt(num) % 1 != 0).ToList();
            Console.WriteLine();
            imperfectSquares.ForEach(num => Console.WriteLine($"{num}"));
        }
        static void Custom()
        // Build a collection of customers who are millionaires
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer() { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer() { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer() { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer() { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer() { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer() { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer() { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer() { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer() { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };
            List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000).ToList();
            /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
            List<Bank> bankMillionaire = (from millionaire in millionaires group millionaire by millionaire.Bank into bankCustomer select new Bank
            {
                Name = bankCustomer.Key,
                    Count = bankCustomer.Count()
            }).ToList();

            Console.WriteLine();
            bankMillionaire.ForEach(bank => Console.WriteLine($"{bank.Name} {bank.Count}"));
        }
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
        public class Bank
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}