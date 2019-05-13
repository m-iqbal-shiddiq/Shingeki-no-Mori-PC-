using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    public static int Gold;
    public int startGold = 400;

    private void Start()
    {
        Gold = startGold;
    }
}
