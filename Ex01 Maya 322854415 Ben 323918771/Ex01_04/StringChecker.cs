using System;

namespace Ex01_04
{
    public class StringChecker
    {
        public static bool IsAllNumbers(string i_InputStr)
        {
            bool isAllNumbers = true;
            for(int i=0; i < i_InputStr.Length; i++) 
            {
                isAllNumbers = !char.IsDigit(i_InputStr[i]);   
            }

            return isAllNumbers;
        }
        public static bool IsAllLetters(string i_InputStr)
        {
            bool isAllLetters = true;
            for (int i = 0; i < i_InputStr.Length; i++)
            {
                isAllLetters = !char.IsLetter(i_InputStr[i]);
            }

            return isAllLetters;
        }
        public static bool IsPolindrom(string i_InputStr)
        {
            bool isPolindrom = true;

            if (i_InputStr.Length <= 1)
            {
                isPolindrom = true;
            }
            else if (i_InputStr[0] != i_InputStr[i_InputStr.Length - 1])
            {
                isPolindrom = false;
            }
            else
            {
                string smallerStr = i_InputStr.Substring(1, i_InputStr.Length - 2);
                isPolindrom = IsPolindrom(smallerStr);
            }

            return isPolindrom;
        }
    }
}
