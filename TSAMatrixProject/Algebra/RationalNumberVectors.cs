using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject.ValueMatrices.Vectors;
using TSAMatrixProject;
using TSAMatrixProject.Exceptions;

namespace TSAMatrixProject.Algebra.Vectors
{
    public class RationalNumberRowVector : RationalNumberMatrix, IVector<RationalNumber>
    {
        public RationalNumberRowVector(int size) : base(1, size)
        {

        }

        public RationalNumberRowVector(RationalNumber[] rep) : base(1, rep.Length)
        {
            for(int i = 0; i < Dimension; i++)
            {
                Replace(0, i, rep[i]);
            }
        }

        public int Dimension => ColumnSize;

        public RationalNumber DotProduct(IVector<RationalNumber> other)
        {
            return VectorMath.DotProduct<RationalNumber>(this, other);
        }

        public RationalNumber Get(int index)
        {
            return Get(0, index);
        }
    }

    public class RationalNumberColumnVector : RationalNumberMatrix, IVector<RationalNumber>
    {
        public RationalNumberColumnVector(int size) : base(size, 1)
        {

        }

        public RationalNumberColumnVector(RationalNumber[] rep) : base(rep.Length, 1)
        {
            for(int i = 0; i < Dimension; i++)
            {
                Replace(i, 0, rep[i]);
            }
        }

        public int Dimension => RowSize;

        public RationalNumber DotProduct(IVector<RationalNumber> other)
        {
            return VectorMath.DotProduct<RationalNumber>(this, other);
        }

        public RationalNumber Get(int index)
        {
            return Get(index, 0);
        }

        public new RationalNumberColumnVector GenerateClone()
        {
            RationalNumberColumnVector ret = new RationalNumberColumnVector(Dimension);
            for(int i = 0; i < Dimension; i++)
            {
                ret.Replace(i, 0, new RationalNumber(Get(i, 0).Numerator, Get(i, 0).Denominator));
            }
            return ret;
        }
    }
}