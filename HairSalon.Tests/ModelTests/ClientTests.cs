using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest: IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=sheila_stephen_test;";
    }
    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("jerome", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_returnsName_string()
    {
      //Arrange
      string name = "Jesicca";
      Client newClient = new Client(name,1);
      //Act
      string result = newClient.GetName();
      //Assert
      Assert.AreEqual(name,result);
    }

    [TestMethod]
    public void Setname_SetName_void()
    {
      //Arrange
      string name = "Jesicca";
      Client newClient = new Client(name, 1);
      //Act
      string updateName = "John";
      newClient.SetName (updateName);
      string result = newClient.GetName();
      //Assert
      Assert.AreEqual(updateName,result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string name1 = "Jo";
      string name2 = "jen";
      Client newClient1 = new Client(name1, 1);
      Client newClient2 = new Client(name2, 1);
      newClient1.Save(); //Save needs to be added for test to pass
      newClient2.Save(); //Save needs to be added for test to pass
      List<Client> newList = new List<Client> {newClient1, newClient2};

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
