using System;

namespace z1
{
    class Student : Person, IAmStudent
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

        public event WriteInfa _Mess;
        public event WriteInfa Mess
        {
            add
            {
                _Mess += value;
                Console.WriteLine($"\nHello, Console! {value.Method.Name} added.");
            }
            remove
            {
                _Mess -= value;
                Console.WriteLine($"\nHello, Console! {value.Method.Name} removed.");
            }
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

        public Course CURS { get; set; }

        public Student(string name, byte age, string sex, int amount, string yniver) 
            : base(name,age,sex)
        {
            _marks = new int[amount];
            Length = amount;
            VYS = yniver;
        }

        public Student(string name, int amount) 
            : this(name, 18, "Unknown", amount, "BSUIR")
        {
            _marks = new int[amount];
            Length = amount;
        }

        public Student(int amount, string yniver) 
            : this("Pasha", 18, "male", amount, yniver)
        {   _marks = new int[amount];
            Length = amount;
            VYS = yniver;
        }

        public Student() 
            : this("Pasha", 18, "male", 3, "BSUIR")
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
                    _marks[index - 1] = value;
                else
                    throw new ArgumentException();
            }
        }

        public new virtual string Show()
        {
            _Mess?.Invoke();
            return ($"Name: {Name}\nAge: {age.ToString()}\nSex: {sex}\nVYS: {VYS}");
        }

        public override string ShowMarks()
        {
            _Mess?.Invoke();
            string ocenki = "";
            foreach (int mark in _marks)
                ocenki+=mark.ToString()+" ";
            return ocenki;
        }
    }
}
