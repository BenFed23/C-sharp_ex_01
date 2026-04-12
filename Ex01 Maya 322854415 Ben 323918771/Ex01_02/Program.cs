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
        public static void Main()
        {
            LetterTreeBuilder.PrintLetterTreeByNumOfLines(k_BeginnerLetterTreeRowCount);
        }
    }
}
