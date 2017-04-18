using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    
        public class MathOps
        {
            public decimal Add(decimal parm1, decimal parm2)
            {
                decimal localvar;
                localvar = parm1 + parm2;
                return localvar;
            }
            public decimal Subtract(decimal number1, decimal number2)
            {
                return number2 - number1;
            }
            public decimal Multiply(decimal number1, decimal number2)
            {
                return number1 * number2;
            }
            public decimal Divide(decimal number1, decimal number2)
            {
                return number1 / number2;
            }
            public void Divideref(int number1, int number2, ref int answer, ref int remainder)
            {
                answer = number1 / number2;
                remainder = number1 % number2;
            }
            public void Divide2(int number1, int number2, out int answer, out int remainder)
            {
                answer = number1 / number2;
                remainder = number1 % number2;
            }
            public DivideAnswer Divide3(int number1, int number2)
            {
                DivideAnswer answer = new DivideAnswer();
                answer.Value = number1 / number2;
                answer.Remainder = number1 % number2;
                return answer;
            }

        }
        public class DivideAnswer
        {
            public int Value;
            public int Remainder;
        }
    
}
