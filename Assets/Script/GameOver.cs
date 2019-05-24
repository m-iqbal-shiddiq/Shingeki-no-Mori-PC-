using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public string sceneName;

    public SceneFader sceneFader;

   
    //fungsi retry
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    //fungsi menu

    public void Menu()
    {
        sceneFader.FadeTo(sceneName);
    }
}
