using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        private const int k_BeginnerLetterTreeRowCount = 7;
        private const char k_StartChar = 'A';
        private const int k_StartRowIndex = 1;
        private const int k_TreeTrunkHeight = 2;

        public static void Main()
        {
            PrintLetterTreeByNumOfLines(k_BeginnerLetterTreeRowCount);
        }

        public static void PrintLetterTreeByNumOfLines(int i_NumOfLinesInTree)
        {
            int heightWithoutTreeTrunk = i_NumOfLinesInTree - k_TreeTrunkHeight;
            char nextCharForTrunk = BuilderLetterTreeWithoutTreeTrunkRecursive(k_StartRowIndex, heightWithoutTreeTrunk, k_StartChar);

            printTrunkOfTreeRecursive(k_StartRowIndex, heightWithoutTreeTrunk, nextCharForTrunk);
        }

        public static char BuilderLetterTreeWithoutTreeTrunkRecursive(int i_CurrentRowNumber, int i_HeightWithoutTreeTrunk, char i_CurrentCharToPrint)
        {
            char nextCharToPrintAfterThisRow;

            if (i_CurrentRowNumber > i_HeightWithoutTreeTrunk)
            {
                nextCharToPrintAfterThisRow = i_CurrentCharToPrint;
            }
            else
            {
                StringBuilder lineBuilder = new StringBuilder();
                lineBuilder.Append(string.Format("{0}    ", i_CurrentRowNumber));
                appendCharsRecursive(2 * (i_HeightWithoutTreeTrunk - i_CurrentRowNumber), " ", lineBuilder);
                char nextCharToPrint = buildLettersRecursive((2 * i_CurrentRowNumber) - 1, i_CurrentCharToPrint, lineBuilder);
                System.Console.WriteLine(lineBuilder.ToString());
                System.Console.WriteLine();
                nextCharToPrintAfterThisRow = BuilderLetterTreeWithoutTreeTrunkRecursive(i_CurrentRowNumber + 1, i_HeightWithoutTreeTrunk, nextCharToPrint);
            }

            return nextCharToPrintAfterThisRow;
        }

        private static char buildLettersRecursive(int i_AmountOfLettersInLine, char i_CurrentCharToPrint, StringBuilder i_LineBuilder)
        {
            char resultChar;

            if (i_AmountOfLettersInLine <= 0)
            {
                resultChar = i_CurrentCharToPrint;
            }
            else
            {
                i_LineBuilder.Append(i_CurrentCharToPrint);
                if (i_AmountOfLettersInLine > 1)
                {
                    i_LineBuilder.Append(" ");
                }

                char nextChar = (i_CurrentCharToPrint == 'Z') ? 'A' : (char)(i_CurrentCharToPrint + 1);
                resultChar = buildLettersRecursive(i_AmountOfLettersInLine - 1, nextChar, i_LineBuilder); ;
            }

            return resultChar;
        }

        private static void appendCharsRecursive(int i_AmountOfcharsToPrint, string i_StrToPrint, StringBuilder i_CharStringBuilder)
        {
            if(i_AmountOfcharsToPrint <= 0)
            {
                return;
            }

            i_CharStringBuilder.Append(i_StrToPrint);
            appendCharsRecursive(i_AmountOfcharsToPrint - 1, i_StrToPrint, i_CharStringBuilder);
        }

        private static void printTrunkOfTreeRecursive(int i_TrunkLineIndex, int i_TrunkHeight, char i_CurrentCharToPrint)
        {
            if(i_TrunkLineIndex > k_TreeTrunkHeight)
            {
                return;
            }

            int currentRowNumber = i_TrunkHeight + i_TrunkLineIndex;
            StringBuilder trunkBuilder = new StringBuilder();
            trunkBuilder.Append(string.Format("{0}    ", currentRowNumber));
            appendCharsRecursive(2 * (i_TrunkHeight - 1) - 1, " ", trunkBuilder);
            trunkBuilder.Append("|");
            trunkBuilder.Append(i_CurrentCharToPrint);
            trunkBuilder.Append("|");
            System.Console.WriteLine(trunkBuilder.ToString());
            System.Console.WriteLine();
            printTrunkOfTreeRecursive(i_TrunkLineIndex + 1, i_TrunkHeight, i_CurrentCharToPrint);
        }
    }
}
