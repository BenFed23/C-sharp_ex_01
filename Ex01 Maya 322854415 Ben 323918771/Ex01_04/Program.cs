using System;



namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a 8 cherecters string ");
            string i_Sentence = Console.ReadLine();
            if (i_Sentence.Length != 8)
            {
                Console.WriteLine("The string needs to be 8 characters long, try again!");
                return;
            }
            bool strIsPolindrom = StringChecker.IsPolindrom(i_Sentence);
            string analysisResult = "";
            if (StringChecker.IsAllNumbers(i_Sentence))
            {
                AllNumbers number = new AllNumbers(i_Sentence);
                bool isDivisibleBy4 = number.IsDivideBy(4);
                analysisResult = string.Format("The number is divisible by 4: {0}", isDivisibleBy4);
            }
            else if (StringChecker.IsAllLetters(i_Sentence))
            {
                AllLetters letters = new AllLetters(i_Sentence);
                int uppersCount = letters.uppercaseCount();
                bool isDescending = letters.Isdescendingorder();
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
