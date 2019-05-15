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
    private Nodes selectedNode;

    public NodeUI nodeUI; 

    public bool canBuild { get { return animalToSpawn != null;  } }
    public bool hasGold { get { return StatsPlayer.Gold >= animalToSpawn.cost; } }
    
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
    
    public void SetAnimalBuild(AnimalBlueprint animal)
    {
        animalToSpawn = animal;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public AnimalBlueprint GetAnimaltoSpawn()
    {
        return animalToSpawn;
    }
}
