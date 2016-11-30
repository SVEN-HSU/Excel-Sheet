//https://leetcode.com/problems/excel-sheet-column-number/
//Accepted
//https://leetcode.com/problems/excel-sheet-column-title/
//Accepted
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Sheet_Column_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //Console.WriteLine(Convert.ToInt32('A'));
            //Console.WriteLine(Convert.ToInt32('Z'));
            //p.TitleToNumber("ZZ");
            p.ConvertToTitle(1000000001);
            Console.Read();
        }

        public int TitleToNumber(string s)
        {
            // revert the raw string: ABCDE -> EDCBA
            // result = E*1 + D*26 + C*26^2 + B*26^3 + A*26^4 ...

            char[] _s = s.ToCharArray();

            int tmp = 0, result = 0;

            for (int i = _s.Length - 1; i > -1; i--)
            {
                result += (Convert.ToInt32(_s[i]) - 64) * IntPow(26, tmp);
                tmp++;
            }

            Console.WriteLine("result=" + result);
            return result;
        }

        public string ConvertToTitle(int n)
        {
            /* Hint:
             * how do you convert a value 12345 to (10000 + 2000 + 300 + 40 +5)
             * 12345 = 1*10000 + 2*1000 + 3*100 + 4*10 + 5
             */

            string result = "";
            long _n = Convert.ToInt64(n);   // test cases contains very large number ...
            long p = 26;
            long c = 0;
            int i = 0;

            while (_n > 0)
            {
                //Console.WriteLine("p= " + p + ", i=" + i);
                c = _n % p;

                if (c == 0)
                {
                    // modifier to 'Z'
                    c = p;
                }

                //Console.WriteLine("c= " + c );

                // extract the char. ex: extract 'C' from "ABCDE" -> C * (26^2) 
                result += Convert.ToChar((c / IntPow(26, i)) + 64);
                
                //Console.WriteLine("g=" + Convert.ToChar((c / IntPow(26, i)) + 64));

                _n = _n - c;
                
                //Console.WriteLine("n= " + n+"\n");
                p *= 26;
                i++;
            }

            // reverse the string.
            result = new string(result.Reverse().ToArray());
            Console.WriteLine("result = " + result);
            return result;
        }

        public int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }
}
