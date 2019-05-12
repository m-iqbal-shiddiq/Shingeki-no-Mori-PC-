﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void BuyGorilla()
    {
        buildManager.SetAnimalBuild(buildManager.GorillaPrefab);
    }

    public void BuyAnother()
    {
        buildManager.SetAnimalBuild(buildManager.AnotherPrefab);
    }
}
