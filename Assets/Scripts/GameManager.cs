using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public SaveData saveData;

    private void Awake()
    {
        Debug.Log("GameManager Awake");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Instance.saveData = new SaveData();
        Instance.saveData.playerHighScore = "";
        Instance.saveData.highScore = 0;
        DontDestroyOnLoad(gameObject);
    }
}
