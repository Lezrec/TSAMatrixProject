using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TSAMatrixProject.Exceptions {

    [Serializable]
    public abstract class MatrixArgumentException : ArgumentException {

    }

    [Serializable]
    public class NullMatrixException : MatrixArgumentException {

        private string message;

        public NullMatrixException(string message, int row, int col) {
            this.message = $"{message}. Row Input = {row}, Column Input = {col}.";
        }

        public override string ToString() {
            return message;
        }
    }

    //TODO: Flesh these out

    [Serializable]
    public class LinearDimensionMismatchException : MatrixArgumentException {

    }

    [Serializable]
    public class MultiplicationDimensionMismatchException : MatrixArgumentException {

    }

    [Serializable]
    public class MatrixTypeMismatchException : MatrixArgumentException {

    }
}
