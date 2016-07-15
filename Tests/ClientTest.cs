using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
  }
  [Fact]
  public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
  {
    //Arrange, Act
    Client firstClient = new Client("Harry Knights", 1);
    Client secondClient = new Client("Harry Knights", 1);

    //Assert
    Assert.Equal(firstClient, secondClient);
  }
}
