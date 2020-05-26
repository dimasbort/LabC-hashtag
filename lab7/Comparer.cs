using System.Collections.Generic;

namespace z1
{
    class Comparer : IComparer<Rational>
    {
        public int Compare(Rational obj1, Rational obj2)
        {
            if (obj1.Chisl * obj2.Znam > obj2.Chisl * obj1.Znam)
            {
                return 1;
            }
            else if ((obj1.Chisl == obj2.Chisl) && (obj1.Znam == obj2.Znam))
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
