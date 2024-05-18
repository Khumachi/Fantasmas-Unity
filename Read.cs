using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;

public class Read : MonoBehaviour
{
   
    private string connectionString;
    string query;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    private MySqlDataReader MS_Reader;
    public Text textCanvas;

    public void connection()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = "127.0.0.1";
        builder.UserID = "root";
        builder.Password = "";
        builder.Database = "marcadors";
        builder.Port = 3306;

        MS_Connection = new MySqlConnection(builder.ToString());
        MS_Connection.Open();


       

    }



    public void viewInfo() {

        query = "SELECT * FROM douglas";
        connection();

        MS_Command = new MySqlCommand(query, MS_Connection);

        MS_Reader = MS_Command.ExecuteReader();
        Console.WriteLine(MS_Reader);

        textCanvas.text = "";

        while (MS_Reader.Read())
        {
            textCanvas.text += "\n              " + MS_Reader["name"] + "                            " + MS_Reader["surnames"] + "                     " + MS_Reader["age"] ;
        }
        MS_Reader.Close();

    }
   
}