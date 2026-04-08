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
                if (BinaryNumber.isValid(input, k_LengthOfBinaryNumbers))
                {
                    arrayOfBinaryNumbersFromUser[i] = new BinaryNumber(input);
                }
                else
                {
                    --i;
                }

            }

            BinaryStatistics.sortBinaryArrInDescendingOrder(arrayOfBinaryNumbersFromUser);
            System.Console.Write($"Decimal numbers in descending order: ");

            for (int i = 0; i < k_AmountOfBinaryNumbers; ++i)
            {
                System.Console.Write($"{arrayOfBinaryNumbersFromUser[i].getDecimalValue()} ({arrayOfBinaryNumbersFromUser[i].getBinaryNumberString()})");
                if (i != k_AmountOfBinaryNumbers - 1)
                {
                    System.Console.Write(", ");
                }
            }
            
            System.Console.WriteLine();
            float binaryArrAverage = BinaryStatistics.calculateBinaryArrAverage(arrayOfBinaryNumbersFromUser);
            System.Console.WriteLine($"Average: {binaryArrAverage:F2}");

            BinaryNumber[] maxSequenceBinaryNumbers;
            int sizeOfMaxSequenceBinaryNumbers;
            int maxSequenceLength = BinaryStatistics.findAllBinaryNumbersWithLongestBitSequences(arrayOfBinaryNumbersFromUser, out maxSequenceBinaryNumbers, out sizeOfMaxSequenceBinaryNumbers);
            System.Console.Write($"Longest bit sequence: {maxSequenceLength} (");
            for (int i = 0; i < sizeOfMaxSequenceBinaryNumbers; ++i)
            {
                System.Console.Write($"{maxSequenceBinaryNumbers[i].getBinaryNumberString()}");
                if (i != sizeOfMaxSequenceBinaryNumbers - 1)
                {
                    System.Console.Write(", ");
                }
            }
            System.Console.WriteLine(")");

            int amountOf1Bits = BinaryStatistics.findAmountOf1InBinaryArr(arrayOfBinaryNumbersFromUser);
            System.Console.WriteLine($"Total 1-bits: {amountOf1Bits}");

            int maxAmountOfTransitions;
            BinaryNumber mostTransitionsBinaryNumber = BinaryStatistics.findmostTransitionsInBinaryNumber(arrayOfBinaryNumbersFromUser, out maxAmountOfTransitions);
            System.Console.WriteLine($"Number with most transitions: {mostTransitionsBinaryNumber.getDecimalValue()} ({mostTransitionsBinaryNumber.getBinaryNumberString()}) - {maxAmountOfTransitions} transitions");

            int divisorNumber = 4;
            int amountOfDivisbleNumbers = 0;
            BinaryNumber[] arrayOfDivisbleNumbers = BinaryStatistics.getAmountOfNumbersDividedBy(arrayOfBinaryNumbersFromUser, divisorNumber, out amountOfDivisbleNumbers);
            System.Console.Write($"Numbers divisible by {divisorNumber}: {amountOfDivisbleNumbers} ");

            if (amountOfDivisbleNumbers != 0)
            {
                System.Console.Write("(");
                for (int i = 0; i < amountOfDivisbleNumbers; ++i)
                {
                    System.Console.Write($"{arrayOfDivisbleNumbers[i].getBinaryNumberString()}");
                    if (i != amountOfDivisbleNumbers - 1)
                    {
                        System.Console.Write(", ");
                    }
                }
                System.Console.WriteLine(")");
            }

            System.Console.ReadLine(); //delete
        }
    }
}
