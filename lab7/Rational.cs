using System;

namespace z1
{
    struct Rational : IComparable<Rational>, IEquatable<Rational>
    {
        public readonly int _chislitel;
        public readonly int _znamenatel;

        public Rational(int chislitel) : this(chislitel, 1) { }
        public Rational(int chislitel, int znamenatel)
        {
            _chislitel = chislitel;
            _znamenatel = znamenatel;
        }

        //реализация методов интерфейсов
        public int CompareTo(Rational sravnimChislo)
        {
            return _chislitel.CompareTo(sravnimChislo);
        }

        public override bool Equals(object sravnimNumber)
        {
            return Equals(sravnimNumber);
        }

        public bool Equals(Rational sravnimNumber)
        {
            Rational RatNumberSravn = (Rational)sravnimNumber;

            return (_chislitel == RatNumberSravn._chislitel &&
            _znamenatel == RatNumberSravn._znamenatel);
        }

        //перекрытие
        public static Rational operator +(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return new Rational(a._chislitel * b._znamenatel + b._znamenatel * a._znamenatel,
                    a._znamenatel * b._znamenatel);
            }
            else
            {
                return 0;
            }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return new Rational(a._chislitel * b._znamenatel - b._chislitel * a._znamenatel,
                    a._znamenatel * b._znamenatel);
            }
            else
            {
                return 0;
            }
        }

        public static Rational operator *(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return new Rational(a._chislitel * b._chislitel,
                    a._znamenatel * b._znamenatel);
            }
            else
            {
                return 0;
            }
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return new Rational(a._chislitel * b._znamenatel,
                    a._znamenatel * b._chislitel);
            }
            else
            {
                return 0;
            }
        }

        public static bool operator >(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return a._chislitel * b._znamenatel
                    > b._chislitel * a._znamenatel;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Rational a, Rational b)
        {
            if (a._znamenatel != 0 && b._znamenatel != 0)
            {
                return a._chislitel * b._znamenatel
                    < b._chislitel * a._znamenatel;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Rational number1, Rational number2)
        {
            return number1.Equals(number2);
        }

        public static bool operator !=(Rational number1, Rational number2)
        {
            return number1.Equals(number2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static implicit operator Rational(string number)
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
            return Convert.ToInt32(number._chislitel / number._znamenatel);
        }

        public static implicit operator Rational(double doubleNum)
        {
            return new Rational(Convert.ToInt32(doubleNum * 100), 100);
        }

        public static explicit operator double(Rational number)
        {
            return number._chislitel / number._znamenatel;
        }

        //преобразуем в строку
        public override string ToString()
        {
            return (_chislitel.ToString() + "/" + _znamenatel.ToString());
        }

        //и наоборот
        public static Rational Parse(string RatNumStr)
        {
            try
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

                        try
                        {
                            int dop;
                            int thisOut;

                            thisIn = Convert.ToDouble(RatNumStr);

                            thisOut = Convert.ToInt32(Math.Floor(thisIn));
                            dop = Convert.ToInt32(Math.Round((thisIn - thisOut), 3) * 1000);

                            return new Rational((thisOut * 1000) + dop, 1000);
                        }
                        catch (FormatException)
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid value parcing!");
                }
            }
            catch (FormatException)
            {
                return 0;
            }
        }
    }
}
