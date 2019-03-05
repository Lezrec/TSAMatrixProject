using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.Exceptions;
using TSAMatrixProject.ValueMatrices.Vectors;

namespace TSAMatrixProject.ValueMatrices {
    public partial class IntegerMatrix {

        public static IntegerMatrix Sum(IntegerMatrix obj1, IntegerMatrix obj2) {
            if (!SizeParity(obj1, obj2)) throw new ArgumentException("The matrices were not in the same dimension.");
            else {
                IntegerMatrix ret = new IntegerMatrix(obj1.RowSize, obj1.ColumnSize);
                ret.Add(obj1);
                ret.Add(obj2);
                return ret;
            }
        }
        
        public void Add(IntegerMatrix other) {
            for(int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    Replace(i, j, Get(i, j) + other.Get(i, j));
                }
            }
        }

        //TODO: Test this. Pretty sure it works?
        public IntegerMatrix Multiply(IntegerMatrix other) {
            if (!CanMultiply(other)) throw new MultiplicationDimensionMismatchException(); //todo
            else {
                IntegerMatrix ret = new IntegerMatrix(RowSize, other.ColumnSize);
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < other.ColumnSize; j++) {
                        int[] ro = GetRow(i).ToArray<int>();
                        int[] co = other.GetColumn(j).ToArray<int>();
                        IntegerRowVector v = new IntegerRowVector(ro);
                        IntegerColumnVector w = new IntegerColumnVector(co);
                        ret.Replace(i, j, VectorMath.DotProduct<int>(v, w));
                    }
                }
                return ret;
            
                
            }
        }

    }

    public partial class SquareIntegerMatrix {

        //minor = n-1 x n-1 matrix, for determinant first row is always excluded so only need column
        //eg col = 0 means the first minor, 0 row and 0 col excluded for a 3x3 gives a 2x2 with the bottom right minor
        //index starts at 0 btw
        //TODO: Test this.
        public SquareIntegerMatrix GetMinor(int col) {
            return (SquareIntegerMatrix)RemoveRow(0).RemoveColumn(col);
        }
    }
}
