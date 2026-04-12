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
            int treeHeightNumber;
            bool IsValidInput;

            System.Console.WriteLine("Please enter a tree height (number between 4 - 15)");
            userStringInput = System.Console.ReadLine();
            IsValidInput = int.TryParse(userStringInput, out treeHeightNumber) && (treeHeightNumber <= 15 && treeHeightNumber >= 4);
            while (!IsValidInput) { 
                Console.WriteLine("Invalid input, please enter a valid number between 4 and 15");
                userStringInput = System.Console.ReadLine();
                IsValidInput = int.TryParse(userStringInput, out treeHeightNumber) && (treeHeightNumber <= 15 && treeHeightNumber >= 4);
            }

            Console.WriteLine();
            LetterTreeBuilder.PrintLetterTreeByNumOfLines(treeHeightNumber);
        }
    }
}
