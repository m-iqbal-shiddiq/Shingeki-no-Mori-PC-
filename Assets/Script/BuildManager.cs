using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject GorillaPrefab;
    public GameObject SnakePrefab;
    public GameObject SpiderPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private AnimalBlueprint animalToSpawn;

    private Nodes selectedNode;

    public NodeUI nodeUI; 

    public bool canBuild { get { return animalToSpawn != null;  } }
    public bool hasGold { get { return StatsPlayer.Gold >= animalToSpawn.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }

    // Memilih node yang akan dipanggi animal
    public void SelectNode(Nodes node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        animalToSpawn = null;
        nodeUI.SetTarget(node);
        
    }
    // Tidak memilih node
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    // Melakukan set animal
    public void SetAnimalBuild(AnimalBlueprint animal)
    {
        animalToSpawn = animal;
        DeselectNode();
    }

    
    // Mengembalikan animal yang akan dipanggil
    public AnimalBlueprint GetAnimaltoSpawn()
    {
        return animalToSpawn;
    }
}
