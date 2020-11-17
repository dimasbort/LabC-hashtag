using System;

namespace z1
{
    sealed class Seminarist : Student
    {
        public int Auditoriya { get; set; }
        private string patron;

        public string Patron
        {
            get
            {
                return patron;
            }
            set
            {
                if (value[0] == 'S' && value[1] == 't')
                    patron = value;
                else
                {
                    patron = "Unknown " + value;
                    throw new ArgumentException();
                }
            }
        }

        public Seminarist(int audit, string patrname): this ("Dima", 17, "male", 3, "MINDS", audit,patrname)
        {
            Auditoriya = audit;
            Patron = patrname;
        }
        
        public Seminarist(string name, byte age, string sex, int amount, string yniver,int audit,string patrname) : base(name, age, sex, amount, yniver)
        {
            Auditoriya = audit;
            Patron = patrname;
        }


    }
}
