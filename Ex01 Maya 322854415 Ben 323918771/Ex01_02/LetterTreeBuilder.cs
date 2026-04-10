using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class LetterTreeBuilder
    {
        private const char k_StartChar = 'A';
        private const int k_StartRowIndex = 1;
        private const int k_TreeTrunkHeight = 2;
        private const int k_AmountOfLettersInTreeTrunk = 1;
        public static void printLetterTreeByNumOfLines(int i_numOfLinesInTree)
        {
            int heightWithoutTreeTrunk = i_numOfLinesInTree - k_TreeTrunkHeight;
            char nextCharForTrunk = printLetterTreeWithoutTreeTrunkRecursive(k_StartRowIndex, heightWithoutTreeTrunk, k_StartChar);
            printTrunkOfTreeRecursive(k_StartRowIndex, heightWithoutTreeTrunk, nextCharForTrunk);
        }

        private static char printLetterTreeWithoutTreeTrunkRecursive(int i_currentRowNumber, int i_heightWithoutTreeTrunk, char i_currentCharToPrint)
        {
            if (i_currentRowNumber > i_heightWithoutTreeTrunk)
            {
                return i_currentCharToPrint;
            }

            System.Console.Write($"{i_currentRowNumber}    ");
            printCharsRecursive(2*(i_heightWithoutTreeTrunk - i_currentRowNumber), " ");
            char nextCharToPrint = printLettersRecursive((2 * i_currentRowNumber) - 1, i_currentCharToPrint);
            System.Console.WriteLine();
            System.Console.WriteLine();

            return printLetterTreeWithoutTreeTrunkRecursive(i_currentRowNumber + 1, i_heightWithoutTreeTrunk, nextCharToPrint);
        }

        private static char printLettersRecursive(int i_amountOfLettersInLine, char i_currentCharToPrint)
        {
            if (i_amountOfLettersInLine <= 0)
            {
                return i_currentCharToPrint;
            }

            System.Console.Write(i_currentCharToPrint);
            if(i_amountOfLettersInLine > 1)
            {
                System.Console.Write(" ");
            }

            char nextCharToPrint;

            if (i_currentCharToPrint == 'Z')
            {
                nextCharToPrint = 'A';
            }
            else
            {
                nextCharToPrint = (char)(i_currentCharToPrint + 1);
            }

            return printLettersRecursive(i_amountOfLettersInLine - 1, nextCharToPrint);

        }

        private static void printCharsRecursive(int i_amountOfcharsToPrint, string i_strToPrint)
        {
            if (i_amountOfcharsToPrint <= 0)
            {
                return;
            }

            System.Console.Write(i_strToPrint);
            printCharsRecursive(i_amountOfcharsToPrint - 1, i_strToPrint);
        }

        private static void printTrunkOfTreeRecursive(int i_trunkLineIndex, int i_trunkHeight, char i_currentCharToPrint)
        {
            if (i_trunkLineIndex > k_TreeTrunkHeight)
            {
                return;
            }

            int currentRowNumber = i_trunkHeight + i_trunkLineIndex;
            System.Console.Write($"{currentRowNumber}    ");
            printCharsRecursive(2*(i_trunkHeight - 1) - 1, " ");
            System.Console.Write("|");
            printLettersRecursive(k_AmountOfLettersInTreeTrunk, i_currentCharToPrint);
            System.Console.Write("|");
            System.Console.WriteLine();
            System.Console.WriteLine();
            printTrunkOfTreeRecursive(i_trunkLineIndex+1, i_trunkHeight, i_currentCharToPrint);
        }
    }
}
