using System;
using MySql.Data.MySqlClient;
using QR_Generator_Test_C_;

public class DB
{
    private MySqlConnection conn;
    public DB()
    {
        string connectionString = "server=localhost;uid=root;pwd=Determinator3012;database=users;";
        conn = new MySqlConnection(connectionString);
    }
    
    public MySqlConnection GetConnection()
    {
        return conn;
    }

    public void OpenConnection()
    {
        if (conn.State == System.Data.ConnectionState.Closed)
            conn.Open();
    }

    public void CloseConnection()
    {
        if (conn.State == System.Data.ConnectionState.Open)
            conn.Close();
    }

}