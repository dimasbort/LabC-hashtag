using System;

namespace z1
{
    class Student : Person
    {
        protected int[] _marks;
        protected string vys;
        public int Length { get; private set; }
        public enum Course
        {
            First=1,
            Second,
            Third,
            Fourth,
            Fifth,
            Magistrant
        }

        public string VYS
        {
            get
            {
                if (vys[0] == 'B') return vys;
                else return vys+" isn't belorussian";
            }
            set
            {
                if (value[0] == 'B') vys=value;
                else vys = 'B' + value;
            }
        }

        public Student(string name, byte age, string sex, int amount, string yniver) : base(name,age,sex)
        {
            _marks = new int[amount];
            Length = amount;
            VYS = yniver;
        }

        public Student(string name, int amount) : this(name, 18, "Unknown", amount, "BSUIR")
        {
            _marks = new int[amount];
            Length = amount;
        }

        public Student(int amount, string yniver) : this("Pasha", 18, "male", amount, yniver)
        {   _marks = new int[amount];
            Length = amount;
            VYS = yniver;
        }

        public Student() : this("Pasha", 18, "male", 3, "BSUIR")
        {        }

        public int this[int index]
        {
            get
            {
                if (index > 0 && index <= Length)
                    return _marks[index-1];
                else
                    return _marks[0];
            }
            set
            {
                if (index > 0 && index <= Length && value <= 10 && value >= 0)
                    _marks[index-1] = value;
                else
                    Console.WriteLine("incorrect input");
            }
        }

        public new virtual void Show()
        {
            Console.WriteLine($"Name: {Name}\nAge: {age.ToString()}\nSex: {sex}\nVYS: {VYS}");
        }

        public override void ShowMarks()
        {
            int i = 1;
            foreach (int mark in _marks)
            {
                Console.WriteLine($"{i}: {mark}");
                i++;
            }
        }
    }
}
