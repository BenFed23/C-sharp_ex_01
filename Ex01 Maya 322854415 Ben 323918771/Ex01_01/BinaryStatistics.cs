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

        public static int findAmountOf1InBinaryArr(BinaryNumber[] i_binaryNumbers) 
        {
            int counterOf1 = 0;
            int arraySize = i_binaryNumbers.Length;

            for (int i = 0; i < arraySize; ++i)
            {
                string binaryNumberString = i_binaryNumbers[i].getBinaryNumberString();
                for (int j = 0; j < i_binaryNumbers[i].getLengthofBinaryNumberString(); ++j) 
                {
                    if (binaryNumberString[j] == '1')
                    {
                        counterOf1++;
                    }
                }
            }

            return counterOf1;
        }
    }
}
