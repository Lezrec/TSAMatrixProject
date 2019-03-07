using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.Algebra {

    //TODO: This
    public delegate double Variable(string name);

    public class VariableMatrix : Matrix<Variable> {
        public VariableMatrix(int row, int col) : base(row, col) {
        }

        public VariableMatrix(Variable[,] rep, MatrixPredicate predicate) : base(rep, predicate) {
        }

        public override bool IsDiagonal => throw new NotImplementedException();

        public override bool IsIdentity => throw new NotImplementedException();

        public override bool IsEmpty => throw new NotImplementedException();

        public override Matrix<Variable> Generate(Variable[,] input) {
            throw new NotImplementedException();
        }

        public override Variable Replace(int row, int col, Variable obj) {
            throw new NotImplementedException();
        }

        internal override Variable[,] ReplaceMatrix(Variable[,] obj) {
            throw new NotImplementedException();
        }
    }
}
