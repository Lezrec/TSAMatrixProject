using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.ValueMatrices {

    //valuetypes = chars, ints, floating pts, and bools
    #region INTEGERS


    public partial class IntegerMatrix : Matrix<int> {


        public IntegerMatrix(int[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        public IntegerMatrix(int row, int col) : base(row, col) {
        }

        public override bool IsDiagonal { get{
                if (!IsSquare) return false;
                else {
                    for(int i = 0; i < RowSize; i++) {
                        for (int j = 0; j < ColumnSize; j++) {
                            if (i != j && Get(i, j) != 0) return false;
                        }
                    }
                    return true;
                }
            }
        }

        public override bool IsIdentity { get {
                if (!IsDiagonal) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        if (Get(i, i) != 1) return false;
                    }
                }
                return true;
            }
        }

        public override bool IsEmpty { get {
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (Get(i, j) != 0) return false;
                    }
                }
                return true;
            }
        }

        public override int Replace(int row, int col, int obj) {
            int ret = Get(row, col);
            ReplaceWithoutReturn(row, col, obj);
            return ret;
        }

        public override Matrix<int> Generate(int[,] input) {
            return new IntegerMatrix(input, (matrix) => true);
        }

        internal override int[,] ReplaceMatrix(int[,] obj) {
            int[,] ret = new int[RowSize, ColumnSize];
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    ret[i, j] = Get(i, j);
                }
            }
            ReplaceMatrixWithoutReturn(obj);
            return ret;
        }
    }
    #region OUTSIDE IMPLEMENTATION

    //TODO: Override equals methods for diagonal matrices to improve algorithmic efficiency

    public partial class SquareIntegerMatrix : IntegerMatrix {
        internal SquareIntegerMatrix(int[,] rep, MatrixPredicate predicate) : base(rep, SquarePredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }
        
        public SquareIntegerMatrix(int size) : base(size, size) {

        }
    }

    public partial class DiagonalIntegerMatrix : SquareIntegerMatrix {
        internal DiagonalIntegerMatrix(int[,] rep, MatrixPredicate predicate) : base(rep, DiagonalPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public DiagonalIntegerMatrix(int size) : base(size) {
        }
    }

    public partial class IdentityIntegerMatrix : DiagonalIntegerMatrix {
        internal IdentityIntegerMatrix(int[,] rep, MatrixPredicate predicate) : base(rep, IdentityPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IdentityIntegerMatrix(int size) : base(size) {
            for(int i = 0; i < size; i++) {
                Replace(i, i, 1);
            }
        }
    }
    #endregion
    #endregion

    #region DOUBLES
    public partial class DoubleMatrix : Matrix<double> {

        public DoubleMatrix(int row, int col) : base(row, col) {
        }

        public DoubleMatrix(double[,] rep, MatrixPredicate predicate) : base(rep, predicate) {

        }

        public override bool IsDiagonal {
            get {
                if (!IsSquare) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        for (int j = 0; j < ColumnSize; j++) {
                            if (i != j && Get(i, j) != 0) return false;
                        }
                    }
                    return true;
                }
            }
        }

        public override bool IsIdentity {
            get {
                if (!IsDiagonal) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        if (Get(i, i) != 1) return false;
                    }
                }
                return true;
            }
        }

        public override bool IsEmpty {
            get {
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (Get(i, j) != 0) return false;
                    }
                }
                return true;
            }
        }

        public override double Replace(int row, int col, double obj) {
            double ret = Get(row, col);
            ReplaceWithoutReturn(row, col, obj);
            return ret;
        }

        public override Matrix<double> Generate(double[,] input) {
            return new DoubleMatrix(input, (matrix) => true);
        }

        internal override double[,] ReplaceMatrix(double[,] obj) {
            double[,] ret = new double[RowSize, ColumnSize];
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    ret[i, j] = Get(i, j);
                }
            }
            ReplaceMatrixWithoutReturn(obj);
            return ret;
        }
    }

    #region OUTSIDE IMPLEMENTATION
    public partial class SquareDoubleMatrix : DoubleMatrix {
        internal SquareDoubleMatrix(double[,] rep, MatrixPredicate predicate) : base(rep, SquarePredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public SquareDoubleMatrix(int size) : base(size, size) {
        }
    }

    public partial class DiagonalDoubleMatrix : SquareDoubleMatrix {
        internal DiagonalDoubleMatrix(double[,] rep, MatrixPredicate predicate) : base(rep, DiagonalPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public DiagonalDoubleMatrix(int size) : base(size) {
        }
    }

    public partial class IdentityDoubleMatrix : DiagonalDoubleMatrix {
        internal IdentityDoubleMatrix(double[,] rep, MatrixPredicate predicate) : base(rep, IdentityPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IdentityDoubleMatrix(int size) : base(size) {
            for(int i = 0; i < size; i++) {
                Replace(i, i, 1);
            }
        }
    }
    #endregion
    #endregion

    #region BOOLEANS
    public partial class BoolMatrix : Matrix<bool> {
        public BoolMatrix(int row, int col) : base(row, col) {
        }

        public BoolMatrix(bool[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        public override bool IsDiagonal {
            get {
                if (!IsSquare) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        for (int j = 0; j < ColumnSize; j++) {
                            if (i != j && Get(i, j) == true) return false;
                        }
                    }
                    return true;
                }
            }
        }

        public override bool IsIdentity {
            get {
                if (!IsDiagonal) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        if (Get(i, i) == false) return false;
                    }
                }
                return true;
            }
        }

        public override bool IsEmpty {
            get {
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (Get(i, j) == true) return false;
                    }
                }
                return true;
            }
        }

        public override Matrix<bool> Generate(bool[,] input) {
            return new BoolMatrix(input, (matrix) => true);
        }

        public override bool Replace(int row, int col, bool obj) {
            bool ret = Get(row, col);
            ReplaceWithoutReturn(row, col, obj);
            return ret;
        }

        internal override bool[,] ReplaceMatrix(bool[,] obj) {
            bool[,] ret = new bool[RowSize, ColumnSize];
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    ret[i, j] = Get(i, j);
                }
            }
            ReplaceMatrixWithoutReturn(obj);
            return ret;
        }
    }

    #region OUTSIDE IMPLEMENTATION
    public partial class SquareBoolMatrix : BoolMatrix {
        public SquareBoolMatrix(bool[,] rep, MatrixPredicate predicate) : base(rep, SquarePredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public SquareBoolMatrix(int size) : base(size, size) {
        }
    }

    public partial class DiagonalBoolMatrix : SquareBoolMatrix {
        public DiagonalBoolMatrix(int size) : base(size) {
            for(int i = 0; i < size; i++) {
                Replace(i, i, true);
            }
        }

        public DiagonalBoolMatrix(bool[,] rep, MatrixPredicate predicate) : base(rep, DiagonalPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }
    }

    public partial class IdentityBoolMatrix : DiagonalBoolMatrix {
        //for bools, identity = diagonal matrix
        public IdentityBoolMatrix(int size) : base(size) {
        }

        public IdentityBoolMatrix(bool[,] rep, MatrixPredicate predicate) : base(rep, IdentityPredicate) {
        }
    }
    #endregion
    #endregion

    #region CHARS
    public partial class CharMatrix : Matrix<char> {
        public CharMatrix(int row, int col) : base(row, col) {
        }

        public CharMatrix(char[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        public override bool IsDiagonal {
            get {
                if (!IsSquare) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        for (int j = 0; j < ColumnSize; j++) {
                            if (i != j && Get(i, j) != 0) return false;
                        }
                    }
                    return true;
                }
            }
        }

        public override bool IsIdentity {
            get {
                if (!IsDiagonal) return false;
                else {
                    for (int i = 0; i < RowSize; i++) {
                        if (Get(i, i) != 1) return false;
                    }
                }
                return true;
            }
        }

        public override bool IsEmpty {
            get {
                for (int i = 0; i < RowSize; i++) {
                    for (int j = 0; j < ColumnSize; j++) {
                        if (Get(i, j) != 0) return false;
                    }
                }
                return true;
            }
        }

        public override Matrix<char> Generate(char[,] input) {
            return new CharMatrix(input, (matrix) => true);
        }

        public override char Replace(int row, int col, char obj) {
            char ret = Get(row, col);
            ReplaceWithoutReturn(row, col, obj);
            return ret;
        }

        internal override char[,] ReplaceMatrix(char[,] obj) {
            char[,] ret = new char[RowSize, ColumnSize];
            for (int i = 0; i < RowSize; i++) {
                for (int j = 0; j < ColumnSize; j++) {
                    ret[i, j] = Get(i, j);
                }
            }
            ReplaceMatrixWithoutReturn(obj);
            return ret;
        }
    }
    #region OUTSIDE IMPLEMENTATION
    public partial class SquareCharMatrix : CharMatrix {
        public SquareCharMatrix(char[,] rep, MatrixPredicate predicate) : base(rep, SquarePredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public SquareCharMatrix(int row, int col) : base(row, col) {
        }
    }

    public partial class DiagonalCharMatrix : SquareCharMatrix {
        public DiagonalCharMatrix(char[,] rep, MatrixPredicate predicate) : base(rep, DiagonalPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public DiagonalCharMatrix(int row, int col) : base(row, col) {
        }
    }

    public partial class IdentityCharMatrix : DiagonalCharMatrix {
        public IdentityCharMatrix(char[,] rep, MatrixPredicate predicate) : base(rep, IdentityPredicate) {
            if (!predicate(this)) {
                throw new ArgumentException("The given matrix does not meet the requirements of the specified kind of matrix.");
            }
        }

        public IdentityCharMatrix(int row, int col) : base(row, col) {
        }
    }
    #endregion
    #endregion
}
