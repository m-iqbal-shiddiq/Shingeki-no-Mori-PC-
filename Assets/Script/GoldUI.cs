using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{

    public Text textGold;

    // Tampilin Gold ke text
    void Update()
    {
        textGold.text = StatsPlayer.Gold.ToString() + "G";
    }
}
