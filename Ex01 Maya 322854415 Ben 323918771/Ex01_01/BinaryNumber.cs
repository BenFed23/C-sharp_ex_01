using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class BinaryNumber
    {
        private string m_BinaryNumberString;
        private int m_DecimalValueOfBinaryNumber;

        public BinaryNumber(string BinaryNumberString)
        {
            m_BinaryNumberString = BinaryNumberString;
        }

        public static bool isValid(string binaryNumberString, int LengthOfBinaryNumber)
        {
            if (binaryNumberString.Length < LengthOfBinaryNumber)
            {
                System.Console.Error.WriteLine("Invalid input size. Please enter a 7 digit binary number");
                return false;
            }

            for (int i = 0; i < LengthOfBinaryNumber; ++i)
            {
                if (binaryNumberString[i] != '0' && binaryNumberString[i] != '1')
                {
                    System.Console.Error.WriteLine("Invalid input character. Please enter only 0 or 1");
                    return false;
                }
            }

            return true;
        }
    }
}
