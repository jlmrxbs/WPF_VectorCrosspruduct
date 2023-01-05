using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM;
using System.Collections.Generic;

namespace MVVM_UnitTests
{
    [TestClass]
    public class UnitTestVectors
    {
        /// <summary>
        /// UnitTest für Methode Vectors.Invert
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenSingleVecInput), DynamicDataSourceType.Method)]
        public void TestInvert(Vectors vektor1, Vectors vektorResult)
        {
            Vectors actual = Vectors.Invert(vektor1);

            //Assert: Compare 2 objects!
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Addieren zweier Vektoren
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="vektor2"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInput), DynamicDataSourceType.Method)]
        public void TestAdd(Vectors vektor1, Vectors vektor2, Vectors vektorResult)
        {
            Vectors actual = vektor1 + vektor2;
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Subtrahieren zweier Vektoren
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="vektor2"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInput), DynamicDataSourceType.Method)]
        public void TestSub(Vectors vektor1, Vectors vektor2, Vectors vektorResult)
        {
            Vectors actual = vektor1 - vektor2;
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Multiplikation eines Vektors mit einem Faktor
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="factor"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenSingleVecFactorInput), DynamicDataSourceType.Method)]
        public void TestMultiplyFactor(Vectors vektor1, double factor, Vectors vektorResult)
        {
            Vectors actual = vektor1*factor;
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Division eines Vektors mit einem Faktor
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="factor"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenSingleVecFactorInput), DynamicDataSourceType.Method)]
        public void TestDivideFactor(Vectors vektor1, double factor, Vectors vektorResult)
        {
            Vectors actual = vektor1 / factor;
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Skalarprodukt eines Vektors
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="vektor2"></param>
        /// <param name="result"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInputSkalar), DynamicDataSourceType.Method)]
        public void TestSkalar(Vectors vektor1, Vectors vektor2, double result)
        {
            var actual = Vectors.Skalar(vektor1, vektor2);
            Assert.AreEqual(result, actual);
        }

        /// <summary>
        /// UnitTest für Methode Kreuzprodukt zweier Vektoren
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="vektor2"></param>
        /// <param name="vektorResult"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInput), DynamicDataSourceType.Method)]
        public void TestCrossproduct(Vectors vektor1, Vectors vektor2, Vectors vektorResult)
        {
            Vectors actual = Vectors.CrossProduct(vektor1, vektor2);
            var vectorCompare = new ObjectComparer();
            Assert.IsTrue(vectorCompare.Equals(vektorResult, actual));
        }

        /// <summary>
        /// UnitTest für Methode Laenge eines Vektors
        /// </summary>
        /// <param name="vektor1"></param>
        /// <param name="result"></param>
        [TestMethod]
        [DynamicData(nameof(GetTestDatenSingleVecInputSkalar), DynamicDataSourceType.Method)]
        public void TestLength(Vectors vektor1, double result)
        {
            var actual = Vectors.Laenge(vektor1);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInputSkalar), DynamicDataSourceType.Method)]
        public void TestAngle(Vectors vektor1, Vectors vektor2, double result)
        {
            var actual = Vectors.Winkel(vektor1, vektor2);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestDatenTwoVecInputBoolean), DynamicDataSourceType.Method)]
        public void TestEqual(Vectors vektor1, Vectors vektor2, bool result)
        {
            var vectorCompare = new ObjectComparer();
            var actual = vectorCompare.Equals(vektor1, vektor2);
            Assert.AreEqual(result, actual);
        }


        //*************************************************************************************
        //*****************************TESTDATEN***********************************************
        //*************************************************************************************

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Output: Vektor Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenSingleVecInput()
        {
            return new List<object[]>()
            {
                //(fail for invert method)
                new object[]{ new Vectors(1, -2, 3), new Vectors(1, 8, 1) },
                //(pass for invert method)
                new object[]{ new Vectors(1, -2, 3), new Vectors(-1, 2, -3)},
                //(pass for invert method)
                new object[]{ new Vectors(12.0, 13.9, -3.98), new Vectors(-12.0, -13.9, 3.98) }
            };
        }

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Output: Vektor Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenSingleVecInputSkalar()
        {
            return new List<object[]>()
            {
                //(pass for length method)
                new object[]{ new Vectors(5.9, 5.6, 0.25), 8.138335210594363 },
                //(pass for length method)
                new object[]{ new Vectors(2, 6, 13), 14.45683229480096 },
            };
        }

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Vektor 2 und Output: Vektor Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenTwoVecInput()
        {
            return new List<object[]>()
            {
                //(pass for add method) //(fail for subract method)
                new object[]{ new Vectors(1, 1, 3), new Vectors(1, 8, 1), new Vectors(2, 9, 4) },
                //(fail for add method) //(pass for subract method)
                new object[]{ new Vectors(1, 2, 3), new Vectors(7, 2, 5), new Vectors(-6, 0, -4)},
                //(pass for add method) //(fail for subract method)
                new object[]{ new Vectors(12.1, 11.8, 10.5), new Vectors(1, 1, 1), new Vectors(13.1, 12.8, 11.5) },
                //(pass for Crossproduct method) // (fail for add method) //(fail for subract method)
                new object[]{ new Vectors(1, 2, 3), new Vectors(4, 5, 6), new Vectors(-3, 6, -3) },
                //(pass for Crossproduct method) // (fail for add method) //(fail for subract method)
                new object[]{ new Vectors(1, 5, 7), new Vectors(-3, -7, 2), new Vectors(59, -23, 8) }
            };
        }

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Double Faktor und Output: Vektor Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenSingleVecFactorInput()
        {
            //(pass for multiply method) //(fail for divide method)
            yield return new object[]
            {
                new Vectors(5,2,3),
                2.0,
                new Vectors(10.0, 4.0, 6.0)
            };

            //(pass for multiply method) //(fail for divide method)
            yield return new object[]
            {
                new Vectors(5,10,50),
                5.0,
                new Vectors(1.0, 2.0, 10.0)
            };
        }

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Vektor 2 und Output: Double Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenTwoVecInputSkalar()
        {
            //(pass for skalar method)
            yield return new object[]
            {
                new Vectors(5,7,2.7),
                new Vectors(3.9,5.1,0.1),
                55.47
            };

            //(fail for skalar method)
            yield return new object[]
            {
                new Vectors(1,2,3),
                new Vectors(4, 5, 6),
                5.0
            };

            //(fail for skalar method) //(pass for angle method)
            yield return new object[]
            {
                new Vectors(1, 1, 8),
                new Vectors(2, 5, 1),
                1.2269615008393358
            };
        }

        /// <summary>
        /// Testdaten für Input: Vektor 1 und Vektor 2 und Output: Boolean Expected Result
        /// </summary>
        private static IEnumerable<object[]> GetTestDatenTwoVecInputBoolean()
        {
            //(pass for skalar method)
            yield return new object[]
            {
                new Vectors(5,5,2.7),
                new Vectors(5,5,2.7),
                true
            };

            //(fail for skalar method)
            yield return new object[]
            {
                new Vectors(1,2,3),
                new Vectors(1,2,3),
                true
            };

            //(fail for skalar method) //(pass for angle method)
            yield return new object[]
            {
                new Vectors(2, 5, 1),
                new Vectors(2, 5, 1),
                true
            };
        }

    }
}
