﻿using MySql.Data.MySqlClient;
using MySQLConnectorLibrary;

namespace WebApi_BT.Models
{
   
public class SqlManager
{
    private MySqlConnection conn = null;

    public SqlManager()
    {
        // constructor
    }

    public bool Connect(string connectionString)
    {
        Disconnect();

        if (connectionString == null || connectionString.Length < 30)
            return false;

        try
        {
            conn = new MySqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            conn = null;
            Console.WriteLine(ex.Message + "\n");
            //MessageBox.Show(ex.Message);
        }
        return (conn != null);
    }

    public void Disconnect()
    {
        if (conn != null)
        {
            conn.Close();
            conn = null;    // The garbage collector will free it later...
        }
    }

    public MySqlConnection GetConnection()
    {
        return conn;
    }

    public bool Open()
    {
        if (conn != null)
        {
            conn.Open();
            return true;
        }
        return false;
    }

    public bool Close()
    {
        if (conn != null)
        {
            conn.Close();
            return true;
        }
        return false;
    }

    public int ExecuteQuery(string query)
    {
        int result = 0;

        try
        {
            MySqlCommand myCommand = new MySqlCommand(query);

            myCommand.Connection = conn;
            conn.Open();
            result = myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\n");
            //MessageBox.Show(ex.Message);
            result = -1;    // negative indicates that it was an error...
        }
        return result;
    }

    public MySqlCommand GetSqlCommand(string command)
    {
        if (conn == null)
            return null;

        return new MySqlCommand(command, conn);
    }
}

}
