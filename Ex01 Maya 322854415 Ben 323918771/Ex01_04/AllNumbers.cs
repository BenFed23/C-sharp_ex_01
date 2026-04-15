using System;


namespace Ex01_04
{
    public class AllNumbers
    {
        private int m_RepresentativeNum;
        public AllNumbers(String i_UserStr)
        {
           int.TryParse(i_UserStr, out m_RepresentativeNum);
        }
        public bool IsDivideBy(int i_dividerNum)
        {
            bool isDivideBy = true;
            isDivideBy = m_RepresentativeNum % i_dividerNum != 0;
           
            return isDivideBy;
        }  
    }
}
