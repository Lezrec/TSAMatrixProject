using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.Exceptions;

namespace TSAMatrixProject
{
    public abstract class Matrix<T> {

        public delegate bool MatrixPredicate(Matrix<T> matrix);
        public static MatrixPredicate SquarePredicate => (matrix) => {
            return matrix.col == matrix.row;
        };
        public static MatrixPredicate SingleRowPredicate => (matrix) => {
            return matrix.row == 1;
        };
        public static MatrixPredicate SingleColumnPredicate => (matrix) => {
            return matrix.col == 1;
        };
        public static MatrixPredicate DiagonalPredicate => (matrix) => {
            return matrix.IsDiagonal;
        };
        public static MatrixPredicate IdentityPredicate => (matrix) => {
            return matrix.IsIdentity;
        };



        private int row, col;
        private T[,] mRep;

        public Matrix(int row, int col) {
            if (row < 1 || col < 1) {
                throw new NullMatrixException("The size of the matrix is outside the acceptable bounds", row, col);
            }

            this.row = row;
            this.col = col;
            mRep = new T[row, col];
        }

        public Matrix(T[,] rep, MatrixPredicate predicate) {
            this.row = rep.GetLength(0);
            this.col = rep.GetLength(1);

            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
            if (row < 1 || col < 1) {
                throw new NullMatrixException("The size of the matrix is outside the acceptable bounds", row, col);
            }

            mRep = rep;
        }


        public int DF { get { return (row - 1) * (col - 1); } }
        public int RowSize { get { return row; } }
        public int ColumnSize { get { return col; } }
        public bool IsSquare { get { return row == col; } }
        public bool SingleColumn { get { return col == 1; } }
        public bool SingleRow { get { return row == 1; } }

        //these are abstract because these properties depend on the T properties
        public abstract bool IsDiagonal { get; }
        public abstract bool IsIdentity { get; }
        public abstract bool IsEmpty { get; }

        public static bool RowParity(Matrix<T> m1, Matrix<T> m2) {
            return m1.RowSize == m2.RowSize;
        }

        public static bool ColumnParity(Matrix<T> m1, Matrix<T> m2) {
            return m1.ColumnSize == m2.ColumnSize;
        }

        public static bool SizeParity(Matrix<T> m1, Matrix<T> m2) {
            return RowParity(m1, m2) && ColumnParity(m1, m2);
        }

        //abstract because of referencing in primitives vs objects
        public abstract T Replace(int row, int col, T obj);
        internal abstract T[,] ReplaceMatrix(T[,] obj);
        //abstract so i can get around abstract limitations, generates a matrix from a 2d array
        public abstract Matrix<T> Generate(T[,] input);


        public IEnumerable<T> GetRow(int col) {
            if (col < 0 || col >= this.col) {
                throw new IndexOutOfRangeException($"The specified range was out of bounds. Column Range = 0-{this.col-1}. Input = {col}");
            }

            for (int i = 0; i < row; i++) {
                yield return mRep[i, col];
            }
        }

        public IEnumerable<T> GetColumn(int row) {
            if (row < 0 || row >= this.row) {
                throw new IndexOutOfRangeException($"The specified range was out of bounds. Row Range = 0-{this.row - 1}. Input = {row}");
            }

            for (int i = 0; i < row; i++) {
                yield return mRep[row, i];
            }
        }
        //todo test
        public Matrix<T> AppendByRow(Matrix<T> other) {
            if (!RowParity(this, other)) {
                throw new InvalidOperationException("In order to append by row, the matrices must have the same amount of rows.");
            }

            T[,] appended = new T[row, col + other.col];

            for(int i = 0; i < row; i++) {

                for(int j = 0; j < col; j++) {
                    appended[i, j] = mRep[i, j];
                }

                for(int j = 0; j < other.col; j++) {
                    appended[i, col + j] = other.mRep[i, j];
                }
            }

            return Generate((appended));
        }


             
        //todo test
        public Matrix<T> AppendByColumn(Matrix<T> other) {
            if (!ColumnParity(this, other)) {
                throw new InvalidOperationException("In order to append by column, the matrices must have the same amount of columns.");
            }

            T[,] appended = new T[row + other.row, col];

            for (int i = 0; i < col; i++) {

                for (int j = 0; j < row; j++) {
                    appended[j, i] = mRep[j, i];
                }

                for (int j = 0; j < other.row; j++) {
                    appended[row + j, i] = other.mRep[j, i];
                }
            }

            return Generate((appended));
        }

        public T Get(int row, int col) {
            return mRep[row, col];
        }

        internal void ReplaceWithoutReturn(int row, int col, T obj) {
            mRep[row, col] = obj;
        }



        internal void ReplaceMatrixWithoutReturn(T[,] obj) {
            mRep = obj;
        }

        public override bool Equals(object obj) {
            if (!this.GetType().Equals(obj.GetType())) return false;
            else {
                Matrix<T> other = (Matrix<T>)obj;
                if (!SizeParity(this, other)) return false;
                for (int i = 0; i < row; i++) {
                    for (int j = 0; j <col; j++) {
                        if (!this.Get(i, j).Equals(other.Get(i, j))) return false;
                    }
                }
            }
            return true;
        }

        //TODO: determine the reference value properties of this
        public Matrix<T> GetTranspose() {
            T[,] vals = new T[col, row]; //row and col swap
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    vals[j, i] = mRep[i, j];
                }
            }
            return Generate(vals);
        }

    }
}
