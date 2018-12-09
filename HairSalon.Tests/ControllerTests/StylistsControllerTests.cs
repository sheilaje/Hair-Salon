using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      ActionResult indexView = controller.Index();
      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Index() as ViewResult;
      //Act
      var resultList = indexView.ViewData.Model;
      Console.WriteLine(resultList);
      //Assert
      Assert.IsInstanceOfType(resultList, typeof(List<Stylist>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      ActionResult newView = controller.New();
      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create("Joannah") as RedirectToActionResult;
      //Act
      string result = actionResult.ActionName;
      //Assert
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      int id = 1;
      ActionResult showView = controller.Show(id);
      //Assert
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      int id = 1;
      ViewResult showView = controller.Show(id) as ViewResult;
      //Act
      var result = showView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Create_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      int stylistId = 1;
      string clientName = "Jenny";
      ActionResult createView = controller.Create(stylistId ,clientName);
      //Assert
      Assert.IsInstanceOfType(createView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_HasCorrectModelType_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();
      //Act
      int stylistId = 1;
      string clientName = "Jenny";
      ViewResult createView = controller.Create(stylistId, clientName) as ViewResult;
      //Act
      var result = createView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }
  }
}
