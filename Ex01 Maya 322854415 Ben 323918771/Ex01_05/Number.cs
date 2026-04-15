
using System;
using System.Text;


namespace Ex01_05
{
    internal class Number
    {
        private string m_RepresentativeStr;
        private int m_RepresentativeNum;
        public Number(string i_UserInput)
        {
            m_RepresentativeStr = i_UserInput;
            int.TryParse(i_UserInput,out  m_RepresentativeNum);
        }
        private int getDigitAt(int i_Index)
        {
            return m_RepresentativeStr[i_Index] - '0';
        }
        public int BiggerThanUnitsDigit(out string o_DigitsList) 
        {
            StringBuilder listOfBiggerNums= new StringBuilder(); 
            int biggerThanCount = 0;
            int unitsDigit = m_RepresentativeNum % 10;

            for (int i = 0; i < m_RepresentativeStr.Length; i++)
            {
                int currentDigit = getDigitAt(i);
                if (currentDigit > unitsDigit)
                {
                    if (listOfBiggerNums.Length > 0) 
                    {
                        listOfBiggerNums.Append(",");
                    }

                    listOfBiggerNums.Append(m_RepresentativeStr[i]);
                    biggerThanCount++;
                }
            }

            if (listOfBiggerNums.Length > 0) 
            {
                o_DigitsList = listOfBiggerNums.ToString();
            }
            else 
            {
                o_DigitsList = "";
            }
           
            return biggerThanCount;
        }
        public int FindUnique()
        {
            int numOfUnique = 0;

            for (int i=0; i<m_RepresentativeStr.Length; i++)
            {
                bool wasAlreadyCounted = false;
                for (int j = 0; j <i; j++)
                {
                    if (m_RepresentativeStr[i] == m_RepresentativeStr[j])
                    {
                        wasAlreadyCounted = true;
                        break; 
                    }
                }
                if (!wasAlreadyCounted)
                {
                    numOfUnique++;
                }
            }

            return numOfUnique; 
        }
        public int GetMultMaxAndMinNum()
        {
            int max = getDigitAt(0);
            int min = getDigitAt(0);

            for (int i = 0; i < m_RepresentativeStr.Length; i++)
            {
                int currentDigit = getDigitAt(i);
                if (currentDigit > max)
                {
                    max = currentDigit;
                }
                if (currentDigit < min)
                {
                    min = currentDigit;
                }
            }

            return max * min;
        }
        public int DividedBy4() 
        {
            int dividedBy4Count = 0;

            for (int i = 0; i < m_RepresentativeStr.Length; i++)
            {
                int currentDig = getDigitAt(i);
                if (currentDig % 4 == 0) 
                {
                    dividedBy4Count++;
                }
            }

            return dividedBy4Count;
        }
    }
}
