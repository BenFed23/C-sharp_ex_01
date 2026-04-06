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

            for (int i = 0; i < k_AmountOfBinaryNumbers; i++)
            {
                System.Console.WriteLine($"{arrayOfBinaryNumbersFromUser[i].getDecimalValue()}");
            }
        }
    }
}
