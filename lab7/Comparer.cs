using System.Collections.Generic;

namespace z1
{
    class Comparer : IComparer<Rational>
    {
        public int Compare(Rational obj1, Rational obj2)
        {
            if (obj1._chislitel * obj2._znamenatel > obj2._chislitel * obj1._znamenatel)
            {
                return 1;
            }
            else if ((obj1._chislitel == obj2._chislitel) && (obj1._znamenatel == obj2._znamenatel))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
