using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int id = 1;
      ActionResult showView = controller.New( id );
      //Assert
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_HasCorrectModelType_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      int id = 1;
      ViewResult showView = controller.New(id) as ViewResult;
      //Act
      var result = showView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Stylist));
      //Console.WriteLine(showView);
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId =1;
      ActionResult showView = controller.Show(stylistId ,clientId);
      //Assert
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId =1;
      ViewResult showView = controller.Show(stylistId, clientId) as ViewResult;
      //Act
      var result = showView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void DeleteAll_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      ActionResult newView = controller.DeleteAll();
      //Assert
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId =1;
      ActionResult editView = controller.Edit(stylistId ,clientId);
      //Assert
      Assert.IsInstanceOfType(editView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId =1;
      ViewResult editView = controller.Edit(stylistId, clientId) as ViewResult;
      //Act
      var result = editView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Update_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId = 1;
      string newName = "Jenny";
      ActionResult updateView = controller.Update(stylistId ,clientId, newName);
      //Assert
      Assert.IsInstanceOfType(updateView, typeof(ViewResult));
    }

    [TestMethod]
    public void Update_HasCorrectModelType_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      int stylistId = 1;
      int clientId = 1;
      string newName = "Jenny";
      ViewResult updateView = controller.Update(stylistId, clientId, newName) as ViewResult;
      //Act
      var result = updateView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }
  }
}
