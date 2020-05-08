using static System.Console;

namespace z1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational[] RNumbers = null;
            ArrayMaker(ref RNumbers);
            Show(RNumbers);
            Comparing(RNumbers);
        }

        public static void ArrayMaker(ref Rational[] RNumbers)
        {
            string StrOfNums;
            WriteLine("How many numbers should I create?");
            StrOfNums = ReadLine();
            int.TryParse((((string.IsNullOrEmpty(StrOfNums))|| (int.Parse(StrOfNums) <= 0)) ?
                "0" : StrOfNums), out int attempt);

            if (attempt <= 0)
            {
                Write("You are lying!");
                return;
            }

            int z = 1;
            RNumbers = new Rational[attempt];
            for (int i = 0; i < RNumbers.Length; i++)
            {
                string Str;
                int chisl, znam;

                while (true)
                {            
                    WriteLine("Enter numerator #"+z.ToString());
                    Str = ReadLine();
                    if ((string.IsNullOrEmpty(Str)) || (int.Parse(Str) < 0))
                    {
                        WriteLine("You are lying, try again please!\n");
                    }
                    else
                    {
                        chisl = int.Parse(Str);
                        break;
                    }
                }

                while (true)
                {
                    WriteLine("Enter denumerator #" + z.ToString());
                    Str = ReadLine();
                    if ((string.IsNullOrEmpty(Str))|| (int.Parse(Str) < 0))
                    {
                        WriteLine("You are lying, try again please!\n");
                    }
                    else
                    {
                        znam = int.Parse(Str);
                        break;
                    }
                }
                z++;
                RNumbers[i] = new Rational(chisl, znam);
                WriteLine("");
            }
        }     
        public static void Show(Rational[] RNumbers)
        {
            for (int i = 0; i < RNumbers.Length; i++)
            {
                Write($"{i + 1}) ");                
                WriteLine(RNumbers[i]._chislitel.ToString() + "/" + RNumbers[i]._znamenatel.ToString());               
                WriteLine((RNumbers[i]._chislitel / RNumbers[i]._znamenatel).ToString());
                WriteLine("");
            }
        }                      
        public static void Comparing(Rational[] RNumbers)
        {
            string Str;
            int srav1 = 0, srav2 = 0;


            WriteLine("What numbers should I compare? Enter their counts in array");

            while (true)
            {
                WriteLine("Enter first number to compare");
                Str = ReadLine();
                if ((string.IsNullOrEmpty(Str))
                    || (int.Parse(Str) < 0)
                    || int.Parse(Str) > RNumbers.Length)
                {
                    WriteLine("You are lying, try again please!\n");
                }
                else
                {
                    srav1 = int.Parse(Str);
                }

                WriteLine("Enter second number to compare");
                Str = ReadLine();
                if ((string.IsNullOrEmpty(Str))
                    || (int.Parse(Str) < 0)
                    || int.Parse(Str) > RNumbers.Length)
                {
                    WriteLine("You are lying, try again please!\n");
                }
                else
                {
                    srav2 = int.Parse(Str);
                    break;
                }
            }
 
            Comparer objComp = new Comparer();
            if (objComp.Compare(RNumbers[srav1], RNumbers[srav2]) == 0)
            {
                WriteLine("These numbers are equal!");
            }
            else if (objComp.Compare(RNumbers[srav1], RNumbers[srav2]) == 1)
            {
                WriteLine("The first number is bigger than second one");
            }
            else
            {
                WriteLine("The second number is bigger than first one");
            }
        }
    }
}
