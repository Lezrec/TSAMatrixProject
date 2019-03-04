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
            Console.WriteLine(m1.ToString());
            Console.Read();
        }

        
    }
}
