using System;
using System.Globalization;
using FakerLib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string reg = "";
            int count = 0;
            double errCount = 0;
            IFormatProvider formatter 
                = new NumberFormatInfo { NumberDecimalSeparator = "." };
            if (args.Length > 0)
            {
                if (args.Length >= 3)
                {
                    if (int.TryParse(args[1], out count) && double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out errCount)
                        && Int32.Parse(args[1]) >= 0 && double.Parse(args[2], formatter) >= 0)
                    {
                        
                        reg = args[0];
                        count = Int32.Parse(args[1]);
                        errCount = double.Parse(args[2], formatter);
                        double peace_errCount = errCount - Math.Floor(errCount);
                        Person person = new Person(reg, count, errCount, peace_errCount);

                        person.PersonGen();
                        person.PersonOutput();
                    }
                    else
                    {
                        Console.Error.WriteLine("\nERROR:   Invalid arguments passed");
                    }
                }
                else
                {
                    reg = args[0];
                    count = Int32.Parse(args[1]);
                    errCount = 0;
                    double peace_errCount = 0;
                    Person person = new Person(reg, count, errCount, peace_errCount);
                    person.PersonGen();
                    person.PersonOutput();
                }
            }
            else
            {
                Console.Error.WriteLine("\nERROR:   Programm need arguments.");
            }
        }
    }
}
