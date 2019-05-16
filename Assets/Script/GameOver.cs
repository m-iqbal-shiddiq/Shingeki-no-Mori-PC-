using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public string sceneName;

    public SceneFader sceneFader;

    //fungsi saat object diaktifkan
    private void OnEnable()
    {
        roundsText.text = StatsPlayer.Wave.ToString();
    }

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
