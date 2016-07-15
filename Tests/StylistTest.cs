using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Giggy Sanjan");
      Stylist secondStylist = new Stylist("Giggy Sanjan");

      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Giggy Sanjan");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Stylist testStylist = new Stylist("Giggy Sanjan");

      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Giggy Sanjan");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist testStylist = new Stylist("Giggy Sanjan");
      testStylist.Save();

      Client firstClient = new Client("Harry Knights", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Harry Knights", testStylist.GetId());
      secondClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
