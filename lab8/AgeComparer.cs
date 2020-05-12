using System;

namespace z1
{
    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person ps1, Person ps2)
        {
            if (ps1.age > ps2.age)
            {
                Console.WriteLine($"\nPerson {ps1.Name} is older, than {ps2.Name}.");
                return 1;
            }
            else
            {
                Console.WriteLine($"\nPerson {ps1.Name} is younger, than {ps2.Name}.");
                return 0;
            }
        }
    }
}
