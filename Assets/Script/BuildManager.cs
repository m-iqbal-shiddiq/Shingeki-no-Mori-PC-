using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }
    public GameObject GorillaPrefab;

    public GameObject SnakePrefab;
    public GameObject SpiderPrefab;

    public GameObject buildEffect;

    private AnimalBlueprint animalToSpawn;

    public bool canBuild { get { return animalToSpawn != null;  } }
    public bool hasGold { get { return StatsPlayer.Gold >= animalToSpawn.cost; } }

    public void SpawnAnimalOn(Nodes node)
    {
        if (StatsPlayer.Gold < animalToSpawn.cost)
        {
            return;
        }
        StatsPlayer.Gold -= animalToSpawn.cost;

        GameObject animal = (GameObject)Instantiate(animalToSpawn.prefab, node.GetAnimalPosition(), Quaternion.identity);
        node.animal = animal;

        GameObject bEffect = (GameObject)Instantiate(buildEffect, node.GetAnimalPosition(), Quaternion.identity);

        Destroy(bEffect, 5f);

        Debug.Log("Hei" + StatsPlayer.Gold);
    }
    
    public void SetAnimalBuild(AnimalBlueprint animal)
    {
        animalToSpawn = animal;
    }

}
