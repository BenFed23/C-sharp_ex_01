using System;



namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter an 8-characters string");
            string userStringInput = Console.ReadLine();
            if(userStringInput.Length != 8)
            {
                Console.WriteLine("The string needs to be 8 characters long, try again!");
                return;
            }

            bool strIsPalindrome = IsPalindrome(userStringInput);
            string analysisResult = "";
            if(IsAllNumbers(userStringInput))
            {
                int.TryParse(userStringInput, out int RepresentativeNum);
                bool isDivisibleBy4 = IsDivideBy(4, RepresentativeNum);
                analysisResult = string.Format("The number is divisible by 4: {0}", isDivisibleBy4);
            }
            else if(IsAllLetters(userStringInput))
            {
               
                int uppersCount = UppercaseCount(userStringInput);
                bool isDescending = Isdescendingorder(userStringInput);
                analysisResult = string.Format("Uppercase count: {0}\nIs descending series: {1}", uppersCount, isDescending);
            }

            string finalOutput = string.Format(
            "Is Palindrome: {0}{2}" +
           "{1}",
            strIsPalindrome,
            analysisResult,
            Environment.NewLine);
            Console.WriteLine(finalOutput);
        }

        public static bool IsAllNumbers(string i_InputStr)
        {
            bool isAllNunbers = true;

            for(int i = 0; i < i_InputStr.Length; i++)
            {
                if (i == 0 && i_InputStr[i] == '-' && i_InputStr.Length > 1)
                {
                    continue;
                }

                if(!char.IsDigit(i_InputStr[i]))
                {
                    isAllNunbers = false;
                    return isAllNunbers;
                }
            }

            return isAllNunbers;
        }

        public static bool IsAllLetters(string i_InputStr)
        {
            bool isAllLetters = true;

            for(int i = 0; i < i_InputStr.Length; i++)
            {
                if(!char.IsLetter(i_InputStr[i]))
                {
                    isAllLetters = false;
                    return isAllLetters;
                }
            }

            return isAllLetters;
        }

        public static bool IsPalindrome(string i_InputStr)
        {
            bool isPalindrome;

            if (i_InputStr.Length <= 1)
            {
                isPalindrome = true;
            }
            else if (i_InputStr[0] != i_InputStr[i_InputStr.Length - 1])
            {
                isPalindrome = false;
            }
            else
            {
                string smallerStr = i_InputStr.Substring(1, i_InputStr.Length - 2);
                isPalindrome = IsPalindrome(smallerStr);
            }

            return isPalindrome;
        }

        public static bool IsDivideBy(int i_DividerNum, int i_RepresentativeNum)
        {
            bool isDividedByNum = (i_DividerNum != 0) && (i_RepresentativeNum % i_DividerNum == 0);

            return isDividedByNum;
        }

        public static bool Isdescendingorder(string i_RepresentativeStr)
        {
            bool isDescendingOrder = true;

            for (int i = 1; i < i_RepresentativeStr.Length; i++)
            {
                char firstCharacter = char.ToLower(i_RepresentativeStr[i - 1]);
                char secondCharacter = char.ToLower(i_RepresentativeStr[i]);
                if (firstCharacter - secondCharacter <= 0)
                {
                    isDescendingOrder = false;
                }
            }

            return isDescendingOrder;
        }

        public static int UppercaseCount(string i_RepresentativeStr)
        {
            int uppercaseCounter = 0;

            for (int i = 0; i < i_RepresentativeStr.Length; i++)
            {
                if (char.IsUpper(i_RepresentativeStr[i]))
                {
                    uppercaseCounter++;
                }
            }

            return uppercaseCounter;
        }
    }
}
