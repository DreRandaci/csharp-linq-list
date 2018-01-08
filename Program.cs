using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{

    // Define a bank
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    // Define a customer
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            // RESTRICTION/FILTERING OPERATIONS 

            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
                                          where fruit.StartsWith('L')
                                          orderby fruit ascending
                                          select fruit;

            LFruits.ToList().ForEach(f => Console.WriteLine(f));

            Console.WriteLine();

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0).ToList();

            foreach (int num in fourSixMultiples)
            {

                Console.WriteLine(num);
            }

            Console.WriteLine();



            // ORDERING OPERATIONS

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(i => i).ToList();
            foreach (string name in descend)
            {

                Console.WriteLine(name);
            }

            Console.WriteLine();


            // Build a collection of these numbers sorted in ascending order
            List<int> moreNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> ascendNums = moreNumbers.OrderBy(n => n).ToList();

            foreach (int num in ascendNums)
            {

                Console.WriteLine(num);
            }

            Console.WriteLine();



            // AGGREGATE OPERATIONS

            // Output how many numbers are in this list
            List<int> howManyNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            int count = howManyNumbers.Count();
            Console.WriteLine("Output how many numbers are in this list: " + count);

            Console.WriteLine();

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double sum = purchases.Sum();
            Console.WriteLine("How much money have we made? $" + sum);

            Console.WriteLine();

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double max = prices.Max();
            Console.WriteLine("What is our most expensive product? $" + max);

            Console.WriteLine();



            // PARTITIONING OPERATIONS

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */

            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            int firstNum = wheresSquaredo.Find(n => Math.Sqrt(n) % 1 == 0);
            Console.WriteLine("first squared number: " + firstNum);
            // foreach (int num in wheresSquaredo)
            // {
            //     double result = Math.Sqrt(num);
            //     bool isSquare = result % 1 == 0;
            // }

            Console.WriteLine();


            // CUSTOM TYPES

            List<Customer> customers = new List<Customer>()
            {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */

            List<Customer> millionaires = customers.Where(c => c.Balance >= 1000000).ToList();

            var groupedMillionaires = from customer in millionaires
                                      group customer by customer.Bank into millionaireGroup
                                      select new
                                      {
                                          Bank = millionaireGroup.Key,
                                          NumberOfMillionaires = millionaireGroup.Count()
                                      };
            Console.WriteLine("display how many millionaires per bank:");
            foreach (var item in groupedMillionaires)
            {
                Console.WriteLine(item.Bank + " " + item.NumberOfMillionaires);
            }

            Console.WriteLine();


            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            var q =
                from b in banks
                join c in customers on b.Symbol equals c.Bank
                select new { Bank = b, c.Balance };

        }
    }
}
