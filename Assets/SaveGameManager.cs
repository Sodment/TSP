using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class SaveGameManager : MonoBehaviour
{
    [SerializeField]
    private ListOfCities dataHolder;

   private void Start()
    {
       
    }
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
        using(StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
        {
            string numberofCities = ListOfCities.instance.CityList.Count.ToString();
            writer.WriteLine(numberofCities);
            foreach (Vector3Int vector in ListOfCities.instance.CityList)
            {
                writer.WriteLine(vector.x.ToString() + " " + vector.y.ToString());
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
            using(StreamReader reader = new StreamReader(file, Encoding.UTF8))
            {
                string firstline = reader.ReadLine();
                int count = Int32.Parse(firstline);
                for (int i = 0; i < count; i++)
                {
                    _ = new string[2];
                    string[] line = reader.ReadLine().Split(' ');
                    Vector3Int vector = new Vector3Int
                    {
                        x = Int32.Parse(line[0]),
                        y = Int32.Parse(line[1]),
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
