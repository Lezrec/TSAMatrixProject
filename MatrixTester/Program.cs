using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.Algebra;
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
            SquareDoubleMatrix sdm = new SquareDoubleMatrix(2);
            sdm.Replace(0, 0, 2);
            sdm.Replace(0, 1, 5);
            sdm.Replace(1, 0, 9);
            sdm.Replace(1, 1, 4);
            DoubleColumnVector colv = new DoubleColumnVector(new double[] { 2.5, 4 });
            AugmentedMatrix aug = new AugmentedMatrix(sdm, colv);
            Console.WriteLine(aug.ToString());
        }

        
    }
}
