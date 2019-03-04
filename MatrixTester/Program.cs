using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.ValueMatrices;

namespace MatrixTester {
    public static class Program {

        public static void Main(string[] args) {
            IntegerMatrix m1 = new IntegerMatrix(2, 3);
            m1.Replace(1, 1, 5);
            Console.WriteLine(m1.ToString());
            IntegerMatrix m2 = new IntegerMatrix(2, 3);
            m2.Replace(0, 2, 15);
            IntegerMatrix m3 = (IntegerMatrix)m1.AppendByRow(m2);
            IntegerMatrix m4 = (IntegerMatrix)m1.AppendByColumn(m2);
            Console.WriteLine(m3.ToString());
            Console.WriteLine(m4.ToString());
            Console.Read();
        }

        
    }
}
