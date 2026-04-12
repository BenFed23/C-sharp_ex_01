using System;



namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a 8 cherecters string ");
            string userStringInput = Console.ReadLine();
            if (userStringInput.Length != 8)
            {
                Console.WriteLine("The string needs to be 8 characters long, try again!");
                return;
            }

            bool strIsPolindrom = StringChecker.IsPolindrom(userStringInput);
            string analysisResult = "";
            if (StringChecker.IsAllNumbers(userStringInput))
            {
                AllNumbers number = new AllNumbers(userStringInput);
                bool IsDivisibleBy4 = number.IsDivideBy(4);
                analysisResult = string.Format("The number is divisible by 4: {0}", IsDivisibleBy4);
            }
            else if (StringChecker.IsAllLetters(userStringInput))
            {
                AllLetters letters = new AllLetters(userStringInput);
                int uppersCount = letters.UppercaseCount();
                bool isDescending = letters.IsDescendingOrder();
                analysisResult = string.Format("Uppercase count: {0}\nIs descending series: {1}", uppersCount, isDescending);
            }

            string finalOutput = string.Format(
         
            "Is Palindrome: {0}{2}" +
           "{1}",
            strIsPolindrom,
            analysisResult,
            Environment.NewLine);
            Console.WriteLine(finalOutput);
        }
    }
}
