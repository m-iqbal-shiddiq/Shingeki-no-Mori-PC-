using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public Text roundsText;

    //fungsi saat object diaktifkan
    private void OnEnable()
    {
        roundsText.text = StatsPlayer.Wave.ToString();
    }

    //fungsi retry
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    //fungsi menu

    public void Menu()
    {
        Debug.Log("Menu");
    }
}
