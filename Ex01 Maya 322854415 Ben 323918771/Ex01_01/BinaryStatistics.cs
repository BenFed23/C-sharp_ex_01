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
    }
}
