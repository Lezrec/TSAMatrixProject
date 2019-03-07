using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.Algebra {
    //will simplify matrix algebra hopefully
    public struct RationalNumber {
        int numerator;
        int divisor;

        public bool IsZero => numerator == 0;
        public bool IsOne => numerator == 1 && divisor == 1;

        public RationalNumber(int numerator, int divisor) {
            if (divisor == 0) throw new DivideByZeroException();
            this.numerator = numerator;
            this.divisor = divisor;
            Reduce();
        }

        public RationalNumber Negation() {
            RationalNumber ret = new RationalNumber(-numerator, -divisor);
            return ret;
        }

        public RationalNumber Inverse() {
            RationalNumber ret = new RationalNumber(divisor, numerator);
            return ret;
        }

        //TODO: Test these
        public static RationalNumber operator +(RationalNumber a, RationalNumber b) {
            int lcm = LCM(a.divisor, b.divisor);
            int mulA = lcm / a.divisor;
            int mulB = lcm / b.divisor;
            a.numerator *= mulA;
            a.divisor *= mulA;
            RationalNumber ret = new RationalNumber(a.numerator + b.numerator, lcm);
            ret.Reduce();
            return ret;
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b) {
            RationalNumber ret = a + b.Negation();
            return ret;
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b) {
            a.numerator *= b.divisor;
            b.numerator *= a.divisor;
            int nDiv = a.divisor * b.divisor;
            RationalNumber ret = new RationalNumber(a.numerator + b.numerator, nDiv);
            ret.Reduce();
            return ret;
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
        }

        private static int LCM(int a, int b) {
            return (a * b) / GCF(a, b);
        }

        private static int GCF(int a, int b) {
            // Everything divides 0  
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

    }
}
