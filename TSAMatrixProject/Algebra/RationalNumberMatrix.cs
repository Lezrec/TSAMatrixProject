using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.Algebra;
using TSAMatrixProject.Algebra.Vectors;
using TSAMatrixProject.Exceptions;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.ValueMatrices.Vectors;

namespace TSAMatrixProject.Algebra {

    public class RationalNumberMatrix : Matrix<RationalNumber> {

        public RationalNumberMatrix(int row, int col) : base(row, col) {
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    Replace(i, j, RationalNumber.Zero);
                }
            }
        }

        public RationalNumberMatrix(RationalNumber[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        public RationalNumberMatrix(RationalNumberRowVector[] rows) : base(rows.Length, rows[0].Dimension)
        { //todo build error case for rows of varying length
            for(int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    Replace(i, j, rows[i].Get(j));
                }
            }
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

        public new RationalNumberMatrix GenerateClone()
        {
            RationalNumberMatrix ret = new RationalNumberMatrix(RowSize, ColumnSize);
            for(int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    ret.Replace(i, j, new RationalNumber(Get(i, j).Numerator, Get(i, j).Denominator));
                }
            }
            return ret;
        }

        public RationalNumberRowVector ReplaceRow(int row, RationalNumberRowVector other)
        {

            //TODO: should they have to be the same size?
            RationalNumberRowVector ret = new RationalNumberRowVector(GetRow(row).ToArray<RationalNumber>());
            for(int i = 0; i < ColumnSize; i++)
            {
                Replace(row, i, other.Get(0, i));
            }
            return ret;
        }
    }
}
