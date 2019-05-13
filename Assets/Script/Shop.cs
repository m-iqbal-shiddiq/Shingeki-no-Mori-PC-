using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public AnimalBlueprint Gorilla;
    public AnimalBlueprint Spider;
    public AnimalBlueprint Snake;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectGorilla()
    {
        buildManager.SetAnimalBuild(Gorilla);
    }

    public void SelectSpider()
    {
        buildManager.SetAnimalBuild(Spider);
    }

    public void SelectSnake()
    {
        buildManager.SetAnimalBuild(Snake);
    }
}
