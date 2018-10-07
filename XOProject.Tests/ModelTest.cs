using System;
using System.Threading.Tasks;
using XOProject.Controller;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace XOProject.Tests
{
   public class ModelTest
{
        [Test]
        public void ShouldTestHourlyShareRate()
        {
  
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            HourlyShareRate hsr = new HourlyShareRate();
            hsr.Id = 5;

            var errorCount = cpv.myValidation(hsr).Count;
            Assert.AreEqual(1, errorCount);


        }

        [Test]
        public void ShouldTestTrade()
        {
            Trade trade = new Trade();
            trade.Id = 10;
            trade.Symbol = "XYT";
            trade.NoOfShares = 10;
            trade.PortfolioId = 5;
            trade.Price = 10;
            trade.Action = "TYZ";
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var errorCount = cpv.myValidation(trade).Count;
            Assert.AreEqual(0, errorCount);
        }


        [Test]
        public void ShouldTestTradeAnalysis()
        {
            TradeAnalysis tradeAnalysis = new TradeAnalysis();
            tradeAnalysis.Action = "BUY";
            tradeAnalysis.Sum = 200;
            tradeAnalysis.Maximum = 100;
            tradeAnalysis.Minimum = 100;
            tradeAnalysis.Average = 100;

 
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var errorCount = cpv.myValidation(tradeAnalysis).Count;
            Assert.AreEqual(0, errorCount);
        }

        [Test]
        public void ShouldTestTradeModel()
        {
            TradeModel tradeModel = new TradeModel();
            tradeModel.Action = "BUY";
            tradeModel.NoOfShares = 10;

            tradeModel.PortfolioId = 1;
            tradeModel.Symbol = "ABC";
            


                CheckPropertyValidation cpv = new CheckPropertyValidation();
            var errorCount = cpv.myValidation(tradeModel).Count;
            Assert.AreEqual(0, errorCount);
        }
    }
}
