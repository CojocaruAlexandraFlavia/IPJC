using UnityEngine;
using System;
using System.Data;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

public class DatabaseHandler 
{
	public string server, database, uid, password;
	public bool pooling = true;
	private MySqlConnection con = null;
	private MD5 _md5Hash;

    public DatabaseHandler()
    {
        Initialize ();
    }

    private void Initialize()
    {
        server = "127.0.0.1";
        database = "unity";
        uid = "root";
        password = "root";
        string connectionString = "server=" + server + ";" + "uid=" + uid + ";"  + "password=" + password + ";" + "database=" + database + ";" ;
        con = new MySqlConnection(connectionString);
        
    }

	public string GetConnectionState()
    {
		return con.State.ToString ();
	}

    private bool OpenConnection()
    {   
        try
        {
            con.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Debug.Log("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    Debug.Log("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
}

    private bool CloseConnection(){
        try
        {
            con.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }

    public void Insert()
    {
        string query = "INSERT INTO users (id, username, password) VALUES(1, 'user', 'user')";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            
            cmd.ExecuteNonQuery();

            this.CloseConnection();
        }
    }

    public void Update()
    {
        string query = "UPDATE users SET username='joe', password='joe' WHERE name='user'";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = query;

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            this.CloseConnection();
        }
}

    public void Delete()
    {
        string query = "DELETE FROM users WHERE username='user'";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    public List< string >[] Select()
    {
        string query = "SELECT * FROM users";

        List< string >[] list = new List< string >[3];
        list[0] = new List< string >();
        list[1] = new List< string >();
        list[2] = new List< string >();

        if (this.OpenConnection() == true)
        {

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["username"] + "");
                list[2].Add(dataReader["password"] + "");
            }

            dataReader.Close();

            this.CloseConnection();

            return list;
        }
        else
        {
            return list;
        }
    }
}
