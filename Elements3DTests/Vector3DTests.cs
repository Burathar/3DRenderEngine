using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elements3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D.Tests
{
    [TestClass()]
    public class Vector3DTests
    {
        private Vector3D a = new Vector3D(5, 0, 0);
        private Vector3D b = new Vector3D(0, 5, 0);
        private Vector3D c = new Vector3D(2, 3, 4);
        private Vector3D d = new Vector3D(-6, 0, 1);
        private Vector3D dInverted = new Vector3D(6, 0, -1);
        private Vector3D e = new Vector3D(4, 7, -2);
        private Vector3D cPlusD = new Vector3D(-4, 3, 5);
        private Vector3D cMinD = new Vector3D(8, 3, 3);
        private Vector3D cTimeD = new Vector3D(-12, 0, 4);
        private Vector3D cDevD = new Vector3D(2 / -6d, 3 / 0d, 4 / 1d);
        private Vector3D cDevE = new Vector3D(2 / 4d, 3 / 7d, 4 / -2d);

        [TestMethod()]
        public void GetDotProdcutTest()
        {
            Assert.AreEqual(0, a.GetDotProdcut(b));
            Assert.AreEqual(0, b.GetDotProdcut(a));
            Assert.AreEqual(10, a.GetDotProdcut(c));
        }

        [TestMethod()]
        public void AddTest()
        {
            c.Add(d);
            Assert.AreEqual(cPlusD, c);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            c.Subtract(d);
            Assert.AreEqual(cMinD, c);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            c.Multiply(d);
            Assert.AreEqual(cTimeD, c);
        }

        [TestMethod()]
        public void DevideTest()
        {
            c.Devide(e);
            Assert.AreEqual(cDevE, c);
        }

        [TestMethod()]
        public void DevideByZeroTest()
        {
            c.Devide(d); // results in y=infinity
            Assert.AreEqual(cDevD, c);
        }

        [TestMethod()]
        public void InvertTest()
        {
            d.Invert();
            Assert.AreEqual(dInverted, d);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Vector3D v1 = new Vector3D(-6, 0, 1);
            Vector3D v2 = new Vector3D(-6, 0, 1);
            Vector3D v3 = v1;
            Vector3D v4 = new Vector3D(6, 0, 1);
            Vector3D v5 = new Vector3D(new Point3D(0, 0, 0), new Point3D(-6, 0, 1));
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(v1, v3);
            Assert.AreNotEqual(v1, v4);
            Assert.AreEqual(v1, v5);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Vector3D v1 = new Vector3D(-6, 0, 1);
            Vector3D v2 = new Vector3D(-6, 0, 1);
            Vector3D v3 = v1;
            Vector3D v4 = new Vector3D(6, 0, 1);
            Vector3D v5 = new Vector3D(new Point3D(0, 0, 0), new Point3D(-6, 0, 1));
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.AreEqual(v1.GetHashCode(), v3.GetHashCode());
            Assert.AreNotEqual(v1.GetHashCode(), v4.GetHashCode());
            Assert.AreEqual(v1.GetHashCode(), v5.GetHashCode());
        }

        [TestMethod()]
        public void GetAngleWithVectorTest()
        {
            Assert.AreEqual(0, a.GetAngleWith(Vector3D.XAxis));
            Assert.AreEqual(90, a.GetAngleWith(Vector3D.YAxis));
            Assert.AreEqual(90, a.GetAngleWith(Vector3D.ZAxis));

            Assert.AreEqual(68.2, Math.Round(c.GetAngleWith(Vector3D.XAxis), 2));
            Assert.AreEqual(56.15, Math.Round(c.GetAngleWith(Vector3D.YAxis), 2));
            Assert.AreEqual(42.03, Math.Round(c.GetAngleWith(Vector3D.ZAxis), 2));

            Assert.AreEqual(60.76, Math.Round(c.GetAngleWith(d), 2));
        }
    }
}