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
            m_DecimalValueOfBinaryNumber = ConvertBinaryStringToDecimal(i_BinaryNumberStringFromUser);
        }

        public int GetDecimalValue()
        {
            return m_DecimalValueOfBinaryNumber;
        }

        public string GetBinaryNumberString()
        {
            return m_BinaryNumberString;
        }

        public int GetLengthOfBinaryNumberString()
        {
            return m_BinaryNumberString.Length;
        }

        public static bool IsValid(string i_BinaryNumberStringFromUser, int i_RequestedLengthOfBinaryNumber)
        {
            bool isValid = true;
            if (i_BinaryNumberStringFromUser.Length < i_RequestedLengthOfBinaryNumber)
            {
                System.Console.Error.WriteLine($"Invalid input size. Please enter a {0} digit binary number", i_RequestedLengthOfBinaryNumber);
                isValid = false;
            }

            for (int i = 0; i < i_RequestedLengthOfBinaryNumber; ++i)
            {
                if (i_BinaryNumberStringFromUser[i] != '0' && i_BinaryNumberStringFromUser[i] != '1')
                {
                    System.Console.Error.WriteLine("Invalid input character. Please enter only 0 or 1");
                    isValid = false;
                }
            }

            return isValid;
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

        public int FindLongestSequenceInBinaryString()
        {
            int longestSequenceInBinaryString = 1;
            int currentLongestSequence = 1;
            int stringLength = m_BinaryNumberString.Length;

            for (int i = 0; i < stringLength - 1; ++i)
            {
                if (m_BinaryNumberString[i] == m_BinaryNumberString[i+1])
                {
                    ++currentLongestSequence;
                }
                else
                {
                    currentLongestSequence = 1;
                }

                if(currentLongestSequence > longestSequenceInBinaryString)
                {
                    longestSequenceInBinaryString = currentLongestSequence;
                }
            }

            return longestSequenceInBinaryString;
        }

        public bool IsDivisibleBy(int i_divisorNumber)
        {
            bool isDivisible = true;
            if (i_divisorNumber == 0) 
            {
                System.Console.Error.WriteLine("Invalid input. can't be divided by 0");
                isDivisible = false; 
            }
            else
            {
                isDivisible = ((m_DecimalValueOfBinaryNumber % i_divisorNumber) == 0);
            }

            return isDivisible;
        }
    }
}
