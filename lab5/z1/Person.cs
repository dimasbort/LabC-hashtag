using System;

namespace z1
{
    abstract class Person
    {
        protected byte age;

        protected string sex;

        public string Name { get; set; }

        public Person() : this("Unknown", 0, "Unknown")
        { }

        public Person(string name) : this(name, 0, "Unknown")
        { }

        public Person(string name, byte age) : this(name, age, "Unknown")
        { }

        public Person(string name, byte age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public string Sex
        {
            set
            {
                if (Name == "Dima" && value == "female")
                    Console.WriteLine("You are lying");
                else
                if (value == "male" || value == "female")
                    sex = value;
                else
                    sex = "Unknown";
            }

            get { return sex; }
        }

        public byte Age
        {
            set
            {
                if (value >= 1 && value <= 100)
                    age = value;
                else
                    age = 0;
            }

            get { return age; }
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}\nAge: {age.ToString()}\nSex: {sex}");
        }

        static Random rnd = new Random();

        public static void CreateID()
        {
            Console.WriteLine($"Person's unique id - {rnd.Next(1000, 10000).ToString()}");
        }

        public abstract void ShowMarks();
    }
}
