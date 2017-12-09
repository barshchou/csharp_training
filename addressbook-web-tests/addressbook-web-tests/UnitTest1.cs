using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;
            Assert.AreEqual(s1.Size, 15);
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle r1 = new Circle(5);
            Circle r2 = new Circle(10);
            Circle r3 = r1;

            Assert.AreEqual(r1.Radius, 5);
            Assert.AreEqual(r2.Radius, 10);
            Assert.AreEqual(r3.Radius, 5);

            r3.Radius = 15;
            Assert.AreEqual(r1.Radius, 15);
        }

    }
}
