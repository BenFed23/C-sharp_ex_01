using System;

namespace Ex01_04
{
    public class StringChecker
    {
       
        public static bool IsAllNumbers(string i_InputStr)
        {
            for(int i=0; i < i_InputStr.Length; i++) 
            {
                if (!char.IsDigit(i_InputStr[i]))
                {
                    return false; 
                }
            }
            return true;
        }
        public static bool IsAllLetters(string i_InputStr)
        {
            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if (!char.IsLetter(i_InputStr[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPolindrom(string i_InputStr)
        {
            if(i_InputStr.Length == 0)
            {  
                return true; 
            }
            else if (i_InputStr[0] != i_InputStr[i_InputStr .Length- 1])
            {
                return false;
            }
            else 
            {
                string smallerStr = i_InputStr.Substring(1, i_InputStr.Length - 2);
                return IsPolindrom(smallerStr);
            }


        }
    }
}
