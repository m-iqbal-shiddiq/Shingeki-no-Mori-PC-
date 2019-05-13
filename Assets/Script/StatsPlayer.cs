using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    public static int Gold;
    public int startGold = 400;

    public static int Lives;
    public int startLives = 20;

    private void Start()
    {
        Gold = startGold;
        Lives = startLives;
    }



}
