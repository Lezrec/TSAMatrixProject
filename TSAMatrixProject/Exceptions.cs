using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.Exceptions {

    public abstract class MatrixArgumentException : ArgumentException {

    }

    public class NullMatrixException : MatrixArgumentException {

        private string message;

        public NullMatrixException(string message, int row, int col) {
            this.message = $"{message}. Row Input = {row}, Column Input = {col}.";
        }

        public override string ToString() {
            return message;
        }
    }

    public class LinearDimensionMismatchException : MatrixArgumentException {

    }

    public class MultiplicationDimensionMismatchException : MatrixArgumentException {

    }
}
