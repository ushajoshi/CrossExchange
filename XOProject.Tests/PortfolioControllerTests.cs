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
   public class PortfolioControllerTests
{
        private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock = new Mock<IPortfolioRepository>();
        private readonly Mock<IShareRepository> _shareRepositoryMock = new Mock<IShareRepository>();
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new Mock<ITradeRepository>();

        private readonly PortfolioController _portfolioController;
        public PortfolioControllerTests()
        {

            _portfolioController = new PortfolioController(_shareRepositoryMock.Object, _tradeRepositoryMock.Object, _portfolioRepositoryMock.Object);
            UnitTestBaseSetup();
            //(IShareRepository shareRepository, ITradeRepository tradeRepository, IPortfolioRepository portfolioRepository)
        }

        [SetUp]
        public void UnitTestBaseSetup()
        {
            Portfolio p = new Portfolio();
            p.Name = "John Doe";
            p.Id = 1;

            List<Portfolio> data = new List<Portfolio>();
            data.Add(p);

            var da = data.AsQueryable();
            var _portfolioRepositoryMock = new Mock<DbSet<Portfolio>>();

            _portfolioRepositoryMock.As<IQueryable<Portfolio>>().Setup(m => m.Provider).Returns(da.Provider);
            _portfolioRepositoryMock.As<IQueryable<Portfolio>>().Setup(m => m.Expression).Returns(da.Expression);
            _portfolioRepositoryMock.As<IQueryable<Portfolio>>().Setup(m => m.ElementType).Returns(da.ElementType);
            _portfolioRepositoryMock.As<IQueryable<Portfolio>>().Setup(m => m.GetEnumerator()).Returns(da.GetEnumerator());

        }

 

  

        [Test]
        public async Task Post_ShouldInsertPortfolio()
        {

            // Arrange
            var portfolio = new Portfolio();
            portfolio.Id = 2;
            portfolio.Name = "Usha Joshi";
            var trade1 = new Trade();
            trade1.Id = 1025;
            trade1.Price = 50;
            trade1.NoOfShares = 1;
            trade1.PortfolioId = 2;
            trade1.Symbol = "CBI";
            portfolio.Trade = new List<Trade>();
            portfolio.Trade.Add(trade1);



            // Act
            var result = await _portfolioController.Post(portfolio);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
        }

        [Test]
        public async Task GetPortfolioInfoTest()
        {

            // Arrange
            int portfolioid = 1;


            // Act
            var result = await _portfolioController.GetPortfolioInfo(portfolioid);

            // Assert
            Assert.NotNull(result);

            //Expected Result
            //string expectedResult = "John Doe";

            //var obtainresult = result as Portfolio;
           

            //Assert.Equals(expectedResult, obtainresult.Name);
        }

        [Test]
        public void checkHTTPException()
        {
            HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(100);
            Assert.AreEqual(100, httpStatusCodeException.StatusCode);


        }

    }
}
