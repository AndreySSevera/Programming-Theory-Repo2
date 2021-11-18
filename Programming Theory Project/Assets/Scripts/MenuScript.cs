using System.IO;
using System;
using UnityEngine;


public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    public float CountMass { get; set; }
    public int CountSlabs { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [Serializable]
    public class SaveData
    {
        public float countMass;
        public int countSlabs;
    }
    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.countMass = CountMass;
        saveData.countSlabs = CountSlabs;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.dataPath + "/savefile.json", json);
    }
    public void LoadData()
    {
        if (File.Exists(Application.dataPath + "/savefile.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/savefile.json");

            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            CountMass = saveData.countMass;
            CountSlabs = saveData.countSlabs;
        }
    }
}
