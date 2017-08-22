using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour 
{

    private static SceneManager _instance;
    public static SceneManager Instance
    {
        get
        {
            return (_instance = _instance ?? new SceneManager());
        }
    }


    public int Score { get;set; }

    private void Awake()
    {
        Score = 0;
        _instance = this;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("GameOver");
    }
}
