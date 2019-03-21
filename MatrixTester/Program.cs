using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.Algebra;
using TSAMatrixProject.Algebra.Vectors;
using TSAMatrixProject.ValueMatrices.Vectors;

namespace MatrixTester {
    public static class Program {

        public static void Main(string[] args) {
            Random rand = new Random();
            IntegerMatrix m1 = new IntegerMatrix(2, 3);
            m1.Replace(1, 1, 5);
            Console.WriteLine(m1.ToString());
            IntegerMatrix m2 = new IntegerMatrix(2, 3);
            m2.Replace(0, 2, 15);
            IntegerMatrix m3 = (IntegerMatrix)m1.AppendByRow(m2);
            IntegerMatrix m4 = (IntegerMatrix)m1.AppendByColumn(m2);
            Console.WriteLine(m3.ToString());
            Console.WriteLine(m4.ToString());
            SquareIntegerMatrix sq1 = new SquareIntegerMatrix(3);
            SquareIntegerMatrix sq2 = new SquareIntegerMatrix(3);
            for(int i = 0; i < 3; i++) {
                for(int j = 0; j < 3; j++) {
                    sq1.Replace(i, j, rand.Next(0, 10));
                    sq2.Replace(i, j, rand.Next(0, 10));
                }
            }
            Console.WriteLine(sq1.ToString());
            Console.WriteLine(sq2.ToString());
            SquareIntegerMatrix prod1 = sq1.Multiply(sq2);
            Console.WriteLine(prod1.ToString());
            IntegerMatrix minor1 = prod1.GetMinor(0);
            IntegerMatrix minor2 = prod1.GetMinor(1);
            IntegerMatrix minor3 = prod1.GetMinor(2);
            Console.WriteLine(minor1);
            Console.WriteLine(minor2);
            Console.WriteLine(minor3);
            TestAlgebra();
            Console.Read();
        }

        public static void TestAlgebra() {
            RationalNumberMatrix rat1 = new RationalNumberMatrix(2, 2);
            rat1.Replace(0, 0, new RationalNumber(3, 4));
            rat1.Replace(0, 1, new RationalNumber(4, 3));
            rat1.Replace(1, 0, new RationalNumber(2, 5));
            rat1.Replace(1, 1, new RationalNumber(1, 7));
            RationalNumberColumnVector col1 = new RationalNumberColumnVector(2);
            col1.Replace(0, 0, new RationalNumber(1, 1));
            col1.Replace(1, 0, new RationalNumber(1, 2));
            Console.WriteLine(rat1.ToString());
            AugmentedMatrix aug1 = new AugmentedMatrix(rat1, col1);
            Console.WriteLine(aug1.ToString());
            RationalNumber r1 = new RationalNumber(3, 4);
            RationalNumber r2 = new RationalNumber(5, 6);
            RationalNumber[] crosses = RationalNumber.CrossMultiply(r1, r2);
            foreach(RationalNumber ra in crosses)
            {
                //Console.WriteLine(ra);
            }
            //RationalNumberRowVector toRow = aug1.SolveRow(0, 1, 1);
            //Console.WriteLine(toRow);
            //AugmentedMatrix aug2 = aug1.GaussMatrix();
            //Console.WriteLine(aug2);
            RationalNumber[] rary1 = { new RationalNumber(9), new RationalNumber(3), new RationalNumber(4)};
            RationalNumber[] rary2 = { new RationalNumber(4), new RationalNumber(3), new RationalNumber(4) };
            RationalNumber[] rary3 = { new RationalNumber(1), new RationalNumber(1), new RationalNumber(1) };
            RationalNumber[] rcol1 = { new RationalNumber(7), new RationalNumber(8), new RationalNumber(3) };
            RationalNumberRowVector rowv1 = new RationalNumberRowVector(rary1);
            RationalNumberRowVector rowv2 = new RationalNumberRowVector(rary2);
            RationalNumberRowVector rowv3 = new RationalNumberRowVector(rary3);
            RationalNumberColumnVector colv1 = new RationalNumberColumnVector(rcol1);
            RationalNumberMatrix asdf = new RationalNumberMatrix(new RationalNumberRowVector[] { rowv1, rowv2, rowv3 });
            AugmentedMatrix aug3 = new AugmentedMatrix(asdf, colv1);
            AugmentedMatrix aug3Gauss = aug3.GaussMatrix();
            Console.WriteLine(aug3);
            Console.WriteLine(aug3Gauss);

        }

        
    }
}
