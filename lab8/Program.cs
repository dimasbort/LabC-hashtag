using System;

namespace z1
{
    class Program
    {


        static void Main(string[] args)
        {
            string messagePS = "\n*Hello, Console!* New seminarist added to the data base.";

            Seminarist ya = new Seminarist("Dima", 17, "male", 10, "MINDA", 55, "St. Dimitriy Prilutskiy");
            ya.Mess += DisplayMessageAdvanced;
            ya.Mess += delegate ()
            {
                Console.WriteLine("\n*Hello, Console!* New seminarist added to the data base.");
            };

            ya.Mess += () => Console.WriteLine(messagePS);

            ya.Surname = "Levchuk";
            ya.Adress = "Brest";
            ya.CURS = Student.Course.First;

            try
            {
                int x;
                Console.WriteLine("Enter Dima's last mark: ");
                x = Int32.Parse(Console.ReadLine());
                ya[ya.Length - 1] = x; ;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wrong value entered");
                Console.ResetColor();
            }



            Student Pasha = new Student(10, "BSUIR");

            Pasha.Mess += DisplayMessageAdvanced;

            Pasha.Mess += delegate ()
            {
                Console.WriteLine("\nHello, Console! New student added to the data base.");
            };

            Pasha.Surname = "Krivetskiy";
            Pasha.Adress = "Dom";

            try
            {
                int x;
                Console.WriteLine("Enter Pasha's height: ");
                x = Int32.Parse(Console.ReadLine());
                Pasha.Height = x;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Wrong value entered");
                Console.ResetColor();
            }


            AgeComparer comparator = new AgeComparer();
            comparator.Compare(ya, Pasha);


            {
                ya.Mess -= DisplayMessageAdvanced;

                ya.Mess -= delegate ()
                {
                    Console.WriteLine("\n|CONSOLE MESSAGE| New seminarist added to the data base.");
                };

                Pasha.Mess -= DisplayMessageAdvanced;

                Pasha.Mess -= delegate ()
                {
                    Console.WriteLine("\n|CONSOLE MESSAGE| New student added to the data base.");
                };
            }
        }

           private static void DisplayMessageAdvanced()
           {
            Console.WriteLine("\n|CONSOLE MESSAGE| Data output is done.\n");
           }
    }
}
