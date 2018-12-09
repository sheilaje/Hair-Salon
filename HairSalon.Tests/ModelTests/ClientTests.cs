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
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("Joannah", 1);
      Client secondClient = new Client("Joannah", 1);
      // Assert
      Assert.AreEqual(firstClient, secondClient);
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
      newClient1.Save();
      newClient2.Save();
      //Act
      List<Client> newList = new List<Client> {newClient1, newClient2};
      List<Client> result = Client.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("jessica", 1);
      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("jen", 1);
      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Joannah", 1);
      testClient.Save();
      //Act
      Client foundClient = Client.Find(testClient.GetId());
      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      string firstName = "Joannah";
      Client testClient = new Client(firstName, 1);
      testClient.Save();
      string secondName = "JoJo";
      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.GetId()).GetName();
      //Assert
      Assert.AreEqual(secondName, result);
    }
  }
}
