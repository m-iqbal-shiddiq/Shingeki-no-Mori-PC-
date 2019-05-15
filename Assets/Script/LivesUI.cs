using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    
    // Update text nyawa
    void Update()
    {
        livesText.text = StatsPlayer.Lives + " LIVES";    
    }
}
