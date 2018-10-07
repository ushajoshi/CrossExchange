using System;
using System.Threading.Tasks;
using XOProject.Controller;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace XOProject.Tests
{
    public class ShareControllerTests
    {
        private readonly Mock<IShareRepository> _shareRepositoryMock = new Mock<IShareRepository>();

        private readonly ShareController _shareController;

        public ShareControllerTests()
        {
            _shareController = new ShareController(_shareRepositoryMock.Object);
        }

        [Test]
        public void ShouldConstructShareController()
        {
            var result = new ShareController(_shareRepositoryMock.Object);
            Assert.NotNull(result);

        }

        [Test]
        public async Task Post_ShouldInsertHourlySharePrice()
        {
            var hourRate = new HourlyShareRate
            {
                Symbol = "CBI",
                Rate = 330.0M,
                TimeStamp = new DateTime(2018, 08, 17, 5, 0, 0)
            };

            // Arrange

            // Act
            var result = await _shareController.Post(hourRate);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
        }


        [Test]
        public async Task ShouldGet()
        {
            //Arrange 
            String symbol = "CBI";
            // Act
            var result = await _shareController.Get(symbol);

            // Assert
            Assert.NotNull(result);

            //var createdResult = result as List<HourlyShareRate>;
            //Assert.NotNull(createdResult);

        }


        [Test]
        public async Task ShouldGetNothing()
        {
            //Arrange 
            String symbol = "XYZ";
            // Act
            var result = await _shareController.Get(symbol);

            // Assert
            Assert.NotNull(result);

        }

        [Test]
        public async Task Post_GetLastestPrice()
        {
            string symbol = "CBI";

 
            var result = await _shareController.GetLatestPrice(symbol);
            Assert.NotNull(result);
            var obteainedResult = Task.FromResult(result);

            //var obteainedResult = result as HourlyShareRate;

            Assert.NotNull(obteainedResult);



        }

        [Test]
        public async Task Post_ShouldUpdateLastPrice()
        {
            string symbol = "CBI";

             await _shareController.UpdateLastPrice(symbol);
            var result = _shareController.GetLatestPrice(symbol);
            Assert.NotNull(result);

            var obteainedResult = result?.Result as HourlyShareRate;
            Assert.NotNull(obteainedResult);
        }



    }
}
