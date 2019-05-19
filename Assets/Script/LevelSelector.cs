using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); //cek progress awal buat player. kalo baru langsung set 1

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1>levelReached)
                levelButtons[i].interactable = false; //matiin button kalo belum nyelesain scene sebelumnya
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
 