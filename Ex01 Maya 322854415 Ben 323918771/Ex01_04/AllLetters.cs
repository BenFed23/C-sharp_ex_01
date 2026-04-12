using System;
using System.Text;


namespace Ex01_04
{
    public class AllLetters
    {
        private string m_RepresentativeStr;
        public  AllLetters(String i_UserStr)
        {
            m_RepresentativeStr = i_UserStr;
        }
        public bool IsDescendingOrder() 
        {
            bool isDescending = true;
            for (int i = 1; i < m_RepresentativeStr.Length; i++) 
            {
                char firstCharacter=char.ToLower(m_RepresentativeStr[i-1]);
                char secondCharacter = char.ToLower(m_RepresentativeStr[i]);
                if (firstCharacter-secondCharacter < 0)
                {
                    isDescending = false;
                }
            }

            return isDescending;
        }
        public int UppercaseCount()
        {
            int uppercaseCounter = 0;
            for(int i = 0; i < m_RepresentativeStr.Length; i++)
            {
                if (char.IsUpper(m_RepresentativeStr[i])) 
                {
                    uppercaseCounter++;
                }
            }

           return uppercaseCounter;
        }
    }
}
