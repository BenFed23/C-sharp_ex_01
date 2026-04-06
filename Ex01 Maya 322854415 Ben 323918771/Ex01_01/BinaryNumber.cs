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

        public BinaryNumber(string i_BinaryNumberStringFromUser)
        {
            m_BinaryNumberString = i_BinaryNumberStringFromUser;
        }

        public static bool isValid(string i_BinaryNumberStringFromUser, int i_RequestedLengthOfBinaryNumber)
        {
            if (i_BinaryNumberStringFromUser.Length < i_RequestedLengthOfBinaryNumber)
            {
                System.Console.Error.WriteLine($"Invalid input size. Please enter a {i_RequestedLengthOfBinaryNumber} digit binary number");
                return false;
            }

            for (int i = 0; i < i_RequestedLengthOfBinaryNumber; ++i)
            {
                if (i_BinaryNumberStringFromUser[i] != '0' && i_BinaryNumberStringFromUser[i] != '1')
                {
                    System.Console.Error.WriteLine("Invalid input character. Please enter only 0 or 1");
                    return false;
                }
            }

            return true;
        }
    }
}
