//Realiza la operación UPDATE de UNITY con MYSQL
// Actualiza el score del jugador segun el nombre ingresado

using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;
using System;

public class Update : MonoBehaviour
{
    public Text name;
    public Text Surnames;
    public Text age;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    public Martillo martilloScript;
    public TextMeshProUGUI textoPuntuacion;

    public void Start()
    {
        int puntuacion = PlayerPrefs.GetInt("Puntuacion", 0);
        textoPuntuacion.text = puntuacion.ToString();
    }

    public void sendInfo()
    {
        connection();
        CreateDouglasTable();

        
        query = "SELECT * FROM douglas WHERE name = @Name ORDER BY age DESC LIMIT 1";
        MS_Command = new MySqlCommand(query, MS_Connection);
        MS_Command.Parameters.AddWithValue("@Name", name.text);
        MySqlDataReader reader = MS_Command.ExecuteReader();
        
        if (reader.Read())
        {
            
            query = "UPDATE douglas SET surnames = @Surnames, age = @Age WHERE name = @Name AND age = @OldAge";
            MS_Command = new MySqlCommand(query, MS_Connection);
            MS_Command.Parameters.AddWithValue("@Surnames", Surnames.text);
            MS_Command.Parameters.AddWithValue("@Age", textoPuntuacion.text);
            MS_Command.Parameters.AddWithValue("@Name", name.text);
            MS_Command.Parameters.AddWithValue("@OldAge", reader.GetInt32("age"));

            reader.Close();

            MS_Command.ExecuteNonQuery();
        }
        else
        {   
            Debug.Log("No se encontró ningún registro para actualizar.");
        }
        
        MS_Connection.Close();
    }

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

    public void CreateDouglasTable()
    {
        query = "CREATE TABLE IF NOT EXISTS douglas (name VARCHAR(255), surnames VARCHAR(255), age INT)";
        MS_Command = new MySqlCommand(query, MS_Connection);
        MS_Command.ExecuteNonQuery();
    }
}
