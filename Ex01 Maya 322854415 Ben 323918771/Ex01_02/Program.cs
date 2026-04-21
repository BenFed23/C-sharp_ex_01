using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    internal class Program
    {
        private const int k_BeginnerLetterTreeRowCount = 7;
        private const char k_StartChar = 'A';
        private const int k_StartRowIndex = 1;
        private const int k_TreeTrunkHeight = 2;
        private const int k_AmountOfLettersInTreeTrunk = 1;
        public static void Main()
        {
            PrintLetterTreeByNumOfLines(k_BeginnerLetterTreeRowCount);
        }

        public static void PrintLetterTreeByNumOfLines(int i_numOfLinesInTree)
        {
            int heightWithoutTreeTrunk = i_numOfLinesInTree - k_TreeTrunkHeight;
            char nextCharForTrunk = BuilderLetterTreeWithoutTreeTrunkRecursive(k_StartRowIndex, heightWithoutTreeTrunk, k_StartChar);
            PrintTrunkOfTreeRecursive(k_StartRowIndex, heightWithoutTreeTrunk, nextCharForTrunk);
        }

        private static char BuilderLetterTreeWithoutTreeTrunkRecursive(int i_currentRowNumber, int i_heightWithoutTreeTrunk, char i_currentCharToPrint)
        {
            if (i_currentRowNumber > i_heightWithoutTreeTrunk)
            {
                return i_currentCharToPrint;
            }

            StringBuilder lineBuilder = new StringBuilder();
            lineBuilder.Append(string.Format("{0}    ", i_currentRowNumber));
            AppendCharsRecursive(2 * (i_heightWithoutTreeTrunk - i_currentRowNumber), " ", lineBuilder);
            char nextCharToPrint = BuildLettersRecursive((2 * i_currentRowNumber) - 1, i_currentCharToPrint, lineBuilder);
            System.Console.WriteLine(lineBuilder.ToString());
            System.Console.WriteLine();

            return BuilderLetterTreeWithoutTreeTrunkRecursive(i_currentRowNumber + 1, i_heightWithoutTreeTrunk, nextCharToPrint);
        }

        private static char BuildLettersRecursive(int i_amountOfLettersInLine, char i_currentCharToPrint, StringBuilder i_LineBuilder)
        {
            if (i_amountOfLettersInLine <= 0)
            {
                return i_currentCharToPrint;
            }

            i_LineBuilder.Append(i_currentCharToPrint);
            if (i_amountOfLettersInLine > 1)
            {
                i_LineBuilder.Append(" ");
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

            return BuildLettersRecursive(i_amountOfLettersInLine - 1, nextCharToPrint, i_LineBuilder);
        }

        private static void AppendCharsRecursive(int i_amountOfcharsToPrint, string i_strToPrint, StringBuilder i_charStringBuilder)
        {
            if (i_amountOfcharsToPrint <= 0)
            {
                return;
            }

            i_charStringBuilder.Append(i_strToPrint);
            AppendCharsRecursive(i_amountOfcharsToPrint - 1, i_strToPrint, i_charStringBuilder);
        }

        private static void PrintTrunkOfTreeRecursive(int i_trunkLineIndex, int i_trunkHeight, char i_currentCharToPrint)
        {
            if (i_trunkLineIndex > k_TreeTrunkHeight)
            {
                return;
            }

            int currentRowNumber = i_trunkHeight + i_trunkLineIndex;
            StringBuilder trunkBuilder = new StringBuilder();
            trunkBuilder.Append(string.Format("{0}    ", currentRowNumber));
            AppendCharsRecursive(2 * (i_trunkHeight - 1) - 1, " ", trunkBuilder);
            trunkBuilder.Append("|");
            trunkBuilder.Append(i_currentCharToPrint);
            trunkBuilder.Append("|");
            System.Console.WriteLine(trunkBuilder.ToString());
            System.Console.WriteLine();
            PrintTrunkOfTreeRecursive(i_trunkLineIndex + 1, i_trunkHeight, i_currentCharToPrint);
        }
    }
}
