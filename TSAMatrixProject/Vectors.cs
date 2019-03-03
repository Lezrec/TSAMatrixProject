using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.ValueMatrices.Vectors {

    public partial class IntegerColumnVector : IntegerMatrix {

        public IntegerColumnVector(int[,] rep, MatrixPredicate predicate) : base(rep, SingleColumnPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IntegerColumnVector(int size) : base(size, 1) {
        }
    }

    public partial class IntegerRowVector : IntegerMatrix {

        public IntegerRowVector(int[,] rep, MatrixPredicate predicate) : base(rep, SingleRowPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IntegerRowVector(int size) : base(1, size) {
        }
    }

    public partial class DoubleColumnVector : DoubleMatrix {

        public DoubleColumnVector(int size) : base(size, 1) {
        }

        public DoubleColumnVector(double[,] rep, MatrixPredicate predicate) : base(rep, SingleColumnPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }
    }

    public partial class DoubleRowVector : DoubleMatrix {

        public DoubleRowVector(int size) : base(1, size) {
        }

        public DoubleRowVector(double[,] rep, MatrixPredicate predicate) : base(rep, SingleRowPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }
    }

    //todo decide whether to add column and row vectors for chars and bools
}
