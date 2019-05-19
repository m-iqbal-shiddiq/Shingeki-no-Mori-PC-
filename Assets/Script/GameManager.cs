using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameisOver ;

    public GameObject gameoverUI;

    public string nextLevel = "Level02";
    public int leveltoUnlock = 2;

    public SceneFader sceneFader;

    //Fungsi saat scene jalan
    private void Start()
    {
        GameisOver = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (GameisOver)
        {
            return; 
        }
        if (StatsPlayer.Lives <= 0)
        {
            EndGame();
        }        
    }

    void EndGame()
    {
        GameisOver = true;
        gameoverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level Won");
        PlayerPrefs.SetInt("levelReached",leveltoUnlock); // simpan progress ke playerprefs
        sceneFader.FadeTo(nextLevel); //lanjut scene selanjutnya
    }
}
