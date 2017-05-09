using System;
using System.Linq;

namespace AITDNOne
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var correctedUserName = "";
            var sleepHours = 0.0;
            var multipleSleepHours = 0.0;
            var multipleUsers = false;
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter your name: ");
                var userName = Console.ReadLine();   
                if (userName != "")
                {
                    if (userName != null)
                        correctedUserName = userName.First().ToString().ToUpper() + userName.Substring(1);
                }
                else
                {
                    Console.WriteLine("That was not a name.");
                    LeaveProgram(1);
                }
                Console.WriteLine("Hello, " + correctedUserName);               
            }
            else
            {
                foreach (var name in args)
                {
                    var correctedName = name.First().ToString().ToUpper() + name.Substring(1);
                    Console.WriteLine("Hello, " + correctedName);
                }
            }
            if (args.Length > 1)
            {
                multipleUsers = true;
            }
            if (multipleUsers)
            {
                Console.WriteLine("How many hours sleep total did you all get last night?");
                var multipleSleepString = Console.ReadLine();
                try
                {
                    multipleSleepHours = Convert.ToDouble(multipleSleepString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: " + ex.Message);
                    LeaveProgram(1);
                }
                var averageSleep = multipleSleepHours / Convert.ToDouble(args.Length);
                Console.WriteLine("You averaged " + averageSleep + " hours sleep between you.");
                if (averageSleep < 8 && averageSleep > 0)
                {
                    Console.WriteLine("You did not get enough sleep.");
                    LeaveProgram(0);
                }
                else if (averageSleep >= 8 && averageSleep <= 9)
                {
                    Console.WriteLine("You got the perfect amount of sleep.");
                    LeaveProgram(0);
                }
                else if (averageSleep > 9)
                {
                    Console.WriteLine("You got too much sleep.");
                    LeaveProgram(0);
                }
                else if (averageSleep > 15)
                {
                    Console.WriteLine("You have a problem, I would see a Dr as soon as possible.");
                    LeaveProgram(0);
                }
                else if (averageSleep < 0)
                {
                    Console.WriteLine(
                        "You cannot sleep negative amounts, silly billy, perhaps you do need more sleep.");
                    LeaveProgram(0);
                }
            }
            else
            {
                Console.WriteLine("How many hours sleep did you get last night " + correctedUserName + "? ");
                var sleepString = Console.ReadLine();
                try
                {
                    sleepHours = Convert.ToInt32(sleepString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: " + ex.Message);
                    LeaveProgram(1);
                }
                if (sleepHours < 8 && sleepHours > 0)
                {
                    Console.WriteLine("You did not get enough sleep.");
                    LeaveProgram(0);
                }
                else if (sleepHours >= 8 && sleepHours <= 9)
                {
                    Console.WriteLine("You got the perfect amount of sleep.");
                    LeaveProgram(0);
                }
                else if (sleepHours > 9)
                {
                    Console.WriteLine("You got too much sleep.");
                    LeaveProgram(0);
                }
                else if (sleepHours > 15)
                {
                    Console.WriteLine("You have a problem, I would see a Dr as soon as possible.");
                    LeaveProgram(0);
                }
                else if (sleepHours < 0)
                {
                    Console.WriteLine(
                        "You cannot sleep negative amounts, silly billy, perhaps you do need more sleep.");
                    LeaveProgram(0);
                }
            }
        }

        public static void LeaveProgram(int errorCode)
        {
            Console.WriteLine("Exiting program now.");
            Console.ReadKey();
            Environment.Exit(errorCode);
        }
    }
}
