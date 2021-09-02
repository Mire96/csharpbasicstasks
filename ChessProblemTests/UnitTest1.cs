using NUnit.Framework;
using ChessProblem;
namespace ChessProblemTests
{   
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        

        [Test]
        public void TestCheckSameColumnTrue()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'a', row: 2);
            //Act
            bool result = f1.CheckSameColumn(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestCheckSameColumnFalse()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 2);
            //Act
            bool result = f1.CheckSameColumn(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestCheckSameRowTrue()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 1);
            //Act
            bool result = f1.CheckSameRow(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestCheckSameRowFalse()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 2);
            //Act
            bool result = f1.CheckSameRow(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestCheckSameDiagonalTrue()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 2);
            //Act
            bool result = f1.CheckSameDiagonal(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestCheckSameDiagonalFalse()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 1);
            //Act
            bool result = f1.CheckSameDiagonal(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestCalculateFieldDistance()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 1);
            //Act
            int result = f1.CalculateFieldDistance(f2);
            //Assert
            Assert.That(result == 1);
        }

        [Test]
        public void TestMoveRookRowTrue()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 1);
            Rook r1 = new Rook(field: f1, mark: 'r', Color.WHITE);
            //Act
            bool result = r1.MoveCheck(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestMoveRookRowFalse()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 2);
            Rook r1 = new Rook(field: f1, mark: 'r', Color.WHITE);
            //Act
            bool result = r1.MoveCheck(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestMoveKnight2Row1ColTrue()
        {   // Arrange
            Field f1 = new Field(column: 'e', row: 4);
            Field f2 = new Field(column: 'f', row: 6);
            Knight k1 = new Knight(field: f1, mark: 'n', Color.WHITE);
            //Act
            bool result = k1.MoveCheck(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestMoveKnight1Row2ColTrue()
        {   // Arrange
            Field f1 = new Field(column: 'e', row: 4);
            Field f2 = new Field(column: 'g', row: 5);
            Knight k1 = new Knight(field: f1, mark: 'n', Color.WHITE);
            //Act
            bool result = k1.MoveCheck(f2);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestMoveKnightFalse()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'b', row: 2);
            Knight k1 = new Knight(field: f1, mark: 'n', Color.WHITE);
            //Act
            bool result = k1.MoveCheck(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestMoveKnightByRow3False()
        {   // Arrange
            Field f1 = new Field(column: 'a', row: 1);
            Field f2 = new Field(column: 'a', row: 4);
            Knight k1 = new Knight(field: f1, mark: 'n', Color.WHITE);
            //Act
            bool result = k1.MoveCheck(f2);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Test1()
        {   // Arrange

            //Act

            //Assert
            Assert.Pass();
        }

        
    }
}