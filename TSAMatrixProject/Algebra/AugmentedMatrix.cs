using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.ValueMatrices;
using TSAMatrixProject.ValueMatrices.Vectors;
using TSAMatrixProject;
using TSAMatrixProject.Exceptions;
using TSAMatrixProject.Algebra;
using TSAMatrixProject.Algebra.Vectors;

namespace TSAMatrixProject.Algebra {
    public class AugmentedMatrix : RationalNumberMatrix {

        private RationalNumberMatrix vars;
        private RationalNumberColumnVector vals;

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
            if (RowSize == 1 && ColumnSize == 2) return this.GenerateClone(); //already solved
            //break down into solving two rows
            AugmentedMatrix copy = this.GenerateClone();
            for (int k = 0; k < RowSize; k++)
            {
                for (int i = k+1; i < RowSize; i++)
                {
                    RationalNumber[] orig = GetRow(i).ToArray<RationalNumber>();
                    for (int j = 0; j < ColumnSize - 1; j++)
                    {
                        RationalNumberRowVector vec = SetToZero(i, k, j);
                        copy.ReplaceRow(k, vec);
                    }
                }
            }
            for (int k = RowSize-1; k >= 0; k--)
            {
                for (int i = k-1; i >= 0; i--)
                {
                    RationalNumber[] orig = GetRow(i).ToArray<RationalNumber>();
                    for (int j = ColumnSize-2; j >= k ; j--)
                    {
                        RationalNumberRowVector vec = SetToZero(k, i, j);
                        copy.ReplaceRow(k, vec);
                    }
                }
            }
            return copy;
            
        }

        public RationalNumberRowVector SetToZero(int row1, int row2, int col) {
            RationalNumber[] r1 = GetRow(row1).ToArray<RationalNumber>();
            RationalNumber[] r2 = GetRow(row2).ToArray<RationalNumber>();
            RationalNumber rat1 = r1[col];
            RationalNumber rat2 = r2[col];
            int solveNum = rat2.Numerator * rat1.Denominator;
            int oNum = rat1.Numerator * rat2.Denominator;
            RationalNumber mulRow = new RationalNumber(solveNum, oNum);
            Console.WriteLine(mulRow);
            RationalNumber[] ary = new RationalNumber[r2.Length];
            RationalNumber[] ret = new RationalNumber[r2.Length];
            for(int i = 0; i < r2.Length; i++)
            {
                ary[i] = new RationalNumber(r2[i].Numerator * mulRow.Denominator, r2[i].Denominator * mulRow.Numerator);
                Console.WriteLine("ary i:" + ary[i]);
                Console.WriteLine("r1 i:" + r1[i]);
                RationalNumber diff = ary[i] - r1[i];
                //Console.WriteLine(diff.ToString());
                ret[i] = diff;
            }

            return new RationalNumberRowVector(ret);

            
        }

        //TODO
        public AugmentedMatrix GaussJordanMatrix() {
            return null;
        }

        public new AugmentedMatrix GenerateClone()
        {
            RationalNumberMatrix mat1 = vars.GenerateClone();
            RationalNumberColumnVector mat2 = vals.GenerateClone();
            return new AugmentedMatrix(mat1, mat2);
        }

        public AugmentedMatrix SwapRows(int row1, int row2)
        {
            AugmentedMatrix ret = GenerateClone();
            RationalNumber[] ary1 = GetRow(row1).ToArray<RationalNumber>();
            RationalNumber[] ary2 = GetRow(row2).ToArray<RationalNumber>();
            for(int i = 0; i < ary1.Length; i++)
            {
                ret.Replace(row1, i, ary2[i]);
                ret.Replace(row2, i, ary1[i]);
            }
            return ret;
        }
    }
}
 