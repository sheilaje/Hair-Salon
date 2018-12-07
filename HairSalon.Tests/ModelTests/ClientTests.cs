using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest
  //: IDisposable
  {

    // public void Dispose()
    // {
    //   Item.ClearAll();
    // }
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
  }
}
