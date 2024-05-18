using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;

public class Write : MonoBehaviour
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
        query = "insert into douglas(name, surnames, age) values( '" + name.text + "' , '" + Surnames.text + "'," + textoPuntuacion.text + ")";
        
        MS_Command = new MySqlCommand(query, MS_Connection);
        MS_Command.ExecuteNonQuery();
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
        query = "CREATE TABLE IF NOT EXISTS douglas ( name VARCHAR(255), surnames VARCHAR(255), age INT)";
        MS_Command = new MySqlCommand(query, MS_Connection);
        MS_Command.ExecuteNonQuery();
    }
}
