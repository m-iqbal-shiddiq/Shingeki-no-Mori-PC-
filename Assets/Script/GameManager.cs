using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameisOver ;

    public GameObject gameoverUI;

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
        Debug.Log("and I am Iron Man");
        gameoverUI.SetActive(true);
    }
}
