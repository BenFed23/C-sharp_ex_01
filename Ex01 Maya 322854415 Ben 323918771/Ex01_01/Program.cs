using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        private const int k_AmountOfBinaryNumbers = 4;
        private const int k_LengthOfBinaryNumbers = 7;
        private const int k_divisorNumber = 4;

        public static void Main()
        {
            string firstBinaryNumberFromUser;
            string secondBinaryNumberFromUser;
            string thirdBinaryNumberFromUser;
            string forthBinaryNumberFromUser;

            System.Console.WriteLine("Please insert 4 binary numbers containing 7 bits");
            getInputStringsFromUser(out firstBinaryNumberFromUser, out secondBinaryNumberFromUser, out thirdBinaryNumberFromUser, out forthBinaryNumberFromUser);
            PrintBinaryNumbersInDescendingOrder(ref firstBinaryNumberFromUser, ref secondBinaryNumberFromUser, ref thirdBinaryNumberFromUser, ref forthBinaryNumberFromUser);
            CalculateAndPrintBinaryNumbersAverage(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAllBinaryNumbersWithLongestBitSequences(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAndPrintTotalAmountOfOnes(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAndPrintMostTransitionsInBinaryNumber(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            PrintAmountOfNumbersDividedBy(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
        }

        public static void getInputStringsFromUser(out string o_FirstBinaryNumberFromUser, out string o_SecondBinaryNumberFromUser, out string o_ThirdBinaryNumberFromUser, out string o_ForthBinaryNumberFromUser)
        {
            o_FirstBinaryNumberFromUser = string.Empty;
            o_SecondBinaryNumberFromUser = string.Empty;
            o_ThirdBinaryNumberFromUser = string.Empty;
            o_ForthBinaryNumberFromUser = string.Empty;
            for (int i = 0; i < k_AmountOfBinaryNumbers; ++i)
            {
                string input = System.Console.ReadLine();
                if (IsValid(input, k_LengthOfBinaryNumbers))
                {
                    switch (i)
                    {
                        case 0:
                            o_FirstBinaryNumberFromUser = input;
                            break;
                        case 1:
                            o_SecondBinaryNumberFromUser = input;
                            break;
                        case 2:
                            o_ThirdBinaryNumberFromUser = input;
                            break;
                        case 3:
                            o_ForthBinaryNumberFromUser = input;
                            break;
                    }
                }
                else
                {
                    --i;
                }
            }
        }

        public static bool IsValid(string i_BinaryNumberStringFromUser, int i_RequestedLengthOfBinaryNumber)
        {
            bool isValid = true;

            if (i_BinaryNumberStringFromUser.Length != i_RequestedLengthOfBinaryNumber)
            {
                System.Console.WriteLine("Invalid input size. Please enter a {0} digit binary number", i_RequestedLengthOfBinaryNumber);
                isValid = false;
            }

            for (int i = 0; i < i_RequestedLengthOfBinaryNumber && isValid; ++i)
            {
                if (i_BinaryNumberStringFromUser[i] != '0' && i_BinaryNumberStringFromUser[i] != '1')
                {
                    System.Console.WriteLine("Invalid input character. Please enter only 0 or 1");
                    isValid = false;
                }
            }

            return isValid;
        }

        public static void PrintBinaryNumbersInDescendingOrder(ref string io_FirstBinaryNumber, ref string io_SecondBinaryNumber, ref string io_ThirdBinaryNumber, ref string io_ForthBinaryNumber)
        {
            swapIfSmaller(ref io_FirstBinaryNumber, ref io_SecondBinaryNumber);
            swapIfSmaller(ref io_ThirdBinaryNumber, ref io_ForthBinaryNumber);
            swapIfSmaller(ref io_FirstBinaryNumber, ref io_ThirdBinaryNumber);
            swapIfSmaller(ref io_SecondBinaryNumber, ref io_ForthBinaryNumber);
            swapIfSmaller(ref io_SecondBinaryNumber, ref io_ThirdBinaryNumber);
            System.Console.Write("Decimal numbers in descending order: ");
            printSingleBinaryInfo(io_FirstBinaryNumber, false);
            printSingleBinaryInfo(io_SecondBinaryNumber, false);
            printSingleBinaryInfo(io_ThirdBinaryNumber, false);
            printSingleBinaryInfo(io_ForthBinaryNumber, true);
            System.Console.WriteLine();
        }
        private static void printSingleBinaryInfo(string i_BinaryStringToPrint, bool i_IsLastString)
        {
            int decimalValueOfString = Convert.ToInt32(i_BinaryStringToPrint, 2);
            System.Console.Write("{0} ({1})", decimalValueOfString, i_BinaryStringToPrint);
            if (!i_IsLastString)
            {
                System.Console.Write(", ");
            }
        }

        private static void swapIfSmaller(ref string io_StringOfFirstNumber, ref string io_StringOfSecondNumber)
        {
            int valueOfFirstNumber = ConvertBinaryStringToDecimal(io_StringOfFirstNumber);
            int valueOfSecondNumber = ConvertBinaryStringToDecimal(io_StringOfSecondNumber);

            if(valueOfFirstNumber < valueOfSecondNumber) 
            {
                string tempStringOfNumber = io_StringOfFirstNumber;
                io_StringOfFirstNumber = io_StringOfSecondNumber;
                io_StringOfSecondNumber = tempStringOfNumber;
            }
        }

        public static int ConvertBinaryStringToDecimal(string i_BinaryNumberStringFromUser)
        {
            int decimalValueOfBinaryString = 0;
            int binaryStringLength = i_BinaryNumberStringFromUser.Length;

            for (int i = 0; i < binaryStringLength; ++i)
            {
                if (i_BinaryNumberStringFromUser[i] == '1')
                {
                    decimalValueOfBinaryString += (int)Math.Pow(2, binaryStringLength - (i + 1));
                }
            }

            return decimalValueOfBinaryString;
        }

        public static void CalculateAndPrintBinaryNumbersAverage(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            double sumOfDecimaValue = 0;
            double binaryNumbersAverage = 0;
            int valueOfFirstNumber = ConvertBinaryStringToDecimal(i_FirstBinaryNumberString);
            int valueOfSecondNumber = ConvertBinaryStringToDecimal(i_SecondBinaryNumberString);
            int valueOfThirdNumber = ConvertBinaryStringToDecimal(i_ThirdBinaryNumberString);
            int valueOfForthNumber = ConvertBinaryStringToDecimal(i_ForthBinaryNumberString);

            sumOfDecimaValue = valueOfFirstNumber + valueOfSecondNumber + valueOfThirdNumber + valueOfForthNumber;
            binaryNumbersAverage = sumOfDecimaValue / (double)k_AmountOfBinaryNumbers;
            int roundedTotal = (int)(binaryNumbersAverage * 100 + 0.5f);
            int wholePart = roundedTotal / 100;
            int decimalPart = roundedTotal % 100;
            System.Console.Write("Average: {0}.{1}", wholePart, decimalPart);
            if (decimalPart < 10)
            {
                System.Console.WriteLine("0");
            }
            else
            {
                System.Console.WriteLine();
            }
        }

        public static void FindAllBinaryNumbersWithLongestBitSequences(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            int longestSequenceOfFirstNumber = CountLongestSequenceInString(i_FirstBinaryNumberString);
            int longestSequenceOfSecondNumber = CountLongestSequenceInString(i_SecondBinaryNumberString);
            int longestSequenceOfThirdNumber = CountLongestSequenceInString(i_ThirdBinaryNumberString);
            int longestSequenceOfForthNumber = CountLongestSequenceInString(i_ForthBinaryNumberString);
            int maxSequenceLength = Math.Max(Math.Max(longestSequenceOfFirstNumber, longestSequenceOfSecondNumber), Math.Max(longestSequenceOfThirdNumber, longestSequenceOfForthNumber));
            int amountOdNumbersWithLongestSequence = 0;
            bool isFirst = true;

            System.Console.Write("Longest bit sequence: {0} (", maxSequenceLength);
            if (longestSequenceOfFirstNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_FirstBinaryNumberString, ref isFirst);
            }

            if (longestSequenceOfSecondNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_SecondBinaryNumberString, ref isFirst);
            }

            if (longestSequenceOfThirdNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_ThirdBinaryNumberString, ref isFirst);
            }

            if (longestSequenceOfForthNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_ForthBinaryNumberString, ref isFirst);
            }

            System.Console.WriteLine(")");
        }

        private static void printNumberWithLongestSequence(string i_BinaryStringToPrint, ref bool io_IsFirst)
        {
            if (!io_IsFirst)
            {
                System.Console.Write(", ");
            }
            System.Console.Write(i_BinaryStringToPrint);
            io_IsFirst = false;
        }

        private static int CountLongestSequenceInString(string i_BinaryString)
        {
            int maxSequenceLength = 0;
            int currSequenceLength = 1;
            int stringLength = i_BinaryString.Length;

            for(int i = 0; i < stringLength - 1; ++i) 
            {
                if (i_BinaryString[i] == i_BinaryString[i + 1])
                {
                    ++currSequenceLength;
                }
                else
                {
                    maxSequenceLength = Math.Max(currSequenceLength, maxSequenceLength);
                    currSequenceLength = 1;
                }
            }

            return Math.Max(currSequenceLength, maxSequenceLength);
        }

        public static void FindAndPrintTotalAmountOfOnes(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            int counterOfOne = 0;

            counterOfOne += countOnesInSingleString(i_FirstBinaryNumberString);
            counterOfOne += countOnesInSingleString(i_SecondBinaryNumberString);
            counterOfOne += countOnesInSingleString(i_ThirdBinaryNumberString);
            counterOfOne += countOnesInSingleString(i_ForthBinaryNumberString);
            System.Console.WriteLine("Total 1-bits: {0}", counterOfOne);
        }

        private static int countOnesInSingleString(string i_BinaryString)
        {
            int counterOfOne = 0;

            for(int i = 0; i < k_LengthOfBinaryNumbers; ++i)
            {
                if (i_BinaryString[i] == '1')
                {
                    counterOfOne++;
                }
            }

            return counterOfOne;
        }

        public static void FindAndPrintMostTransitionsInBinaryNumber(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            string mostTransitionsBinaryNumber = i_FirstBinaryNumberString;
            int maxAmountOfTransitions = countTransitionsInString(i_FirstBinaryNumberString);
            int tempTransitionsCounter = countTransitionsInString(i_SecondBinaryNumberString);

            if(tempTransitionsCounter >= maxAmountOfTransitions)
            {
                maxAmountOfTransitions = tempTransitionsCounter;
                mostTransitionsBinaryNumber = i_SecondBinaryNumberString;
            }

            tempTransitionsCounter = countTransitionsInString(i_ThirdBinaryNumberString);
            if (tempTransitionsCounter >= maxAmountOfTransitions)
            {
                maxAmountOfTransitions = tempTransitionsCounter;
                mostTransitionsBinaryNumber = i_ThirdBinaryNumberString;
            }

            tempTransitionsCounter = countTransitionsInString(i_ForthBinaryNumberString);
            if (tempTransitionsCounter >= maxAmountOfTransitions)
            {
                maxAmountOfTransitions = tempTransitionsCounter;
                mostTransitionsBinaryNumber = i_ForthBinaryNumberString;
            }

            int decimalValueOfMostTransitionsNumber = ConvertBinaryStringToDecimal(mostTransitionsBinaryNumber);
            System.Console.WriteLine("Number with most transitions: {0} ({1}) - {2} transitions", decimalValueOfMostTransitionsNumber, mostTransitionsBinaryNumber, maxAmountOfTransitions);
        }

        private static int countTransitionsInString(string i_BinaryString)
        {
            int amountOfTransitions = 0;

            for (int i = 0; i < k_LengthOfBinaryNumbers - 1; ++i)
            {
                if (i_BinaryString[i] != i_BinaryString[i + 1])
                {
                    ++amountOfTransitions;
                }
            }

            return amountOfTransitions;
        }
        public static void PrintAmountOfNumbersDividedBy(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            int amountOfDivisbleNumbers = 0;
            int decimalValueOfFirstNumber = ConvertBinaryStringToDecimal(i_FirstBinaryNumberString);
            int decimalValueOfSecondNumber = ConvertBinaryStringToDecimal(i_SecondBinaryNumberString);
            int decimalValueOfThirdNumber = ConvertBinaryStringToDecimal(i_ThirdBinaryNumberString);
            int decimalValueOfForthNumber = ConvertBinaryStringToDecimal(i_ForthBinaryNumberString);
            bool isFirstDividedBy = IsDivisibleBy(k_divisorNumber, decimalValueOfFirstNumber);
            bool isSecondDividedBy = IsDivisibleBy(k_divisorNumber, decimalValueOfSecondNumber);
            bool isThirdDividedBy = IsDivisibleBy(k_divisorNumber, decimalValueOfThirdNumber);
            bool isForthDividedBy = IsDivisibleBy(k_divisorNumber, decimalValueOfForthNumber);

            if(isFirstDividedBy)
            {
                ++amountOfDivisbleNumbers;
            }

            if (isSecondDividedBy)
            {
                ++amountOfDivisbleNumbers;
            }

            if (isThirdDividedBy)
            {
                ++amountOfDivisbleNumbers;
            }

            if (isForthDividedBy)
            {
                ++amountOfDivisbleNumbers;
            }

            System.Console.Write("Numbers divisible by {0}: {1} ", k_divisorNumber, amountOfDivisbleNumbers);
            if (amountOfDivisbleNumbers != 0)
            {
                bool isFirstString = true;
                System.Console.Write("(");
                if (isForthDividedBy)
                {
                    printNumberDividedNumber(i_ForthBinaryNumberString, ref isFirstString);
                }

                if (isThirdDividedBy)
                {
                    printNumberDividedNumber(i_ThirdBinaryNumberString, ref isFirstString);
                }

                if (isSecondDividedBy)
                {
                    printNumberDividedNumber(i_SecondBinaryNumberString, ref isFirstString);
                }

                if (isFirstDividedBy)
                {
                    printNumberDividedNumber(i_FirstBinaryNumberString, ref isFirstString);
                }

                System.Console.WriteLine(")");
            }
        }

        private static void printNumberDividedNumber(string i_BinaryStringToPrint, ref bool io_IsFirst)
        {
            if (!io_IsFirst)
            {
                System.Console.Write(", ");
            }
            System.Console.Write("{0}", i_BinaryStringToPrint);
            io_IsFirst = false;
        }
        public static bool IsDivisibleBy(int i_divisorNumber, int i_dividedNumber)
        {
            bool isDivisible = true;

            if (i_divisorNumber == 0)
            {
                System.Console.WriteLine("Invalid input. can't be divided by 0");
                isDivisible = false;
            }
            else
            {
                isDivisible = ((i_dividedNumber % i_divisorNumber) == 0);
            }

            return isDivisible;
        }
    }
}

