using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimalBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    // Mendapat harga jual dari animal
    public int GetSellCost()
    {
        return cost / 2;
    }
}
