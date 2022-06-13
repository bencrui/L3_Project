using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

public class DataGate : MonoBehaviour
{
    string connectionString = null;

    MySqlConnection cnn;

    void Start()
    {
        connectionString = "server=localhost;database=Database1;uid=root;pwd=abc123;";
        cnn = new MySqlConnection(connectionString);
        cnn.Open();

        FeedDetails();
    }
    public ArrayList FeedDetails()
    {
        ArrayList details = new ArrayList();

        string sql = "SELECT Description FROM TSkill WHERE Description LIKE 'Description 2';";
        var cmd = new MySqlCommand(sql, cnn);
        Debug.Log(cmd.ExecuteScalar().ToString());


        return details;
    }

    public void Save(string[] file)
    {

    }
}
