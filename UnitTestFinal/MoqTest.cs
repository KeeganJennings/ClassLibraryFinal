using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryFinal;
using Moq;
using System.Collections.Generic;

namespace UnitTestFinal
{
    [TestClass]
    public class MoqTest
    {
        [TestMethod]
        public void TestShippingControllerCalculateShipping()
        {
            //Arrange
            DefaultShippingService deliveryService;
            var mockDeliveryService = new Mock<IDeliveryService>();
            var mockProduct = new Mock<IProduct>();
            var mockShippingLocation = new Mock<IShippingLocation>();
            double cost;

            //Act
            mockDeliveryService.SetupGet(ds => ds.CostPerRefuel).Returns(1);
            mockDeliveryService.SetupGet(ds => ds.ShippingVehicle).Returns(new Truck());

            mockShippingLocation.SetupGet(sl => sl.StartZipCode).Returns(111111);
            mockShippingLocation.SetupGet(sl => sl.DestinationZipCode).Returns(60605);

            mockProduct.SetupGet(p => p.Name).Returns("Test Product");
            mockProduct.SetupGet(p => p.ShippingWeight).Returns(100);
            mockProduct.SetupGet(p => p.ShortDescription).Returns("Test Product Desc");

            List<IProduct> products = new List<IProduct>();
            products.Add(mockProduct.Object);

            deliveryService = new DefaultShippingService(mockDeliveryService.Object, products, mockShippingLocation.Object);

            cost = deliveryService.ShippingCost();

            //Assert

            Assert.IsNotNull(deliveryService);
            Assert.AreEqual(200, cost);
        }
    }
}
