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

    private GameObject animalToSpawn;

    public GameObject GetAnimalToSpawn()
    {
        return animalToSpawn;
    }
    
    public void SetAnimalBuild(GameObject animal)
    {
        animalToSpawn = animal;
    }

}
