using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.Algebra;
using TSAMatrixProject.Exceptions;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.ValueMatrices.Vectors;

namespace TSAMatrixProject.Algebra {

    public class RationalNumberMatrix : Matrix<RationalNumber> {

        public RationalNumberMatrix(int row, int col) : base(row, col) {
        }

        public RationalNumberMatrix(RationalNumber[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        //todo test this
        public override bool IsDiagonal { get {
                if (!IsSquare) return false;
                for( int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (!Get(i, j).IsZero && i != j) return false;
                    }
                }
                return true;
            } }

        public override bool IsIdentity { get {
                if (!IsDiagonal) return false;
                for(int i = 0; i < RowSize; i++) {
                    if (!Get(i, i).IsOne) return false;
                }
                return true;
            } }

        public override bool IsEmpty { get {
                for(int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (!Get(i, j).IsZero) return false;
                    }
                }
                return true;
            } }

        public override Matrix<RationalNumber> Generate(RationalNumber[,] input) {
            RationalNumberMatrix ret = new RationalNumberMatrix(input.GetLength(0), input.GetLength(1));
            for (int i = 0; i < input.GetLength(0); i++) {
                for (int j = 0; j < input.GetLength(1); j++) {
                    ret.Replace(i, j, input[i, j]);
                }
            }
            return ret;
        }

        public override RationalNumber Replace(int row, int col, RationalNumber obj) {
            RationalNumber ret = Get(row, col);
            ReplaceWithoutReturn(row, col, obj);
            return ret;
            
        }

        //TODO: test this.
        internal override RationalNumber[,] ReplaceMatrix(RationalNumber[,] obj) {
            RationalNumber[,] ret = new RationalNumber[RowSize, ColumnSize];
            for(int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    ret[i, j] = Get(i, j);
                    Replace(i, j, obj[i, j]);
                }
            }
            return ret;
        }
    }
}
