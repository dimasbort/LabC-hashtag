using System;

namespace z1
{
    class Program
    {
        public static byte Input()
        {
            string number = Console.ReadLine();

            if (!byte.TryParse(number, out byte x))
            {
                Console.WriteLine("Incorrect input. Please enter number");
                return Input();
            }
            else
            {
                return x;
            }
        }

        public static Seminarist[] CreateGroup()
        {
            Console.WriteLine("Enter amount of seminarists: ");

            int amount = Input();

            Seminarist[] group = new Seminarist[amount];

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Enter info about {(i + 1).ToString()} seminarist:(name, age, sex, amount of marks, VYS, auditoria, patron)");
                group[i] = new Seminarist(Console.ReadLine(), Input(), Console.ReadLine(), Input(), Console.ReadLine(), Input(), Console.ReadLine());
                Console.Clear();
            }

            Console.Clear();

            return group;
        }

        public static void GetInfo(Seminarist[] people)
        {
            Console.WriteLine("Info about all: \n");

            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Seminarist {(i + 1).ToString()}: {people[i].Name}, {people[i].Age.ToString()}, {people[i].Sex}, {people[i].VYS}, {people[i].Auditoriya.ToString()}, {people[i].Patron}\n");
            }
        }
        static void Main(string[] args)
        {
            /*var Dima = new Student(3, "SUIR");
            Console.WriteLine(Dima.VYS);
            Dima.Name = "Dima";
            Console.WriteLine(Dima.Name);
            Dima.Sex = "female";
            Dima.Show();
            Person You = new Student(3, "SU");
            You.Show();
            Dima[3] = 5;
            Console.WriteLine(Dima[3]);
            Dima.ShowMarks();
            Console.WriteLine((int)Student.Course.Second);*/
            while (true)
            {
                Seminarist[] people = CreateGroup();

                GetInfo(people);

                Console.WriteLine("Continue?");

                if (Console.ReadLine() == "yes")
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }
        }
    }
}
