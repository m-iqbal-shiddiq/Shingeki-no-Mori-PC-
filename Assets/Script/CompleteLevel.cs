using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string sceneName = "Level02Fix";

    public SceneFader sceneFader;

    public string nextLevel = "Level02";
    public int leveltoUnlock = 2;
    public string nameScene = "MainMenu";

    public void Continue()
    {
        //PlayerPrefs.SetInt("levelReached", leveltoUnlock); // simpan progress ke playerprefs
        //sceneFader.FadeTo(nextLevel); //lanjut scene selanjutnya
        sceneFader.FadeTo(nameScene);
    }

    //fungsi menu

    public void Menu()
    {
        sceneFader.FadeTo(sceneName);
    } 
}
