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

    public GameObject AnotherPrefab;

    public GameObject SpiderPrefab;

    private AnimalBlueprint animalToSpawn;

    public bool canBuild { get { return animalToSpawn != null;  } }

    public void SpawnAnimalOn(Nodes node)
    {
        if (StatsPlayer.Gold < animalToSpawn.cost)
        {
            return;
        }
        StatsPlayer.Gold -= animalToSpawn.cost;

        GameObject animal = (GameObject)Instantiate(animalToSpawn.prefab, node.GetAnimalPosition(), Quaternion.identity);
        node.animal = animal;

        Debug.Log("Hei" + StatsPlayer.Gold);
    }
    
    public void SetAnimalBuild(AnimalBlueprint animal)
    {
        animalToSpawn = animal;
    }

}
