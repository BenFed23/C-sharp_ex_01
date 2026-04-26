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
        private const int k_DivisorNumber = 4;

        public static void Main()
        {
            string firstBinaryNumberFromUser;
            string secondBinaryNumberFromUser;
            string thirdBinaryNumberFromUser;
            string forthBinaryNumberFromUser;

            System.Console.WriteLine("Please insert 4 binary numbers containing 7 bits");
            GetInputStringsFromUser(out firstBinaryNumberFromUser, out secondBinaryNumberFromUser, out thirdBinaryNumberFromUser, out forthBinaryNumberFromUser);
            PrintBinaryNumbersInDescendingOrder(ref firstBinaryNumberFromUser, ref secondBinaryNumberFromUser, ref thirdBinaryNumberFromUser, ref forthBinaryNumberFromUser);
            CalculateAndPrintBinaryNumbersAverage(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAllBinaryNumbersWithLongestBitSequences(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAndPrintTotalAmountOfOnes(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            FindAndPrintMostTransitionsInBinaryNumber(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
            PrintAmountOfNumbersDividedBy(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser, forthBinaryNumberFromUser);
        }

        public static void GetInputStringsFromUser(out string o_FirstBinaryNumberFromUser, out string o_SecondBinaryNumberFromUser, 
            out string o_ThirdBinaryNumberFromUser, out string o_ForthBinaryNumberFromUser)
        {
            o_FirstBinaryNumberFromUser = string.Empty;
            o_SecondBinaryNumberFromUser = string.Empty;
            o_ThirdBinaryNumberFromUser = string.Empty;
            o_ForthBinaryNumberFromUser = string.Empty;

            for(int i = 0; i < k_AmountOfBinaryNumbers; ++i) 
            {
                string userInputString = System.Console.ReadLine();
                if(IsValid(userInputString, k_LengthOfBinaryNumbers))
                {
                    switch(i)
                    {
                        case 0:
                            o_FirstBinaryNumberFromUser = userInputString;
                            break;
                        case 1:
                            o_SecondBinaryNumberFromUser = userInputString;
                            break;
                        case 2:
                            o_ThirdBinaryNumberFromUser = userInputString;
                            break;
                        case 3:
                            o_ForthBinaryNumberFromUser = userInputString;
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

            if(i_BinaryNumberStringFromUser.Length != i_RequestedLengthOfBinaryNumber)
            {
                System.Console.WriteLine("Invalid input size. Please enter a {0} digit binary number", i_RequestedLengthOfBinaryNumber);
                isValid = false;
            }

            for(int i = 0; i < i_RequestedLengthOfBinaryNumber && isValid; ++i)
            {
                if(i_BinaryNumberStringFromUser[i] != '0' && i_BinaryNumberStringFromUser[i] != '1')
                {
                    System.Console.WriteLine("Invalid input character. Please enter only 0 or 1");
                    isValid = false;
                }
            }

            return isValid;
        }

        public static void PrintBinaryNumbersInDescendingOrder(ref string io_FirstBinaryNumber, ref string io_SecondBinaryNumber, 
            ref string io_ThirdBinaryNumber, ref string io_ForthBinaryNumber)
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
            int decimalValueOfString = ConvertBinaryStringToDecimal(i_BinaryStringToPrint);

            System.Console.Write("{0} ({1})", decimalValueOfString, i_BinaryStringToPrint);
            if(!i_IsLastString)
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

            for(int i = 0; i < binaryStringLength; ++i)
            {
                if(i_BinaryNumberStringFromUser[i] == '1')
                {
                    decimalValueOfBinaryString += (int)Math.Pow(2, binaryStringLength - (i + 1));
                }
            }

            return decimalValueOfBinaryString;
        }

        public static void CalculateAndPrintBinaryNumbersAverage(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, 
            string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
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
            int wholePartOfNumber = roundedTotal / 100;
            int decimalPartOfNumber = roundedTotal % 100;
            System.Console.Write("Average: {0}.{1}", wholePartOfNumber, decimalPartOfNumber);
            if(decimalPartOfNumber < 10)
            {
                System.Console.WriteLine("0");
            }
            else
            {
                System.Console.WriteLine();
            }
        }

        public static void FindAllBinaryNumbersWithLongestBitSequences(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, 
            string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            int longestSequenceOfFirstNumber = countLongestSequenceInString(i_FirstBinaryNumberString);
            int longestSequenceOfSecondNumber = countLongestSequenceInString(i_SecondBinaryNumberString);
            int longestSequenceOfThirdNumber = countLongestSequenceInString(i_ThirdBinaryNumberString);
            int longestSequenceOfForthNumber = countLongestSequenceInString(i_ForthBinaryNumberString);
            int maxSequenceLength = Math.Max(Math.Max(longestSequenceOfFirstNumber, longestSequenceOfSecondNumber), Math.Max(longestSequenceOfThirdNumber, longestSequenceOfForthNumber));
            bool isFirst = true;

            System.Console.Write("Longest bit sequence: {0} (", maxSequenceLength);
            if(longestSequenceOfFirstNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_FirstBinaryNumberString, ref isFirst);
            }

            if(longestSequenceOfSecondNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_SecondBinaryNumberString, ref isFirst);
            }

            if(longestSequenceOfThirdNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_ThirdBinaryNumberString, ref isFirst);
            }

            if(longestSequenceOfForthNumber == maxSequenceLength)
            {
                printNumberWithLongestSequence(i_ForthBinaryNumberString, ref isFirst);
            }

            System.Console.WriteLine(")");
        }

        private static void printNumberWithLongestSequence(string i_BinaryStringToPrint, ref bool io_IsFirst)
        {
            if(!io_IsFirst)
            {
                System.Console.Write(", ");
            }

            System.Console.Write(i_BinaryStringToPrint);
            io_IsFirst = false;
        }

        private static int countLongestSequenceInString(string i_BinaryString)
        {
            int maxSequenceLength = 0;
            int currSequenceLength = 1;
            int stringLength = i_BinaryString.Length;

            for(int i = 0; i < stringLength - 1; ++i) 
            {
                if(i_BinaryString[i] == i_BinaryString[i + 1])
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

        public static void FindAndPrintTotalAmountOfOnes(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, 
            string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
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
                if(i_BinaryString[i] == '1')
                {
                    counterOfOne++;
                }
            }

            return counterOfOne;
        }

        public static void FindAndPrintMostTransitionsInBinaryNumber(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, 
            string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
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
            if(tempTransitionsCounter >= maxAmountOfTransitions)
            {
                maxAmountOfTransitions = tempTransitionsCounter;
                mostTransitionsBinaryNumber = i_ThirdBinaryNumberString;
            }

            tempTransitionsCounter = countTransitionsInString(i_ForthBinaryNumberString);
            if(tempTransitionsCounter >= maxAmountOfTransitions)
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

            for(int i = 0; i < k_LengthOfBinaryNumbers - 1; ++i)
            {
                if(i_BinaryString[i] != i_BinaryString[i + 1])
                {
                    ++amountOfTransitions;
                }
            }

            return amountOfTransitions;
        }

        public static void PrintAmountOfNumbersDividedBy(string i_FirstBinaryNumberString, string i_SecondBinaryNumberString, 
            string i_ThirdBinaryNumberString, string i_ForthBinaryNumberString)
        {
            int amountOfDivisbleNumbers = getDivisibilityBit(i_FirstBinaryNumberString) + getDivisibilityBit(i_SecondBinaryNumberString) + getDivisibilityBit(i_ThirdBinaryNumberString) + getDivisibilityBit(i_ForthBinaryNumberString);

            System.Console.Write("Numbers divisible by {0}: {1} ", k_DivisorNumber, amountOfDivisbleNumbers);
            if(amountOfDivisbleNumbers != 0)
            {
                bool isFirstString = true;
                System.Console.Write("(");
                printIfDivisible(i_ForthBinaryNumberString, ref isFirstString);
                printIfDivisible(i_ThirdBinaryNumberString, ref isFirstString);
                printIfDivisible(i_SecondBinaryNumberString, ref isFirstString);
                printIfDivisible(i_FirstBinaryNumberString, ref isFirstString);

                System.Console.WriteLine(")");
            }
        }

        private static void printIfDivisible(string i_BinaryString, ref bool io_IsFirst)
        {
            int decimalValue = ConvertBinaryStringToDecimal(i_BinaryString);
            if (IsDivisibleBy(k_DivisorNumber, decimalValue))
            {
                printNumberDividedNumber(i_BinaryString, ref io_IsFirst);
            }
        }

        private static int getDivisibilityBit(string i_BinaryString)
        {
            int decimalValue = ConvertBinaryStringToDecimal(i_BinaryString);
            return IsDivisibleBy(k_DivisorNumber, decimalValue) ? 1 : 0;
        }

        private static void printNumberDividedNumber(string i_BinaryStringToPrint, ref bool io_IsFirst)
        {
            if(!io_IsFirst)
            {
                System.Console.Write(", ");
            }

            System.Console.Write("{0}", i_BinaryStringToPrint);
            io_IsFirst = false;
        }
        public static bool IsDivisibleBy(int i_DivisorNumber, int i_DividedNumber)
        {
            bool isDivisible = false;

            if(i_DivisorNumber == 0)
            {
                System.Console.WriteLine("Invalid input. can't be divided by 0");
            }
            else
            {
                isDivisible = ((i_DividedNumber % i_DivisorNumber) == 0);
            }

            return isDivisible;
        }
    }
}

