using System;
using System.Text;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a 9 digit number");
            string userInput = Console.ReadLine();
            if (userInput == null || (userInput.Length != 9)) 
            {
                Console.WriteLine("The number is not 9 digits long,Try again!");
                return;
            }
            if (!IsAllNumbers(userInput))
            {
                Console.WriteLine("Enter only numbers!");
                return;
            }
           
            int digitCounter = BiggerThanUnitsDigit(out string list,userInput);
            string output = string.Format(
            "The units digit is {0}.The digit that are greater than it:{2}. total: {1}{5}" +
            "How many digits are divisible by 4? {3}{5}" +
            "The multiplication of the largest and smallest digit: {4}{5}" +
            "How many unique digits: {6}",
            userInput[userInput.Length - 1],
            digitCounter,
            list,
            DividedBy4(userInput),                 
            GetMultMaxAndMinNum(userInput),       
            Environment.NewLine,                
            FindUnique(userInput)                 
            );
            Console.WriteLine(output);
        }

        private static int getDigitAt(int i_Index,string i_RepresentativeStr)
        {
            return i_RepresentativeStr[i_Index] - '0';
        }

        public static int BiggerThanUnitsDigit(out string o_DigitsList,string i_RepresentativeStr)
        {
            int.TryParse(i_RepresentativeStr, out int representativeNum);
            StringBuilder listOfBiggerNums = new StringBuilder();
            int biggerThanCount = 0;
            int unitsDigit = representativeNum % 10;

            for (int i = 0; i < i_RepresentativeStr.Length; i++)
            {
                int currentdigit = getDigitAt(i,i_RepresentativeStr);
                if (currentdigit > unitsDigit)
                {
                    if (listOfBiggerNums.Length > 0)
                    {
                        listOfBiggerNums.Append(",");
                    }

                    listOfBiggerNums.Append(i_RepresentativeStr[i]);
                    biggerThanCount++;
                }
            }

            if (listOfBiggerNums.Length > 0)
            {
                o_DigitsList = listOfBiggerNums.ToString();
            }
            else
            {
                o_DigitsList = "";
            }

            return biggerThanCount;
        }

        public static int FindUnique(string i_RepresentativeStr)
        {
            int numOfUnique = 0;

            for (int i = 0; i < i_RepresentativeStr.Length; i++)
            {
                bool alreadyCounted = false;
                for (int j = 0; j < i; j++)
                {
                    if (i_RepresentativeStr[i] == i_RepresentativeStr[j])
                    {
                        alreadyCounted = true;
                        break;
                    }
                }

                if (!alreadyCounted)
                {
                    numOfUnique++;
                }
            }

            return numOfUnique;
        }

        public static int GetMultMaxAndMinNum(string i_RepresentativeStr)
        {
            int max = getDigitAt(0,i_RepresentativeStr);
            int min = getDigitAt(0,i_RepresentativeStr);

            for (int i = 0; i < i_RepresentativeStr.Length; i++)
            {
                int currentDigit = getDigitAt(i,i_RepresentativeStr);
                if (currentDigit > max)
                {
                    max = currentDigit;
                }

                if (currentDigit < min)
                {
                    min = currentDigit;
                }
            }

            return max * min;
        }

        public static int DividedBy4(string i_RepresentativeStr)
        {
            int dividedBy4Count = 0;

            for (int i = 0; i < i_RepresentativeStr.Length; i++)
            {
                int currentDigit = getDigitAt(i,i_RepresentativeStr);
                if (currentDigit % 4 == 0)
                {
                    dividedBy4Count++;
                }
            }

            return dividedBy4Count;
        }

        public static bool IsAllNumbers(string i_InputStr)
        {
            bool isAllNumbers = true; 

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if (i == 0 && i_InputStr[i] == '-' && i_InputStr.Length > 1)
                {
                    continue;
                }

                if (!char.IsDigit(i_InputStr[i]))
                {
                    isAllNumbers = false;
                    return isAllNumbers;
                }
            }

            return isAllNumbers;
        }
    }
}
