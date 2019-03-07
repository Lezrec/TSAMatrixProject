using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.ValueMatrices.Vectors;
using TSAMatrixProject;
using TSAMatrixProject.Exceptions;

namespace TSAMatrixProject.Algebra {
    public class AugmentedMatrix : RationalNumberMatrix {

        private DoubleMatrix vars;
        private DoubleColumnVector vals;

        //TODO: Test this.
        public AugmentedMatrix(RationalNumberMatrix variables, RationalNumberColumnVector values) : base(variables.RowSize, variables.ColumnSize + 1) {
            if (!RowParity(variables, values)) {
                throw new MatrixTypeMismatchException(); //must have row parity
            }
            else {
                vars = variables;
                vals = values;
                for(int i = 0; i < vars.RowSize; i++) {
                    for (int j = 0; j < vars.ColumnSize; j++) {
                        Replace(i, j, vars.Get(i, j));
                    }
                    Replace(i, vars.ColumnSize, vals.Get(i));
                }
            }
        }

        //row operations: multiply a row by a constant, add a multiple of a row to another, swap rows
        public AugmentedMatrix GaussMatrix() {
            //break down into solving two rows
            AugmentedMatrix copy = (AugmentedMatrix)this.GenerateClone(); //hopefully this doesnt break everything
            return null;
        }

        private void SolveRows(int row1, int row2) {
            double[] r1 = GetRow(row1).ToArray<double>();
            double[] r2 = GetRow(row2).ToArray<double>();
        }

        //TODO
        public AugmentedMatrix GaussJordanMatrix() {
            return null;
        }
    }
}
