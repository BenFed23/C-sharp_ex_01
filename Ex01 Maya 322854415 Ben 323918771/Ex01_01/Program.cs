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

            BinaryNumber maxSequenceBinaryNumber;
            int maxSequenceLength = BinaryStatistics.findBinaryArrLongestBitSequence(arrayOfBinaryNumbersFromUser, out maxSequenceBinaryNumber);
            System.Console.WriteLine($"Longest bit sequence: {maxSequenceLength} ({maxSequenceBinaryNumber.getBinaryNumberString()})");

            int amountOf1Bits = BinaryStatistics.findAmountOf1InBinaryArr(arrayOfBinaryNumbersFromUser);
            System.Console.WriteLine($"Total 1-bits: {amountOf1Bits}");

            

        }
    }
}
