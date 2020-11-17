using System;

namespace z1
{
    class AgeComparer
    {
        public int Compare(Person ps1, Person ps2)
        {
            if (ps1.age > ps2.age) return 1;
            else
               if (ps1.age < ps2.age) return -1;
            else return 0;

        }
    }
}
