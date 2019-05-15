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

    //Milih Gorilla
    public void SelectGorilla()
    {
        buildManager.SetAnimalBuild(Gorilla);
    }

    //Milih Spider
    public void SelectSpider()
    {
        buildManager.SetAnimalBuild(Spider);
    }

    //Milih Snake
    public void SelectSnake()
    {
        buildManager.SetAnimalBuild(Snake);
    }
}
