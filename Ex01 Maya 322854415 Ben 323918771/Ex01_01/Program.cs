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

        public static void Main()
        {
            BinaryNumber[] arrayOfBinaryNumbersFromUser = new BinaryNumber[k_AmountOfBinaryNumbers];
            System.Console.WriteLine("Please insert 4 binary numbers containing 7 bits");
            for (int i = 0; i < k_AmountOfBinaryNumbers; ++i)
            {
                string input = System.Console.ReadLine();
                if (BinaryNumber.IsValid(input, k_LengthOfBinaryNumbers))
                {
                    arrayOfBinaryNumbersFromUser[i] = new BinaryNumber(input);
                }
                else
                {
                    --i;
                }
            }

            BinaryStatistics.SortBinaryArrInDescendingOrder(arrayOfBinaryNumbersFromUser);
            System.Console.Write($"Decimal numbers in descending order: ");
            for (int i = 0; i < k_AmountOfBinaryNumbers; ++i)
            {
                System.Console.Write($"{arrayOfBinaryNumbersFromUser[i].GetDecimalValue()} ({arrayOfBinaryNumbersFromUser[i].GetBinaryNumberString()})");
                if (i != k_AmountOfBinaryNumbers - 1)
                {
                    System.Console.Write(", ");
                }
            }
            
            System.Console.WriteLine();
            float binaryArrAverage = BinaryStatistics.CalculateBinaryArrAverage(arrayOfBinaryNumbersFromUser);
            System.Console.WriteLine($"Average: {binaryArrAverage:F2}");
            BinaryNumber[] maxSequenceBinaryNumbers;
            int sizeOfMaxSequenceBinaryNumbers;
            int maxSequenceLength = BinaryStatistics.FindAllBinaryNumbersWithLongestBitSequences(arrayOfBinaryNumbersFromUser, out maxSequenceBinaryNumbers, out sizeOfMaxSequenceBinaryNumbers);
            System.Console.Write($"Longest bit sequence: {0} (", maxSequenceLength);
            for (int i = 0; i < sizeOfMaxSequenceBinaryNumbers; ++i)
            {
                System.Console.Write($"{maxSequenceBinaryNumbers[i].GetBinaryNumberString()}");
                if (i != sizeOfMaxSequenceBinaryNumbers - 1)
                {
                    System.Console.Write(", ");
                }
            }

            System.Console.WriteLine(")");
            int amountOf1Bits = BinaryStatistics.FindAmountOf1InBinaryArr(arrayOfBinaryNumbersFromUser);
            System.Console.WriteLine($"Total 1-bits: {0}", amountOf1Bits);
            int maxAmountOfTransitions;
            BinaryNumber mostTransitionsBinaryNumber = BinaryStatistics.FindmostTransitionsInBinaryNumber(arrayOfBinaryNumbersFromUser, out maxAmountOfTransitions);
            System.Console.WriteLine($"Number with most transitions: {0} ({1}) - {2} transitions", mostTransitionsBinaryNumber.GetDecimalValue(), mostTransitionsBinaryNumber.GetBinaryNumberString(), maxAmountOfTransitions);
            int divisorNumber = 4;
            int amountOfDivisbleNumbers = 0;
            BinaryNumber[] arrayOfDivisbleNumbers = BinaryStatistics.GetAmountOfNumbersDividedBy(arrayOfBinaryNumbersFromUser, divisorNumber, out amountOfDivisbleNumbers);
            System.Console.Write($"Numbers divisible by {0}: {1} ", divisorNumber, amountOfDivisbleNumbers);
            if (amountOfDivisbleNumbers != 0)
            {
                System.Console.Write("(");
                for (int i = 0; i < amountOfDivisbleNumbers; ++i)
                {
                    System.Console.Write($"{arrayOfDivisbleNumbers[i].GetBinaryNumberString()}");
                    if (i != amountOfDivisbleNumbers - 1)
                    {
                        System.Console.Write(", ");
                    }
                }

                System.Console.WriteLine(")");
            }
        }
    }
}
