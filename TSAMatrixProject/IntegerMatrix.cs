using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
