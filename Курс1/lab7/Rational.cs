using System;

namespace z1
{
    struct Rational : IComparable<Rational>, IEquatable<Rational>
    {
        private int _chislitel;
        private int _znamenatel;

        public int Chisl
        {
            get { return _chislitel; }
        }

        public int Znam
        {
            get { return _znamenatel; }            
        }        

        public Rational(int chislitel) : this(chislitel, 1) { }
        public Rational(int chislitel, int znamenatel)
        {
            if (znamenatel  == 0) throw new ArgumentNullException();
            _chislitel = chislitel;
            _znamenatel = znamenatel;
        }

        //реализация методов интерфейсов
        public int CompareTo(Rational sravnimChislo)
        {
            return Chisl.CompareTo(sravnimChislo);
        }

        public override bool Equals(object sravnimNumber)
        {
            return Equals(sravnimNumber);
        }

        public bool Equals(Rational sravnimNumber)
        {
            Rational RatNumberSravn = (Rational)sravnimNumber;

            return (Chisl == RatNumberSravn.Chisl &&
            Znam == RatNumberSravn.Znam);
        }

        //перекрытие
        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.Chisl * b.Znam + b.Chisl * a.Znam,
                    a.Znam * b.Znam);
        }

        public static Rational operator -(Rational a, Rational b)
        {
                return new Rational(a.Chisl * b.Znam - b.Chisl * a.Znam,
                    a.Znam * b.Znam);            
        }

        public static Rational operator *(Rational a, Rational b)
        {
                return new Rational(a.Chisl * b.Chisl,
                    a.Znam * b.Znam);            
        }

        public static Rational operator /(Rational a, Rational b)
        {            
                return new Rational(a.Chisl * b.Znam,
                    a.Znam * b.Chisl);            
        }

        public static bool operator >(Rational a, Rational b)
        {            
                return a.Chisl * b.Znam
                    > b.Chisl * a.Znam;            
        }

        public static bool operator <(Rational a, Rational b)
        {            
                return a.Chisl * b.Znam
                    < b.Chisl * a.Znam;
        }

        public static bool operator ==(Rational number1, Rational number2)
        {
            return number1.Equals(number2);
        }

        public static bool operator !=(Rational number1, Rational number2)
        {
            return !number1.Equals(number2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static explicit operator Rational(string number)
        {
            return Parse(number);
        }
        
        public static explicit operator string(Rational number)
        {
            return number.ToString();
        }

        public static implicit operator Rational(int number)
        {
            return new Rational(number);
        }

        public static explicit operator int(Rational number)
        {
            return Convert.ToInt32(number.Chisl / number.Znam);
        }

        public static explicit operator Rational(double doubleNum)
        {
            return new Rational(Convert.ToInt32(doubleNum * 100), 100);
        }

        public static explicit operator double(Rational number)
        {
            return number.Chisl / number.Znam;
        }

        //преобразуем в строку
        public override string ToString()
        {
            return (Chisl.ToString() + "/" + Znam.ToString());
        }

        //и наоборот
        public static Rational Parse(string RatNumStr)
        {            
                if (!string.IsNullOrEmpty(RatNumStr))
                {
                    if (RatNumStr.IndexOf('/') != -1)
                    {
                        string[] strnums = RatNumStr.Split('/');

                        for (int i = 0; i < strnums.Length; i++)
                        {
                            if (int.Parse(strnums[i]) <= 0 || string.IsNullOrEmpty(strnums[i]))
                            {
                                throw new FormatException("Invalid value parcing!");
                            }
                        }

                        return new Rational(int.Parse(strnums[0]),
                            int.Parse(strnums[1]));
                    }
                    else
                    {
                        double thisIn;

                        
                            int dop;
                            int thisOut;

                            thisIn = Convert.ToDouble(RatNumStr);

                            thisOut = Convert.ToInt32(Math.Floor(thisIn));
                            dop = Convert.ToInt32(Math.Round((thisIn - thisOut), 3) * 1000);

                            return new Rational((thisOut * 1000) + dop, 1000);
                        
                    }
                }
                else
                {
                    throw new Exception("Invalid value parcing!");
                }
                     
        }
    }
}

