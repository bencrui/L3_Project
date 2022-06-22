using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

public class DataGate : MonoBehaviour
{
    string readFFP = Application.streamingAssetsPath + "/SaveFile.txt";
    string readFFD = Application.streamingAssetsPath + "/GameData.txt";
    string[] codes;

    void Start()
    {
        string[] pFileLines = File.ReadAllLines(readFFP);
        // don't forget about the default player file for the <new player>
    }

    public string[] Open()
    {
        return File.ReadAllLines(readFFP);
    }

    public string Codes(int n)
    {
        string[] details = File.ReadAllText(readFFD).Split('|');
        codes = details[1].Split('~');
        return codes[n];
    }

    public string[] SkillDetails(int n)
    {
        Debug.Log(File.ReadAllText(readFFD));
        string[] details1 = File.ReadAllText(readFFD).Split('|');
        Debug.Log(details1[0]);
        string[] details2 = details1[0].Split('~');
        Debug.Log(details2[n].Split('/')[0]);
        return details2[n].Split('/');
    }

    public void Save(string[] file)
    {

    }
}
