using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    [SerializeField]
    private ListOfCities dataHolder;
    Encoding encoding = new UTF8Encoding(false);

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/save_game");
    }

    public void SaveGameJson()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save_game/TSPdata.json");
        string json = JsonUtility.ToJson(dataHolder);
        binaryFormatter.Serialize(file, json);
        file.Close();
    }

    public void LoadGameJson()
    {
        if(Directory.Exists(Application.persistentDataPath + "/save_game"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/save_game/TSPdata.json"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/save_game/TSPdata.json", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)binaryFormatter.Deserialize(file), dataHolder);
            file.Close();
        }
    }
    //THIS IS BAD METHOD
    public void SaveGameText()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        FileStream file = new FileStream(Application.persistentDataPath + "/save_game/TSPdata.txt", FileMode.OpenOrCreate);
        using(StreamWriter writer = new StreamWriter(file, encoding))
        {
            string numberofCities = ListOfCities.instance.CityList.Count.ToString();
            writer.WriteLine(numberofCities);
            int i = 0;
            foreach (Vector3Int vector in ListOfCities.instance.CityList)
            {
                writer.WriteLine(++i +" " + vector.x.ToString() + " " + vector.y.ToString());
            }
        }
        file.Close();
    }

    public void LoadGameText()
    {
        if (Directory.Exists(Application.persistentDataPath + "/save_game"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        if (File.Exists(Application.persistentDataPath + "/save_game/TSPdata.json"))
        {
            List<Vector3Int> tmpList = new List<Vector3Int>();
            FileStream file = new FileStream(Application.persistentDataPath + "/save_game/TSPdata.txt", FileMode.Open);
            using(StreamReader reader = new StreamReader(file, encoding))
            {
                string firstline = reader.ReadLine();
                int count = Int32.Parse(firstline);
                for (int i = 0; i < count; i++)
                {
                    _ = new string[3];
                    string[] line = reader.ReadLine().Split(' ');
                    Vector3Int vector = new Vector3Int
                    {
                        x = Int32.Parse(line[1]),
                        y = Int32.Parse(line[2]),
                        z = 0
                    };
                    tmpList.Add(vector);
                }
                
            }
            ListOfCities.instance.CityList = tmpList;
            file.Close();
        }
    }
}
