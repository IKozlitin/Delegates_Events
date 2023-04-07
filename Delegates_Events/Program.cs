using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//синтаксис делегата
/*[модификатор] delegate тип_данных ИмяДелегата(параметры);*/
/*public delegate int IntDelegate(double d);
public delegate void VoidDelegate(int i);*/



namespace Delegates_Events
{
    public delegate double CalcDelegate(double x, double y);
    public class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mult(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            throw new DivideByZeroException();
        }
    }

    public delegate T AddDelegate<T>(T x, T y);
    public class ExampleClass
    {
        public int AddInt(int x, int y)
        {
            return x + y;
        }
        public double AddDouble(double x, double y)
        {
            return x + y;
        }
        public static char AddChar(char x, char y)
        {
            return (char)(x + y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExampleClass example = new ExampleClass();
            AddDelegate<int> delInt = example.AddInt;
            WriteLine($"Sum of integers: {delInt(45, 24)}");

            AddDelegate<double> delDouble = example.AddDouble;
            WriteLine($"Sum of double numbers: {delDouble(3.45, 77.24)}");

            AddDelegate<char> delChar = ExampleClass.AddChar;
            WriteLine($"Sum of characters: {delChar('S', 'D')}");


            Calculator calc = new Calculator();
            CalcDelegate delAll = calc.Add;
            delAll += Calculator.Sub;
            delAll += calc.Mult;
            delAll += calc.Div;

            foreach (CalcDelegate item in delAll.GetInvocationList())
            {
                WriteLine($"Result: {item(6.3, 3.7)}");
            }

            /*Calculator calc = new Calculator();
            Write("Enter an expression: ");
            string expression = ReadLine();
            char sign = ' ';
            foreach(char item in expression)
            {
                if(item == '+' || item =='-' || item == '*' || item == '/')
                {
                    sign = item;
                    break;
                }
            }
            string[] numbers = expression.Split(sign);
            CalcDelegate del = null;
            switch(sign)
            {
                case '+':
                    del = new CalcDelegate(calc.Add);
                    break;
                case '-':
                    del = new CalcDelegate(Calculator.Sub);
                    break;
                case '*':
                    del = calc.Mult;
                    break;
                case '/':
                    del = calc.Div;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            WriteLine($"Result: {del(double.Parse(numbers[0]), double.Parse(numbers[1]))}");
            CalcDelegate delAll = null;
            CalcDelegate delDiv = calc.Div;
            delAll += delDiv;
            delAll -= delDiv;*/


        }
    }
}
