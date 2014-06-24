using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Turton.Api.Controllers;
using Turton.Domain.Models;
using Turton.Service.Interfaces;

namespace Turton.Test.Controller
{
    [TestClass]
    public class NewsEntryControllerTest
    {
        //method_WhatTesting_Returned convention

        [TestMethod]
        public void Get_LoadNewsEntryFromDatabase_ReturnList()
        {

            ////arrange
            var repositoryMock = new Mock<INewsEntryService>();

            var newsentry = new NewsEntry() { ID = 1, Headline = "headline" };

            var controller = new HomeController(repositoryMock.Object);

            //////act
            var result = controller.Get(1) as NewsEntry;

            //////assert
            repositoryMock.Verify(x => x.GetNewsEntry("1"), Times.Exactly(1));
            Assert.AreEqual(newsentry, (NewsEntry)result);

        }
    }
}
