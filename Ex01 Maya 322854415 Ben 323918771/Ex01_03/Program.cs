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
            int treeHeightNumber = GetValidTreeHeight();
            Ex01_02.Program.PrintLetterTreeByNumOfLines(treeHeightNumber);
        }

        public static int GetValidTreeHeight()
        {
            int treeHeightNumber = 0;
            bool isValidInput = false;

            System.Console.WriteLine("Please enter a tree height (number between 4 - 15)");

            while (!isValidInput)
            {
                string userStringInput = System.Console.ReadLine();
                isValidInput = int.TryParse(userStringInput, out treeHeightNumber) && (treeHeightNumber <= 15 && treeHeightNumber >= 4);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input, please enter a valid number between 4 and 15");
                }
            }

            Console.WriteLine();
            return treeHeightNumber;
        }
    }
}
