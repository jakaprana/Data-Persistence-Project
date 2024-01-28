using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField enterNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MenuUIHandler Start");
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        GameManager.Instance.playerName = enterNameInputField.text;
    }

    public void SelectEnterName()
    {
        if (GameManager.Instance.saveData.highScore == 0)
        {
            this.bestScoreText.text = "Best Score : : 0";
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
        #else
                    Application.Quit();
        #endif
    }

    void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            this.bestScoreText.text = "Best Score : " + saveData.playerHighScore + " : " + saveData.highScore;
            GameManager.Instance.saveData = saveData;
            GameManager.Instance.playerName = enterNameInputField.text = saveData.playerHighScore;
        }
    }
}
