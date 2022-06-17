using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    public TMP_InputField PlayerName;
    public string hwname;
    public int maxScore;
    public TextMeshProUGUI maxScoreText;


    [System.Serializable]
    class SaveData
    {
        public int maxScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.maxScore;
        }
    }
    public void SaveThis()
    {
        hwname = PlayerName.text;
        PlayerPrefs.SetString("NAmeKey", hwname);
    }


    

    

    
    private void Awake()
    {
        LoadScore();
        hwname = PlayerPrefs.GetString("NAmeKey");
        PlayerName.text = hwname;

        maxScoreText.text = "Best Score: " + maxScore;

        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }
}

