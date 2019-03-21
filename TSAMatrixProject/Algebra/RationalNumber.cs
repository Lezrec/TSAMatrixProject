using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.Algebra {
    //will simplify matrix algebra hopefully
    public class RationalNumber {
        int numerator;
        int divisor;

        public static readonly RationalNumber Zero = new RationalNumber(0, 1);

        public static RationalNumber[] CrossMultiply(RationalNumber ob, RationalNumber oth)
        {
            RationalNumber[] ret = new RationalNumber[2];
            ret[0] = new RationalNumber(ob.numerator * oth.divisor, ob.divisor * oth.divisor, false);
            ret[1] = new RationalNumber(oth.numerator * ob.divisor, oth.divisor * ob.divisor, false);
            return ret;
        }

        public bool IsZero => numerator == 0;
        public bool IsOne => numerator == 1 && divisor == 1;
        public int Numerator => numerator;
        public int Denominator => divisor;

        public RationalNumber(int numerator, int divisor) {
            if (divisor == 0) throw new DivideByZeroException();
            this.numerator = numerator;
            this.divisor = divisor;
            Reduce();
        }

        public RationalNumber(int numerator, int divisor, bool reduce)
        {
            if (divisor == 0) throw new DivideByZeroException();
            this.numerator = numerator;
            this.divisor = divisor;
            if (reduce) Reduce();
        }

        public RationalNumber(int numerator)
        {
            this.numerator = numerator;
            divisor = 1;
        }

        public RationalNumber()
        {
            numerator = 0;
            divisor = 1;
        }

        public RationalNumber Negation() {
            RationalNumber ret = new RationalNumber(-numerator, divisor);
            return ret;
        }

        public RationalNumber Inverse() {
            RationalNumber ret = new RationalNumber(divisor, numerator);
            return ret;
        }

        //TODO: Test these
        public static RationalNumber operator +(RationalNumber a, RationalNumber b) {
            int aCross = a.numerator * b.divisor;
            int bCross = b.numerator * a.divisor;
            int lcm = LCM(a.divisor, b.divisor);
            //Console.WriteLine($"+op: {aCross}/{lcm} and {bCross}/{lcm}");
            return new RationalNumber(aCross + bCross, lcm);
            //ret.Reduce();
            
        } 

        public static RationalNumber operator -(RationalNumber a, RationalNumber b) {
            RationalNumber c = new RationalNumber(b.numerator, b.divisor);
            RationalNumber neg = c.Negation();
            return a + neg;
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b) {
            return new RationalNumber(a.numerator * b.numerator, a.divisor * b.divisor);
            
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b) {
            return a * b.Inverse();
        }

        //reduces to lowest term
        private void Reduce() {
            int gcf = GCF(numerator, divisor);
            if (gcf > 1) {
                numerator /= gcf;
                divisor /= gcf;
            }
            if (gcf == 0) divisor = 0;
        }

        internal static int LCM(int a, int b) {
            return (a * b) / GCF(a, b);
        }

        internal static int GCF(int a, int b) {
            // Everything divides 0  
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;
            if (a == 0 || b == 0)
                return 0;

            // base case 
            if (a == b)
                return a;

            // a is greater 
            if (a > b)
                return GCF(a - b, b);
            return GCF(a, b - a);
        }

        public override bool Equals(object obj) {
            if (obj is RationalNumber) {
                RationalNumber other = (RationalNumber)obj;
                other.Reduce();
                this.Reduce();
                return (this.divisor == other.divisor && this.numerator == other.numerator);
            }
            return false;
        }

        public override string ToString()
        {
            if (IsZero) return "0";
            if (divisor == 1) return $"{numerator}";
            return $"{numerator}/{divisor}";
        }

    }
}