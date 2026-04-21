using Ex01_04;
using System;


namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a 9 digit number!");
            string userInput = Console.ReadLine();
            if ((userInput == null || (userInput.Length != 9))) 
            {
                Console.WriteLine("the number is not 9 digits long,try again!");
                return;
            }

            if (!StringChecker.IsAllNumbers(userInput))
            {
                Console.WriteLine("enter only numbers!");
                return;
            }

            Number number = new Number(userInput);
            int count = number.BiggerThanUnitsDigit(out string list);
            string output = string.Format(
            "The units digit is {0}.The digit that are greater than it:{2}. all in all: {1}{5}" +
            "How many digits are divisible by 4? {3}{5}" +
            "The multiplication of the largest and smallest digit: {4}{5}" +
            "How many unique digits: {6}",
            userInput[userInput.Length - 1],
            count,
            list,
            number.DividedBy4(),                 
            number.GetMultMaxAndMinNum(),       
            Environment.NewLine,                
            number.FindUnique()                 
            );
            Console.WriteLine(output);
        }    
    }
}
