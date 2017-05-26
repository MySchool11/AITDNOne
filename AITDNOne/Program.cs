using System;
using System.Linq;

namespace AITDNOne
{
    internal class Program
    {

        /// <summary>
        /// This program will take names entered at the console when the program is called or will request one when run without parameters
        /// It has four main variables at start; correctedUserName, a string to hold a name(s) which have neem capitalised; sleepHours a double
        /// to hold the number of hours a single user slept; multipleSleepHours a double to hold the total hours slept by more than one user;
        /// multipleUsers, a boolean to inform the program if more than one user name was entered at the console.
        /// Using the information entered by the user it will determine if enough sleep was had by the user(s).
        /// </summary>
        /// <author>
        /// Samuel Bancroft (c) 2017
        /// </author>
        /// <code>
        /// Made up of one main file
        /// Program.cs => the main file
        /// </code>

        private static void Main(string[] args)
        {
            var correctedUserName = "";
            var sleepHours = 0.0;
            var multipleSleepHours = 0.0;
            var multipleUsers = false;
            if (args.Length == 0) // Ask for a name if one or more was (were) not passed at the command line
            {
                Console.WriteLine("Please enter your name: ");
                var userName = Console.ReadLine();   
                if (userName != "") // check the userName sting is not empty
                {
                    if (userName != null) // check the userName string is not null
                        correctedUserName = userName.First().ToString().ToUpper() + userName.Substring(1); // Use Linq to change the first letter of the name to a capital
                }
                else
                {
                    Console.WriteLine("That was not a name."); // if empty or null report error to user
                    LeaveProgram(1); // Exit the program via the function LeaveProgram() passing a 1 for the Environment.Exit() function to record (1 being an errorneous exit and 0 being a normal one)
                }
                Console.WriteLine("Hello, " + correctedUserName);               
            }
            else // args.Length must be one or more so cycle through the parameters and correct the names (capitalise first letter) then welcome them
            {
                foreach (var name in args) // foreach will loop through every variable in an array
                {
                    var correctedName = name.First().ToString().ToUpper() + name.Substring(1);
                    Console.WriteLine("Hello, " + correctedName);
                }
            }
            if (args.Length > 1) // determine if more than one name was entered from the console.
            {
                multipleUsers = true; // set multipleUsers to true if more than one name was passed as an argument
            }
            if (multipleUsers) // run if multipleUsers is true
            {
                Console.WriteLine("How many hours sleep total did you all get last night?");
                var multipleSleepString = Console.ReadLine(); // get the total number of hours slept by everyone and try to pass it to the double multipleHoursSlept
                try
                {
                    multipleSleepHours = Convert.ToDouble(multipleSleepString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: " + ex.Message);
                    LeaveProgram(1);
                }
                var averageSleep = multipleSleepHours / Convert.ToDouble(args.Length); // work out the average sleep of the users
                Console.WriteLine("You averaged " + averageSleep + " hours sleep between you.");
                AmountSlept(averageSleep); // pass the average to the AmountSlept function
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
                AmountSlept(sleepHours); // pass the amount slept to the AmountSlept function     
            }
        }
        public static void AmountSlept(double hoursSlept) // function to provide suitable response to hours slept
        {
            // a set of if else loops to provide the correct response to the time slept
            if (hoursSlept < 8 && hoursSlept > 0)
            {
                Console.WriteLine("You did not get enough sleep.");
                LeaveProgram(0);
            }
            else if (hoursSlept >= 8 && hoursSlept <= 9)
            {
                Console.WriteLine("You got the perfect amount of sleep.");
                LeaveProgram(0);
            }
            else if (hoursSlept > 9)
            {
                Console.WriteLine("You got too much sleep.");
                LeaveProgram(0);
            }
            else if (hoursSlept > 15)
            {
                Console.WriteLine("You have a problem, I would see a Dr as soon as possible.");
                LeaveProgram(0);
            }
            else if (hoursSlept < 0)
            {
                Console.WriteLine(
                    "You cannot sleep negative amounts, silly billy, perhaps you do need more sleep.");
                LeaveProgram(0);
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
