using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client (string name, int stylistId, int id = 0)
    {
      _name = name;
      _stylistId = stylistId;
      _id = id;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && nameEquality && stylistIdEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }


    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientDescription = rdr.GetString(1);
        int clientCategoryId = rdr.GetInt32(2);
        Client newClient = new Client(clientDescription, clientCategoryId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (clientName, stylistId) VALUES (@name, @stylistId);";
      MySqlParameter description = new MySqlParameter();
      MySqlParameter category_id = new MySqlParameter();
      cmd.Parameters.AddWithValue("@name", this._name);
      cmd.Parameters.AddWithValue("@stylistId", this._stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `clients` WHERE clientId = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      // thisId.ParameterName = "@thisId";
      // thisId.Value = id;
      // cmd.Parameters.Add(thisId);
      cmd.Parameters.AddWithValue("@thisId", id);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientName = "";
      int stylistId = 0;

      while (rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        stylistId = rdr.GetInt32(2);
      }
      Client newClient = new Client(clientName, stylistId, clientId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;

      //To fail Find use below code:
      //Item dummyItem = new Item("dummy item");
      //return dummyItem;
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET clientName = @newClient WHERE clientId = @searchId;";
      // MySqlParameter searchId = new MySqlParameter();
      // searchId.ParameterName = "@searchId";
      // searchId.Value = _id;
      // cmd.Parameters.Add(searchId);
      // MySqlParameter description = new MySqlParameter();
      // description.ParameterName = "@newDescription";
      // description.Value = newDescription;
      // cmd.Parameters.Add(description);
      MySqlParameter searchId = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchId", this._id);
      MySqlParameter description = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newClient", newName);
      cmd.ExecuteNonQuery();
      _name = newName;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      //To fail create empty Edit method and write tests
    }

  }
}
