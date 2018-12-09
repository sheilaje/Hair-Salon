using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class HomeControllerTest
    {

      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
        //Arrange
        HomeController controller = new HomeController();
        //Act
        var indexView = controller.Index();
        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        Console.WriteLine(typeof(ViewResult));
      }

      [TestMethod]
      public void Index_HasCorrectedModelType_ClientList()
      {
        //Arrange
        HomeController controller = new HomeController();
        ViewResult indexView = controller.Index() as ViewResult;
        //Act
        var result = indexView.ViewData.Model;
        //Assert
        Assert.IsInstanceOfType(result, typeof(List<Client>));
      }

    }
}
