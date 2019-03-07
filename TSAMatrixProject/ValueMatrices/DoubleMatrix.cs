using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.Exceptions;
using TSAMatrixProject.ValueMatrices.Vectors;

namespace TSAMatrixProject.ValueMatrices {

    public partial class DoubleMatrix {

        public static DoubleMatrix Sum(DoubleMatrix obj1, DoubleMatrix obj2) {
            if (!SizeParity(obj1, obj2)) throw new ArgumentException("The matrices were not in the same dimension.");
            else {
                DoubleMatrix ret = new DoubleMatrix(obj1.RowSize, obj1.ColumnSize);
                ret.Add(obj1);
                ret.Add(obj2);
                return ret;
            }
        }

        public void Add(DoubleMatrix other) {
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    Replace(i, j, Get(i, j) + other.Get(i, j));
                }
            }
        }

        //TODO: Test this. Pretty sure it works?
        public DoubleMatrix Multiply(DoubleMatrix other) {
            if (!CanMultiply(other)) throw new MultiplicationDimensionMismatchException(); //todo
            else {
                DoubleMatrix ret = new DoubleMatrix(RowSize, other.ColumnSize);
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < other.ColumnSize; j++) {
                        double[] ro = GetRow(i).ToArray<double>();
                        double[] co = other.GetColumn(j).ToArray<double>();
                        DoubleRowVector v = new DoubleRowVector(ro);
                        DoubleColumnVector w = new DoubleColumnVector(co);
                        ret.Replace(i, j, VectorMath.DotProduct<double>(v, w));
                    }
                }
                return ret;


            }
        }

        //TODO: classify multiplications to have the products be as explicit as possible.
        //im sure theres a better way to do this lol
        public SquareDoubleMatrix Multiply(SquareDoubleMatrix other) {
            DoubleMatrix product = Multiply(other as DoubleMatrix);
            SquareDoubleMatrix ret = new SquareDoubleMatrix(other.RowSize);
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < RowSize; j++) {
                    ret.Replace(i, j, product.Get(i, j));
                }
            }
            return ret;

        }

        public SquareDoubleMatrix TrySquareConversion() {
            if (IsSquare) {
                SquareDoubleMatrix ret = new SquareDoubleMatrix(RowSize);
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < RowSize; j++) {
                        ret.Replace(i, j, this.Get(i, j));
                    }
                }
                return ret;
            }
            else throw new MatrixTypeMismatchException();
        }
    }
}
