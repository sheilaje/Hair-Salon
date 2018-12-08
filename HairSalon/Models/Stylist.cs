using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    //private List<Client> _clients;

    public Stylist(string sName, int id = 0)
    {
      _name = sName;
      _id = id;
      //_clients = new List<Client>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(StylistName, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        return (idEquality && nameEquality);
        //fail the Equals test by not adding the Equals method
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    } // add this method to get rid of the hashcode warning

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (stylistName) VALUES (@sName);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@sName";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public static Stylist Find(int id)
    // {
    //
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
    //   // MySqlParameter idParameter = new MySqlParameter();
    //   // idParameter.ParameterName = "@searchId";
    //   // idParameter.ParameterValue = stylistId;
    //   cmd.Parameters.AddWithValue("@stylistId", id);
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int StylistId = 0;
    //   string StylistName = "";
    //   while(rdr.Read())
    //   {
    //     StylistId = rdr.GetInt32(0);
    //     StylistName = rdr.GetString(1);
    //   }
    //   Stylist newStylist = new Stylist(StylistName, StylistId);
    //   conn.Close();
    //   if(conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newStylist;
    // }

    // public List<Item> GetItems()
    // {
    //   List<Item> allStylistItems = new List<Item> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM items WHERE category_id = @category_id;";
    //   MySqlParameter categoryId = new MySqlParameter();
    //   // categoryId.ParameterName = "@categoryId";
    //   // categoryName.ParameterValue = this._id;
    //   // cmd.Parameters.Add(categoryId);
    //   cmd.Parameters.AddWithValue("@category_id", this._id);
    //
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //   while(rdr.Read())
    //   {
    //     int itemId = rdr.GetInt32(0);
    //     string itemDescription = rdr.GetString(1);
    //     int itemStylistId = rdr.GetInt32(2);
    //     Item newItem = new Item(itemDescription, itemStylistId, itemId);
    //     allStylistItems.Add(newItem);
    //   }
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allStylistItems;
      //Add following code to return dummy list to fail test method GetItems_RetrievesAllItemsWithCategory
      //List<Item> allCategoryItems = new List<Item> {};
      //return allCategoryItems;
    // }

  }
}
