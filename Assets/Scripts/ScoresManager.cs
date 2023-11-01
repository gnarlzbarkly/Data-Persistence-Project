using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Scores;

public class ScoresManager : MonoBehaviour
{
    public List<HighScore> HighScores;

    public static ScoresManager Instance;
    
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     [System.Serializable]
    class SaveData
    {
        public List<HighScore> HighScores;
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        data.HighScores = HighScores;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScores = data.HighScores;
        }
        else
        {
            HighScores = new List<HighScore>();
        }
    }

    public void AddScore(string name, int score)
    {
        HighScores.Add(new HighScore(name, score));
        SaveScores();
    }
}
