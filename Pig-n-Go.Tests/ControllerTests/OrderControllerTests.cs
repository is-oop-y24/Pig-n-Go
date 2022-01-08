using NUnit.Framework;
using Pig_n_Go.Controllers;

namespace Pig_n_Go.Tests.ControllerTests
{
    public class OrderControllerTests
    {
        [SetUp]
        public void Setup()
        {
            var orderController = new OrderController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}