using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.Exceptions;

namespace TSAMatrixProject.ValueMatrices.Vectors {

    public static class VectorMath {

        public static T DotProduct<T>(IVector<T> v, IVector<T> w) {
            return v.DotProduct(w);
        }
    }

    public interface IVector<T> {
        T DotProduct(IVector<T> other);
        T Get(int index);
        int Dimension { get; }
        //TODO: Determine other vector properties.
    }

    public partial class IntegerColumnVector : IntegerMatrix, IVector<int> {

        public int Dimension => RowSize;

        public IntegerColumnVector(int[,] rep, MatrixPredicate predicate) : base(rep, SingleColumnPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IntegerColumnVector(int size) : base(size, 1) {
        }

        public int DotProduct(IVector<int> other) {
            if (other.Dimension != Dimension) throw new MultiplicationDimensionMismatchException();
            else {
                int ret = 0;
                for (int i = 0; i < Dimension; i++) {
                    ret += Get(i) * other.Get(i);
                } 
                return ret;
            }
        }

        public int Get(int index) {
            return Get(index, 1);
        }
    }

    public partial class IntegerRowVector : IntegerMatrix, IVector<int> {

        public int Dimension => ColumnSize;

        public IntegerRowVector(int[,] rep, MatrixPredicate predicate) : base(rep, SingleRowPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IntegerRowVector(int size) : base(1, size) {
        }

        public int DotProduct(IVector<int> other) {
            if (other.Dimension != Dimension) throw new MultiplicationDimensionMismatchException();
            else {
                int ret = 0;
                for (int i = 0; i < Dimension; i++) {
                    ret += Get(i) * other.Get(i);
                }
                return ret;
            }
        }

        public int Get(int index) {
            return Get(1, index);
        }
    }

    public partial class DoubleColumnVector : DoubleMatrix, IVector<double> {

        public int Dimension => RowSize;

        public DoubleColumnVector(int size) : base(size, 1) {
        }

        public DoubleColumnVector(double[,] rep, MatrixPredicate predicate) : base(rep, SingleColumnPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        

        public double DotProduct(IVector<double> other) {
            if (other.Dimension != Dimension) throw new MultiplicationDimensionMismatchException();
            else {
                double ret = 0;
                for (int i = 0; i < Dimension; i++) {
                    ret += Get(i) * other.Get(i);
                }
                return ret;
            }
        }

        public double Get(int index) {
            return Get(index, 1);
        }
    }

    public partial class DoubleRowVector : DoubleMatrix, IVector<double> {

        public int Dimension => ColumnSize;

        public DoubleRowVector(int size) : base(1, size) {
        }

        public DoubleRowVector(double[,] rep, MatrixPredicate predicate) : base(rep, SingleRowPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public double DotProduct(IVector<double> other) {
            if (other.Dimension != Dimension) throw new MultiplicationDimensionMismatchException();
            else {
                double ret = 0;
                for (int i = 0; i < Dimension; i++) {
                    ret += Get(i) * other.Get(i);
                }
                return ret;
            }
        }

        public double Get(int index) {
            return Get(1, index);
        }
    }

    //todo decide whether to add column and row vectors for chars and bools
}
