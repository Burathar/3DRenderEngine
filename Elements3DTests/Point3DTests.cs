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
    public class Point3DTests
    {
        private Point3D a = new Point3D(3, 2, 6);
        private Point3D b = new Point3D(1, -7, 3);

        [TestMethod()]
        public void AddTest()
        {
            Point3D result = new Point3D(3 + 1, 2 + -7, 6 + 3);
            a.Add(b);
            Assert.AreEqual(result, a);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Point3D result = new Point3D(3 - 1, 2 - -7, 6 - 3);
            a.Subtract(b);
            Assert.AreEqual(result, a);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Point3D result = new Point3D(3 * 1, 2 * -7, 6 * 3);
            a.Multiply(b);
            Assert.AreEqual(result, a);
        }

        [TestMethod()]
        public void DevideTest()
        {
            Point3D result = new Point3D(3 / 1d, 2 / -7d, 6 / 3d);
            a.Devide(b);
            Assert.AreEqual(result, a);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Point3D v1 = new Point3D(-6, 0, 1);
            Point3D v2 = new Point3D(-6, 0, 1);
            Point3D v3 = v1;
            Point3D v4 = new Point3D(6, 0, 1);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(v1, v3);
            Assert.AreNotEqual(v1, v4);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Point3D v1 = new Point3D(-6, 0, 1);
            Point3D v2 = new Point3D(-6, 0, 1);
            Point3D v3 = v1;
            Point3D v4 = new Point3D(6, 0, 1);
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.AreEqual(v1.GetHashCode(), v3.GetHashCode());
            Assert.AreNotEqual(v1.GetHashCode(), v4.GetHashCode());
        }
    }
}