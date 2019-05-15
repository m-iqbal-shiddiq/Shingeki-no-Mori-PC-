using UnityEngine.EventSystems;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    [HideInInspector]
    public GameObject animal;
    [HideInInspector]
    public AnimalBlueprint animalBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Color hoverColor;
    public Color havenotGoldColor;
    private Renderer Rend;
    private Color startColor;
    public Quaternion rotationOffset;
    public Vector3 positionOffset;
    BuildManager buildManager;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        startColor = Rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetAnimalPosition()
    {
        return transform.position + positionOffset;
    }

    void spawnAnimal(AnimalBlueprint blueprint)
    {
        if (StatsPlayer.Gold < blueprint.cost)
        {
            return;
        }
        StatsPlayer.Gold -= blueprint.cost;

        GameObject _animal = (GameObject)Instantiate(blueprint.prefab, GetAnimalPosition(), Quaternion.identity);
        animal = _animal;

        animalBlueprint = blueprint;

        GameObject bEffect = (GameObject)Instantiate(buildManager.buildEffect, GetAnimalPosition(), Quaternion.identity);

        Destroy(bEffect, 3f);

        Debug.Log("Hei" + StatsPlayer.Gold);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasGold)
        {
            Rend.material.color = hoverColor;
        } else
        {
            Rend.material.color = havenotGoldColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (animal != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        spawnAnimal(buildManager.GetAnimaltoSpawn());
    }

    public void UpgradeAnimal()
    {
        if (StatsPlayer.Gold < animalBlueprint.upgradeCost)
        {
            return;
        }
        StatsPlayer.Gold -= animalBlueprint.upgradeCost;

        Destroy(animal);

        GameObject _animal = (GameObject)Instantiate(animalBlueprint.upgradedPrefab, GetAnimalPosition(), Quaternion.identity);
        animal = _animal;

        GameObject bEffect = (GameObject)Instantiate(buildManager.buildEffect, GetAnimalPosition(), Quaternion.identity);

        Destroy(bEffect, 3f);
        isUpgraded = true;

        Debug.Log("Upgrade");
    }

    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }
}
