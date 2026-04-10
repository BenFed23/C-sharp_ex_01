using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01_02;

namespace Ex01_03
{
    internal class Program
    {
        public static void Main()
        {
            string userStringInput;
            int TreeHeightNumber;
            bool isValidInput;

            System.Console.WriteLine("Please enter a tree height (number between 4 - 15)");
            userStringInput = System.Console.ReadLine();
            isValidInput = int.TryParse(userStringInput, out TreeHeightNumber) && (TreeHeightNumber <= 15 && TreeHeightNumber >= 4);
            while (!isValidInput) { 
                Console.WriteLine("Invalid input, please enter a valid number between 4 and 15");
                userStringInput = System.Console.ReadLine();
                isValidInput = int.TryParse(userStringInput, out TreeHeightNumber) && (TreeHeightNumber <= 15 && TreeHeightNumber >= 4);
            }

            Console.WriteLine();
            LetterTreeBuilder.printLetterTreeByNumOfLines(TreeHeightNumber);
        }
    }
}
