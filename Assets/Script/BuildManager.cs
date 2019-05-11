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
    public GameObject standardAnimalPrefab;

    void Start()
    {
        animalToSpawn = standardAnimalPrefab;
    }

    private GameObject animalToSpawn;
    public GameObject GetAnimalToSpawn()
    {
        return animalToSpawn;
    }
    // Start is called before the first frame update

}
