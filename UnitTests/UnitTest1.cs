using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSAMatrixProject;
using TSAMatrixProject.ValueMatrices;

namespace UnitTests {

    [TestClass]
    public class UnitTester {

        private Random rand = new Random(); //TODO: Figure out whether to keep the same seed every time or not.

        public IntegerMatrix GenerateRandomIntegerMatrix() {
            int row = rand.Next(1, 10);
            int col = rand.Next(1, 10);
            IntegerMatrix ret = new IntegerMatrix(row, col);

            for(int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    ret.Replace(i, j, rand.Next(9, 255));
                }
            }
            return ret;
        }

        [TestMethod]
        public void Integer_Matrix_Construction_Size_Test() {
            //Arrange
            int row = rand.Next(1, 10);
            int col = rand.Next(1, 10);
            IntegerMatrix m1 = new IntegerMatrix(row, col);
            //Act

            //Assert
            Assert.AreEqual(m1.RowSize, row);
            Assert.AreEqual(m1.ColumnSize, col);
        }

        [TestMethod]
        public void Integer_Matrix_Value_Change_Test() {
            //Arrange
            int row = rand.Next(1, 10);
            int col = rand.Next(1, 10);
            int rowIndex = rand.Next(1, row - 1);
            int colIndex = rand.Next(1, col - 1);
            IntegerMatrix m1 = new IntegerMatrix(row, col);
            //Act
            m1.Replace(rowIndex, colIndex, 5); //value doesnt matter just cant be zero
            //Assert
            Assert.AreEqual(m1.Get(rowIndex, colIndex), 5);
        }

        [TestMethod]
        public void Matrix_Transpose_Test() {
            //Arrange
            IntegerMatrix m1 = GenerateRandomIntegerMatrix();
            IntegerMatrix m2 = (IntegerMatrix)m1.GetTranspose();

            for (int i = 0; i < m1.RowSize; i++) {
                for (int j = 0; j < m1.ColumnSize; j++) {
                    Assert.AreEqual(m1.Get(i, j), m2.Get(j, i));
                }
            }
        }

        [TestMethod]
        public void Row_Append_Test() {
            //Arrange
            IntegerMatrix m1 = GenerateRandomIntegerMatrix();
            int col = rand.Next(1, 10);
            IntegerMatrix m2 = new IntegerMatrix(m1.RowSize, col);
            //Act
            IntegerMatrix m3 = (IntegerMatrix)m1.AppendByRow(m2);
            //Assert
            for(int i = 0; i < m1.RowSize; i++) {
                for (int j = m1.ColumnSize; j < m3.ColumnSize; j++) {
                    Assert.AreEqual(m3.Get(i, j), 0);
                }
            }
           
        }

        [TestMethod]
        public void Column_Append_Test() {
            //Arrange
            IntegerMatrix m1 = GenerateRandomIntegerMatrix();
            int row = rand.Next(1, 10);
            IntegerMatrix m2 = new IntegerMatrix(row, m1.ColumnSize);
            //Act
            IntegerMatrix m3 = (IntegerMatrix)m1.AppendByColumn(m2);
            //Assert
            for (int i = m1.RowSize; i < m3.RowSize; i++) {
                for (int j = 0; j < m1.ColumnSize; j++) {
                    Assert.AreEqual(m3.Get(i, j), 0);
                }
            }
        }

        [TestMethod]
        public void Row_Remove_Test() {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Column_Remove_Test() {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Generate_Test() {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Matrix_Multiplication_Test() {

        }

        [TestMethod]
        public void Matrix_Addition_Mismatch_Test() {

        }

        public void Matrix_Multiplication_Mismatch_Test() {

        }

        //TODO: Add Vector tests, doublematrix tests, charmatrix tests, boolmatrix tests.
    }
}
