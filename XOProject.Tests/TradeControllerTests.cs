using System;
using System.Threading.Tasks;
using XOProject.Controller;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace XOProject.Tests
{
   public class TradeControllerTests
{

        private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock = new Mock<IPortfolioRepository>();
        private readonly Mock<IShareRepository> _shareRepositoryMock = new Mock<IShareRepository>();
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new Mock<ITradeRepository>();

        private readonly TradeController _tradeController;

        public TradeControllerTests()
        {

            _tradeController = new TradeController(_shareRepositoryMock.Object, _tradeRepositoryMock.Object, _portfolioRepositoryMock.Object);
            
            //(IShareRepository shareRepository, ITradeRepository tradeRepository, IPortfolioRepository portfolioRepository)
        }


        [Test]
        public async Task ShouldGetAllTradings()
        {
            //Arrange 
            int portFolioid = 1;
            // Act
            var result = await _tradeController.GetAllTradings(portFolioid);

            // Assert
            Assert.NotNull(result);

        }

        [Test]
        public async Task ShouldGetAnalysis()
        {
            //Arrange 
            string symbol = "REL";
            // Act
            var result = await _tradeController.GetAnalysis(symbol);

            // Assert
            Assert.NotNull(result);
            

        }
    }
}
