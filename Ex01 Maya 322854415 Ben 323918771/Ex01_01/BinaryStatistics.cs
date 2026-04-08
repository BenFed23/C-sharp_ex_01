using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class BinaryStatistics
    {
        public static void sortBinaryArrInDescendingOrder(BinaryNumber[] io_binaryNumbers)
        {
            int arraySize = io_binaryNumbers.Length;

            for (int i = 0; i < arraySize - 1; ++i) 
            {
                for (int j = 0; j < arraySize - i - 1; ++j)
                {
                    if (io_binaryNumbers[j].getDecimalValue() < io_binaryNumbers[j+1].getDecimalValue())
                    {
                        BinaryNumber tempBinaryNumber = io_binaryNumbers[j];
                        io_binaryNumbers[j] = io_binaryNumbers[j + 1];
                        io_binaryNumbers[j + 1] = tempBinaryNumber;
                    }
                }
            }

        }

        public static float calculateBinaryArrAverage(BinaryNumber[] i_binaryNumbers) 
        {
            int arraySize = i_binaryNumbers.Length;
            float sum = 0;

            for (int i = 0; i < arraySize; ++i)
            {
                sum += i_binaryNumbers[i].getDecimalValue();
            }

            return sum/(float)arraySize;
        }

        public static int findAllBinaryNumbersWithLongestBitSequences(BinaryNumber[] i_binaryNumbers, out BinaryNumber[] o_maxSequenceBinaryNumbers, out int o_amountOfMaxSequenceBinaryNumbers)
        {
            int maxSequenceLength = 0;
            int arraySize = i_binaryNumbers.Length;
            o_amountOfMaxSequenceBinaryNumbers = 0;
            o_maxSequenceBinaryNumbers = new BinaryNumber[arraySize];

            for (int i = 0; i < arraySize; ++i)
            {
                int tempSequenceLength = i_binaryNumbers[i].findLongestSequenceInBinaryString();
               
                if (tempSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = tempSequenceLength;
                    o_amountOfMaxSequenceBinaryNumbers = 0;
                    o_maxSequenceBinaryNumbers[o_amountOfMaxSequenceBinaryNumbers] = i_binaryNumbers[i];
                    ++o_amountOfMaxSequenceBinaryNumbers;
                }
                else if (tempSequenceLength == maxSequenceLength && maxSequenceLength > 0)
                {
                    o_maxSequenceBinaryNumbers[o_amountOfMaxSequenceBinaryNumbers] = i_binaryNumbers[i];
                    ++o_amountOfMaxSequenceBinaryNumbers;
                }
            }

            return maxSequenceLength;
        }

        public static int findAmountOf1InBinaryArr(BinaryNumber[] i_binaryNumbers) 
        {
            int counterOf1 = 0;
            int arraySize = i_binaryNumbers.Length;

            for (int i = 0; i < arraySize; ++i)
            {
                string binaryNumberString = i_binaryNumbers[i].getBinaryNumberString();
                int lengthofBinaryNumberString = i_binaryNumbers[i].getLengthofBinaryNumberString();
                for (int j = 0; j < lengthofBinaryNumberString; ++j) 
                {
                    if (binaryNumberString[j] == '1')
                    {
                        counterOf1++;
                    }
                }
            }

            return counterOf1;
        }

        public static BinaryNumber findmostTransitionsInBinaryNumber(BinaryNumber[] i_binaryNumbers, out int o_maxAmountOfTransitions)
        {
            o_maxAmountOfTransitions = 0;
            int arraySize = i_binaryNumbers.Length;
            BinaryNumber mostTransitionsBinaryNumber = null;

            for (int i = arraySize - 1; i >= 0; --i)
            {
                int tempTransitionsCounter = 0;
                int lengthofBinaryNumberString = i_binaryNumbers[i].getLengthofBinaryNumberString();
                string binaryNumberString = i_binaryNumbers[i].getBinaryNumberString();
                for (int j = 0; j < lengthofBinaryNumberString - 1; ++j)
                {
                    if (binaryNumberString[j] != binaryNumberString[j + 1])
                    {
                        ++tempTransitionsCounter;
                        if (tempTransitionsCounter > o_maxAmountOfTransitions)
                        {
                            o_maxAmountOfTransitions = tempTransitionsCounter;
                            mostTransitionsBinaryNumber = i_binaryNumbers[i];
                        }
                    }
                }
            }

            return mostTransitionsBinaryNumber;
        }

        public static BinaryNumber[] getAmountOfNumbersDividedBy(BinaryNumber[] i_binaryNumbers, int i_divisorNumber, out int o_amountOfDivisbleNumbers)
        {
            int arraySize = i_binaryNumbers.Length;
            o_amountOfDivisbleNumbers = 0;
            BinaryNumber[] arrayOfDivisbleNumbers = new BinaryNumber[arraySize];
            int nextIndexForNewArray = 0;

            for (int i = arraySize - 1; i >= 0; --i)
            {
                if (i_binaryNumbers[i].isDivisibleBy(i_divisorNumber))
                {
                    ++o_amountOfDivisbleNumbers;
                    arrayOfDivisbleNumbers[nextIndexForNewArray] = i_binaryNumbers[i];
                    ++nextIndexForNewArray;
                }
            }

            return arrayOfDivisbleNumbers;
        }
    }
}
